using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
        private ObservableCollection<UserControl> views;

        public MainWindowViewModel()
            : base("Order Entry System - LastName")
        {
            RepositoryManager.InitializeRepository();
        }

        public ObservableCollection<UserControl> Views
        {
            get
            {
                if (this.views == null)
                {
                    this.views = new ObservableCollection<UserControl>();
                }

                return this.views;
            }
        }

        /// <summary>
        /// Creates the commands required by the view model.
        /// </summary>
        protected override void CreateCommands()
        {
            this.AddMultiEntityCommand("View all products");
            this.AddMultiEntityCommand("View all customers");
            this.AddMultiEntityCommand("View all locations");
            this.AddMultiEntityCommand("View all categories");
            this.AddMultiEntityCommand("View all orders");
        }

        private void ActivateViewModel(UserControl view)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Views);

            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(view);
            }
        }

        private void AddMultiEntityCommand(string displayName)
        {
            this.Commands.Add(new CommandViewModel(displayName, new DelegateCommand(p => this.ShowAllEntities(displayName)), "Objects", false, false));
        }

        /// <summary>
        /// A handler which responds to a request to close a workspace.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments for the event.</param>
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel viewModel = sender as WorkspaceViewModel;

            UserControl view = this.Views.FirstOrDefault(v => v.DataContext == viewModel) as UserControl;

            this.Views.Remove(view);
        }

        private void ShowAllEntities(string displayName)
        {
            UserControl view = this.Views.FirstOrDefault(v => (v.DataContext as WorkspaceViewModel).DisplayName == displayName);

            WorkspaceViewModel viewModel = null;

            if (view == null)
            {
                switch (displayName)
                {
                    case "View all products":
                        view = new MultiProductView();
                        viewModel = new MultiEntityViewModel<Laptop, LaptopViewModel, EntityView>();
                        break;
                    case "View all customers":
                        view = new MultiCustomerView();
                        viewModel = new MultiEntityViewModel<Customer, CustomerViewModel, CustomerView>();
                        break;
                    case "View all locations":
                        view = new MultiLocationView();
                        viewModel = new MultiEntityViewModel<Location, LocationViewModel, LocationView>();
                        break;
                    case "View all categories":
                        view = new MultiCategoryView();
                        viewModel = new MultiEntityViewModel<Category, CategoryViewModel, CategoryView>();
                        break;
                    case "View all orders":
                        view = new MultiOrderView();
                        viewModel = new MultiEntityViewModel<Order, OrderViewModel, OrderView>();
                        break;
                }

                viewModel.RequestClose += this.OnWorkspaceRequestClose;

                view.DataContext = viewModel;

                this.Views.Add(view);
            }

            this.ActivateViewModel(view);
        }
    }
}