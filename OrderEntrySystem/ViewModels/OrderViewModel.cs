using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class OrderViewModel : EntityViewModel<Order>
    {
        private MultiEntityViewModel<OrderLine, OrderLineViewModel, OrderLineView> filteredLineViewModel;

        /// <summary>
        /// Initializes a new instance of the OrderViewModel class.
        /// </summary>
        /// <param name="order">The order to be shown.</param>
        public OrderViewModel(Order order)
            : base("New order", order)
        {
            this.filteredLineViewModel = new MultiEntityViewModel<OrderLine, OrderLineViewModel, OrderLineView>();
            this.filteredLineViewModel.AllEntities = this.FilteredLines;
        }

        public decimal ProductTotal
        {
            get
            {
                return this.Entity.ProductTotal;
            }
        }

        public decimal TaxTotal
        {
            get
            {
                return this.Entity.TaxTotal;
            }
        }

        public decimal Total
        {
            get
            {
                return this.Entity.Total;
            }
        }

        public ObservableCollection<OrderLineViewModel> FilteredLines
        {
            get
            {
                List<OrderLineViewModel> lines = null;

                if (this.Entity.Lines != null)
                {
                    lines =
                        (from l in this.Entity.Lines
                         select new OrderLineViewModel(l)).ToList();
                }

                this.FilteredLineViewModel.AddPropertyChangedEvent(lines);

                return new ObservableCollection<OrderLineViewModel>(lines);
            }
        }

        public MultiEntityViewModel<OrderLine, OrderLineViewModel, OrderLineView> FilteredLineViewModel
        {
            get
            {
                return this.filteredLineViewModel;
            }
        }

        public OrderStatus Status
        {
            get
            {
                return this.Entity.Status;
            }

            set
            {
                this.Entity.Status = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return this.Entity.Customer;
            }

            set
            {
                this.Entity.Customer = value;
            }
        }

        public decimal ShippingAmount
        {
            get
            {
                return this.Entity.ShippingAmount;
            }

            set
            {
                this.Entity.ShippingAmount = value;
                this.OnPropertyChanged("ShippingAmount");
                this.OnPropertyChanged("Total");
            }
        }

        public IEnumerable<OrderStatus> OrderStatuses
        {
            get
            {
                return Enum.GetValues(typeof(OrderStatus)) as IEnumerable<OrderStatus>;
            }
        }

        public IEnumerable<Laptop> Products
        {
            get
            {
                return (RepositoryManager.GetRepository(typeof(Laptop)) as Repository<Laptop>).GetEntities();
            }
        }

        public void UpdateOrderTotals()
        {
            this.OnPropertyChanged("ProductTotal");
            this.OnPropertyChanged("TaxTotal");
            this.OnPropertyChanged("Total");
            this.OnPropertyChanged("Status");
        }
    }
}