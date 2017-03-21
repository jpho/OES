using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class CustomerViewModel : EntityViewModel<Customer>, IDataErrorInfo
    {
        private MultiEntityViewModel<Order, OrderViewModel, OrderView> filteredOrderViewModel;

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        /// <param name="customer">The customer to be shown.</param>
        public CustomerViewModel(Customer customer)
            : base("New customer", customer)
        {
            this.filteredOrderViewModel = new MultiEntityViewModel<Order, OrderViewModel, OrderView>();
            this.filteredOrderViewModel.AllEntities = this.FilteredOrders;
        }

        public string Error
        {
            get
            {
                return this.Entity.Error;
            }
        }

        public string FirstName
        {
            get
            {
                return this.Entity.FirstName;
            }

            set
            {
                this.Entity.FirstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return this.Entity.LastName;
            }

            set
            {
                this.Entity.LastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        public string Phone
        {
            get
            {
                return this.Entity.Phone;
            }

            set
            {
                this.Entity.Phone = value;
                this.OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get
            {
                return this.Entity.Email;
            }

            set
            {
                this.Entity.Email = value;
                this.OnPropertyChanged("Email");
            }
        }

        public ObservableCollection<OrderViewModel> FilteredOrders
        {
            get
            {
                var orders =
                    (from o in this.Entity.Orders
                    select new OrderViewModel(o)).ToList();

                this.FilteredOrderViewModel.AddPropertyChangedEvent(orders);

                return new ObservableCollection<OrderViewModel>(orders);
            }
        }

        public MultiEntityViewModel<Order, OrderViewModel, OrderView> FilteredOrderViewModel
        {
            get
            {
                return this.filteredOrderViewModel;
            }
        }

        public string Address
        {
            get
            {
                return this.Entity.Address;
            }

            set
            {
                this.Entity.Address = value;
                this.OnPropertyChanged("Address");
            }
        }

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