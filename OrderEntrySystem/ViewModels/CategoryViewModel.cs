using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class CategoryViewModel : EntityViewModel<Category>, IDataErrorInfo
    {
        public CategoryViewModel(Category category)
            : base("New product category", category)
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

        public string this[string propertyName]
        {
            get
            {
                return this.Entity[propertyName];
            }
        }
    }
}