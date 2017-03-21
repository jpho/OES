using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class LaptopViewModel : EntityViewModel<Laptop>, IDataErrorInfo
    {
        private MultiEntityViewModel<Category, CategoryViewModel, CategoryView> filteredCategoryViewModel;

        public LaptopViewModel(Laptop laptop)
            : base("New laptop", laptop)
        {
            this.filteredCategoryViewModel = new MultiEntityViewModel<Category, CategoryViewModel, CategoryView>();
            this.filteredCategoryViewModel.AllEntities = this.FilteredCategories;
        }

        public string Error
        {
            get
            {
                return this.Entity.Error;
            }
        }

        public MultiEntityViewModel<Category, CategoryViewModel, CategoryView> FilteredCategoryViewModel
        {
            get
            {
                return this.filteredCategoryViewModel;
            }
        }

        public ObservableCollection<CategoryViewModel> FilteredCategories
        {
            get
            {
                List<CategoryViewModel> categories = null;

                if (this.Entity.LaptopCategories != null)
                {
                    categories =
                        (from c in this.Entity.LaptopCategories
                        select new CategoryViewModel(c.Category)).ToList();
                }

                this.FilteredCategoryViewModel.AddPropertyChangedEvent(categories);

                return new ObservableCollection<CategoryViewModel>(categories);
            }
        }

        [EntityControlAttribute(ControlType.TextBox, "Name: ", 1), EntityColumnAttribute("Name", 1,25)]
        public string Name
        {
            get
            {
                return this.Entity.Name;
            }

            set
            {
                this.Entity.Name = value;
                this.OnPropertyChanged("Name");
            }
        }

        [EntityControlAttribute(ControlType.ComboBox, "Condition: ", 2),
            EntityColumnAttribute("Condition", 1, 25)]
        public OrderEntryEngine.Condition Condition
        {
            get
            {
                return this.Entity.Condition;
            }

            set
            {
                this.Entity.Condition = value;
                this.OnPropertyChanged("Condition");
            }
        }

        public ICollection<OrderEntryEngine.Condition> Conditions
        {
            get
            {
                return Enum.GetValues(typeof(OrderEntryEngine.Condition)) as ICollection<OrderEntryEngine.Condition>;
            }
        }

        [EntityControlAttribute(ControlType.TextBox, "Description: ", 3),
            EntityColumnAttribute("Description", 1, 25)]
        public string Description
        {
            get
            {
                return this.Entity.Description;
            }

            set
            {
                this.Entity.Description = value;
                this.OnPropertyChanged("Description");
            }
        }

        [EntityControlAttribute(ControlType.CheckBox, "Refurbished: ", 4)]
            [EntityColumnAttribute("Refurbished", 1, 25)]
        public bool IsRefurbished
        {
            get
            {
                return this.Entity.IsRefurbished;
            }

            set
            {
                this.Entity.IsRefurbished = value;
                this.OnPropertyChanged("Refurbished");
            }
        }

        [EntityControl(ControlType.Label, "Extended Price: ", 5)]
        [EntityColumnAttribute("Extended Price", 1, 25)]
        public decimal ExtendedPrice
        {
            get
            {
                return this.Entity.ExtendedPrice;
            }
        }

        [EntityControlAttribute(ControlType.TextBox, "Price: ", 6)]
        [EntityColumnAttribute("Price", 1, 25)]
        public decimal Price
        {
            get
            {
                return this.Entity.Price;
            }

            set
            {
                this.Entity.Price = value;
                this.OnPropertyChanged("Price");
            }
        }

        [EntityControlAttribute(ControlType.TextBox, "RAM: ", 7)]
        [EntityColumnAttribute("RAM", 1, 25)]
        public double Ram
        {
            get
            {
                return this.Entity.Ram;
            }

            set
            {
                this.Entity.Ram = value;
                this.OnPropertyChanged("RAM");
            }
        }

        [EntityControlAttribute(ControlType.TextBox, "CPU Speed: ", 8)]
        [EntityColumnAttribute("CPU Speed", 1, 25)]
        public double CpuSpeed
        {
            get
            {
                return this.Entity.CpuSpeed;
            }

            set
            {
                this.Entity.CpuSpeed = value;
                this.OnPropertyChanged("CPU Speed");
            }
        }

        [EntityControlAttribute(ControlType.TextBox, "Memory: ", 9)]
        [EntityColumnAttribute("Memory", 1, 25)]
        public double Memory
        {
            get
            {
                return this.Entity.Memory;
            }

            set
            {
                this.Entity.Memory = value;
                this.OnPropertyChanged("Memory");
            }
        }

        [EntityControlAttribute(ControlType.ComboBox, "Location: ", 10)]
        [EntityColumnAttribute("Location", 1, 25)]
        public Location Location
        {
            get
            {
                return this.Entity.Location;
            }

            set
            {
                this.Entity.Location = value;
                this.OnPropertyChanged("Location");
            }
        }

        [EntityControlAttribute(ControlType.TextBox, "Quantity: ", 11)]
        [EntityColumnAttribute("Quantity", 1, 25)]
        public int Quantity
        {
            get
            {
                return this.Entity.Quantity;
            }

            set
            {
                this.Entity.Quantity = value;
            }
        }

        

        public ICollection<Location> Locations
        {
            get
            {
                return (RepositoryManager.GetRepository(typeof(Location)) as Repository<Location>).GetEntities();
            }
        }

        public IEnumerable<Category> Categories
        {
            get
            {
                return (RepositoryManager.GetRepository(typeof(Category)) as Repository<Category>).GetEntities() as IEnumerable<Category>;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                return this.Entity[propertyName];
            }
        }
    }
}