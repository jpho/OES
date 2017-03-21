using System.ComponentModel;
using System.Windows;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class LocationViewModel : EntityViewModel<Location>, IDataErrorInfo
    {
        public LocationViewModel(Location location)
            : base("New location", location)
        {
        }

        public string Error
        {
            get
            {
                return this.Entity.Error;
            }
        }

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

        [EntityControl(ControlType.TextBox, 666)]
        public string City
        {
            get
            {
                return this.Entity.City;
            }

            set
            {
                this.Entity.City = value;
                this.OnPropertyChanged("City");
            }
        }

        public string State
        {
            get
            {
                return this.Entity.State;
            }

            set
            {
                this.Entity.State = value;
                this.OnPropertyChanged("State");
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