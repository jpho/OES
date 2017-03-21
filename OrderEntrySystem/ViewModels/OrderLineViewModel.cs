using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class OrderLineViewModel : EntityViewModel<OrderLine>, IDataErrorInfo
    {
        /// <summary>
        /// Initializes a new instance of the OrderLineViewModel class.
        /// </summary>
        /// <param name="line">The order line to be shown.</param>
        public OrderLineViewModel(OrderLine line)
            : base("New order line", line)
        {
        }

        public string Error
        {
            get
            {
                return this.Entity.Error;
            }
        }

        public Laptop Product
        {
            get
            {
                return this.Entity.Laptop;
            }

            set
            {
                this.Entity.Laptop = value;
                this.OnPropertyChanged("Product");
                this.Entity.ProductAmount = value.Price;
                this.OnPropertyChanged("ProductTotal");
                this.Entity.CalculateTax();
                this.OnPropertyChanged("TaxTotal");
            }
        }

        public IEnumerable<Laptop> Products
        {
            get
            {
                return (RepositoryManager.GetRepository(typeof(Laptop)) as Repository<Laptop>).GetEntities();
            }
        }

        public int Quantity
        {
            get
            {
                return this.Entity.Quantity;
            }

            set
            {
                this.Entity.Quantity = value;
                this.OnPropertyChanged("Quantity");
                this.OnPropertyChanged("ProductTotal");
                this.Entity.CalculateTax();
                this.OnPropertyChanged("TaxTotal");
            }
        }

        public decimal ProductTotal
        {
            get
            {
                return this.Entity.ExtendedProductAmount;
            }
        }

        public decimal TaxTotal
        {
            get
            {
                return this.Entity.ExtendedTax;
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