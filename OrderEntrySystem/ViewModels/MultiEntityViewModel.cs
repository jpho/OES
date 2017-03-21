using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class MultiEntityViewModel<TEntity, TViewModel, TView> : WorkspaceViewModel
        where TEntity : class, IEntity
        where TViewModel : EntityViewModel<TEntity>
        where TView : UserControl
    {
        public MultiEntityViewModel()
            : base("All " + typeof(TEntity).ToString())
        {
            this.CreateAllViewModels();

            this.Repository.EntityAdded += this.OnEntityAdded;
            this.Repository.EntityRemoved += this.OnEntityRemoved;
        }

        public ObservableCollection<TViewModel> AllEntities { get; set; }

        public int NumberOfItemsSelected
        {
            get
            {
                return this.AllEntities.Count(vm => vm.IsSelected);
            }
        }

        public Repository<TEntity> Repository
        {
            get
            {
                return RepositoryManager.GetRepository(typeof(TEntity)) as Repository<TEntity>;
            }
        }

        public void AddPropertyChangedEvent(List<TViewModel> entities)
        {
            entities.ForEach(pvm => pvm.PropertyChanged += this.OnEntityViewModelPropertyChanged);
        }

        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("New...", new DelegateCommand(param => this.CreateNewEntityExecute())));
            this.Commands.Add(new CommandViewModel("Edit...", new DelegateCommand(param => this.EditEntityExecute(), param => this.NumberOfItemsSelected == 1)));
            this.Commands.Add(new CommandViewModel("Delete", new DelegateCommand(param => this.DeleteEntityExecute(), param => this.NumberOfItemsSelected == 1)));
        }

        private void CreateAllViewModels()
        {
            List<TViewModel> entities =
                (from e in this.Repository.GetEntities()
                 select Activator.CreateInstance(typeof(TViewModel), e) as TViewModel).ToList();

            this.AddPropertyChangedEvent(entities);

            this.AllEntities = new ObservableCollection<TViewModel>(entities);
        }

        private void CreateNewEntityExecute()
        {
            IEntity entity = Activator.CreateInstance(typeof(TEntity)) as IEntity;

            TViewModel viewModel = Activator.CreateInstance(typeof(TViewModel), entity) as TViewModel;

            this.ShowEntity(viewModel as TViewModel);
        }

        private void DeleteEntityExecute()
        {
            EntityViewModel<TEntity> viewModel = this.GetOnlySelectedViewModel();

            if (viewModel != null)
            {
                if (MessageBox.Show("Do you really want to delete the selected Item?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.Repository.RemoveEntity(viewModel.Entity);
                    this.Repository.SaveToDatabase();
                }
            }
            else
            {
                MessageBox.Show("Please select only one Item");
            }
        }

        private void EditEntityExecute()
        {
            TViewModel viewModel = this.GetOnlySelectedViewModel();

            if (viewModel != null)
            {
                this.ShowEntity(viewModel);

                this.Repository.SaveToDatabase();
            }
            else
            {
                MessageBox.Show("Please select only one item.");
            }
        }

        private TViewModel GetOnlySelectedViewModel()
        {
            TViewModel result;

            try
            {
                result = this.AllEntities.Single(vm => vm.IsSelected);
            }
            catch
            {
                result = null;
            }

            return result;
        }

        private void OnEntityAdded(object sender, EntityEventArgs<TEntity> e)
        {
            TViewModel vm = Activator.CreateInstance(typeof(TViewModel), e.Entity) as TViewModel;

            vm.PropertyChanged += this.OnEntityViewModelPropertyChanged;

            this.AllEntities.Add(vm);
        }

        private void OnEntityRemoved(object sender, EntityEventArgs<TEntity> e)
        {
            TViewModel viewModel = this.GetOnlySelectedViewModel();

            if (viewModel != null)
            {
                if (viewModel.Entity == e.Entity)
                {
                    this.AllEntities.Remove(viewModel);
                }
            }
        }

        /// <summary>
        /// A handler which responds when a entity view model's property changes.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnEntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string isSelected = "IsSelected";

            if (e.PropertyName == isSelected)
            {
                this.OnPropertyChanged("NumberOfItemsSelected");
            }
        }

        /// <summary>
        /// Creates a new window to edit a car.
        /// </summary>
        /// <param name="viewModel">The view model for the car to be edited.</param>
        private void ShowEntity(TViewModel viewModel)
        {
            WorkspaceWindow window = new WorkspaceWindow();
            window.Width = 400;
            viewModel.CloseAction = b => window.DialogResult = b;
            window.Title = viewModel.DisplayName;

            TView view = Activator.CreateInstance(typeof(TView)) as TView;

            view.DataContext = viewModel;

            window.Content = view;

            window.ShowDialog();
        }
    }
}
