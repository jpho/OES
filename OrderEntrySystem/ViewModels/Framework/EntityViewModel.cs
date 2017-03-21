using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OrderEntryDataAccess;
using OrderEntryEngine;
using System.Windows.Input;

namespace OrderEntrySystem
{
    public abstract class EntityViewModel<T> : WorkspaceViewModel
        where T : class, IEntity
    {
        private bool isSelected;

        public EntityViewModel(string displayName, T entity)
            : base(displayName)
        {
            this.Entity = entity;
        }

        public T Entity { get; set; }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                this.isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }

        [EntityControl(ControlType.Button, 999)]
        public ICommand Ok
        {
            get
            {
                return new DelegateCommand(p => this.OkExecute());
            }
        }

        [EntityControl(ControlType.Button, 998)]
        public ICommand Cancel
        {
            get
            {
                return new DelegateCommand(p => this.CancelExecute());
            }
        }

        /// <summary>
        /// Creates the commands needed for the entity view model.
        /// </summary>
        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("OK", new DelegateCommand(p => this.OkExecute()), true, false));
            this.Commands.Add(new CommandViewModel("Cancel", new DelegateCommand(p => this.CancelExecute()), false, true));
        }

        protected virtual bool Save()
        {
            bool result = true;

            if (this.Entity.IsValid)
            {
                Repository<T> repository = RepositoryManager.GetRepository(typeof(T)) as Repository<T>;
                repository.AddEntity(this.Entity);
                repository.SaveToDatabase();
            }
            else
            {
                result = false;
                MessageBox.Show("One or more fields are invalid. The " + typeof(T).ToString() + " could not be saved.");
            }

            return result;
        }

        private void CancelExecute()
        {
            this.CloseAction(false);
        }

        private void OkExecute()
        {
            if (this.Save())
            {
                this.CloseAction(true);
            }
        }
    }
}