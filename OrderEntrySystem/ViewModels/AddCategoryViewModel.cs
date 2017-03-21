using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    public class AddCategoryViewModel : EntityViewModel<Laptop>
    {
        public AddCategoryViewModel(Laptop product)
            : base("Add category", product)
        {
        }

        public Category Category { get; set; }

        public IEnumerable<Category> Categories
        {
            get
            {
                return (RepositoryManager.GetRepository(typeof(Category)) as Repository<Category>).GetEntities();
            }
        }

        protected override bool Save()
        {
            bool result = true;

            if (this.Entity.IsValid)
            {
                LaptopCategory pc = new LaptopCategory();

                pc.Category = this.Category;
                pc.Laptop = this.Entity;

                (RepositoryManager.GetRepository(typeof(LaptopCategory)) as Repository<LaptopCategory>).AddEntity(pc);

                RepositoryManager.GetRepository(typeof(LaptopCategory)).SaveToDatabase();
            }
            else
            {
                result = false;
                MessageBox.Show("One or more fields are invalid. The product category could not be saved.");
            }

            return result;
        }
    }
}