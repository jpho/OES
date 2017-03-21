using OrderEntryDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OrderEntrySystem
{
    /// <summary>
    /// Interaction logic for EntityView.xaml.
    /// </summary>
    public partial class EntityView : UserControl
    {
        private StackPanel commandPanel;

        private Grid propertyGrid;

        public EntityView()
        {
            this.InitializeComponent();

         
        }

        private void BuildLabeledControl(PropertyInfo propertyInfo)
        {
            Grid grid = new Grid();

            grid.Width = 270.0;
            grid.Height = 23.0;
            grid.Margin = new Thickness(0, 0, 15, 5);

            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = new GridLength(120);
            grid.ColumnDefinitions.Add(columnDefinition);

            columnDefinition = new ColumnDefinition();
            columnDefinition.Width = new GridLength(150);
            grid.ColumnDefinitions.Add(columnDefinition);

            ControlType controlType = DisplayUtil.GetControlType(propertyInfo);

              Binding binding = this.CreateBinding(propertyInfo, controlType, this.DataContext);

            TextBox textBox = null;

            switch (controlType)
            {
                case ControlType.Button:
                    Button button = new Button();
                    button.SetBinding(Button.CommandProperty, binding);
                    button.Content = DisplayUtil.GetControlDescription(propertyInfo);
                    button.HorizontalAlignment = HorizontalAlignment.Right;
                    button.Margin = new Thickness(5, 0, 0, 0);
                    button.Padding = new Thickness(15, 3, 15, 3);
                    this.commandPanel.Children.Add(button);
                    break;



                case ControlType.CheckBox:
                    CheckBox checkBox = new CheckBox();
                    checkBox.SetBinding(CheckBox.IsCheckedProperty, binding);
                    Grid.SetColumn(checkBox, 1);
                    grid.Children.Add(checkBox);
                    break;

                    // combo box
                case ControlType.ComboBox:
                    ComboBox comboBox = new ComboBox();

                    if (propertyInfo.PropertyType.IsEnum)
                    {
                        comboBox.ItemsSource = Enum.GetValues(propertyInfo.PropertyType);
                        // populate?
                    }
                    else
                    {
                        comboBox.ItemsSource = RepositoryManager.GetLookupRepository(propertyInfo.PropertyType).LookupList;
                    }

                    comboBox.SetBinding(ComboBox.SelectedItemProperty, binding);
                    Grid.SetColumn(comboBox, 1);
                    grid.Children.Add(comboBox);
                    break;

                case ControlType.DateBox:
                    break;

                case ControlType.Label:
                     textBox = new TextBox();
                    textBox.IsEnabled = false;
                    textBox.SetBinding(TextBox.TextProperty, binding);

                    Grid.SetColumn(textBox, 1);
                    grid.Children.Add(textBox);
                    
                    break;

                case ControlType.None:
                    break;


                case ControlType.TextBox:
                     textBox = new TextBox();
                     textBox.SetBinding(TextBox.TextProperty, binding);
                    Grid.SetColumn(textBox, 1);
                    grid.Children.Add(textBox);
                    break;
                default:
                    break;
            }

            if (controlType != ControlType.Button)
            {
                Label label = new Label();
                label.Content = DisplayUtil.GetControlDescription(propertyInfo);
                label.Margin = new Thickness(0, -2, 0, 0);
                Grid.SetColumn(label, 0);
                grid.Children.Add(label);

                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = GridLength.Auto;

                this.propertyGrid.RowDefinitions.Add(rowDefinition);

                Grid.SetRow(grid, this.propertyGrid.RowDefinitions.Count - 1);

                this.propertyGrid.Children.Add(grid);
            }
        }

        /// <summary>
        /// Create binding
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="controlType"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private Binding CreateBinding(PropertyInfo propertyInfo, ControlType controlType, object source)
        {
            Binding binding = new Binding(propertyInfo.Name);

            binding.Source = source;

            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

             binding.Mode = BindingMode.TwoWay;

           // binding.Mode = controlType == ControlType.Label || controlType == ControlType.Button ? BindingMode.OneWay

            if (!propertyInfo.CanWrite || controlType == ControlType.Label)
            {
                binding.Mode = BindingMode.OneWay;
            }

            if (controlType == ControlType.TextBox && binding.Mode == BindingMode.TwoWay)
            {
                switch (propertyInfo.PropertyType.Name)
                {
                    case "Decimal":
                        binding.Converter = new DecimalToStringConverter();
                        break;

                    case "Double":
                        binding.Converter = new DoubleToStringConverter();
                        break;
                }
            }
            return binding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.propertyGrid = new Grid();
            this.Content = this.propertyGrid;
            PropertyInfo[] pvmInfo = typeof(LaptopViewModel).GetProperties();

            this.commandPanel = new StackPanel();
            this.commandPanel.Orientation = Orientation.Horizontal;
            this.commandPanel.HorizontalAlignment = HorizontalAlignment.Right;
            this.commandPanel.Margin = new Thickness(0, 5, 10, 10);

            var sortedPvmInfo =
                from p in pvmInfo
                where DisplayUtil.HasControl(p)
                orderby DisplayUtil.GetControlSequence(p)
                select p;

            foreach (PropertyInfo p in sortedPvmInfo)
            {
                
                object object1 = ReflectionUtil.GetAttributePropertyValue(p, typeof(EntityControlAttribute), p.Name.ToString());

                this.BuildLabeledControl(p);
                
            }

            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            this.propertyGrid.RowDefinitions.Add(rowDefinition);
            Grid.SetRow(this.commandPanel, this.propertyGrid.RowDefinitions.Count);
            this.propertyGrid.Children.Add(this.commandPanel);


        }
    }
}
