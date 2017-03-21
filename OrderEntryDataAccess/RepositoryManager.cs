using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntryEngine;
using OrderEntryDataAccess;

namespace OrderEntryDataAccess
{
    public static class RepositoryManager
    {
        public static OrderEntryContext Context { get; set; }

        public static Dictionary<Type, IRepository> Repositories { get; set; }

        public static IRepository GetRepository(Type type)
        {
            IRepository value = null;

            if (Repositories.TryGetValue(type, out value))
            {
                return value;
            }
            else
            {
                throw new Exception("Invalid dictionary specified.");
            }
        }

        public static ILookupRepository GetLookupRepository(Type type)
        {
            IRepository value = RepositoryManager.GetRepository(type);

            if (value is ILookupRepository)
            {
                return value as ILookupRepository;
            }
            else
            {
                throw new Exception("Specified type does not implement ILookupRepository.");
            }
        }

        public static void InitializeRepository()
        {
            RepositoryManager.Context = new OrderEntryContext();

            RepositoryManager.Repositories = new Dictionary<Type, IRepository>()
            {
            { typeof(Category), new LookupRepository<Category>(Context.Categories) },
            { typeof(Customer), new LookupRepository<Customer>(Context.Customers) },
            { typeof(GraphicsCard), new LookupRepository<GraphicsCard>(Context.GraphicsCards) },
            { typeof(Location), new LookupRepository<Location>(Context.Locations) },
            { typeof(OrderLine), new Repository<OrderLine>(Context.Lines) },
            { typeof(Order), new Repository<Order>(Context.Orders) },
            { typeof(Laptop), new LookupRepository<Laptop>(Context.Products) },
            { typeof(LaptopCategory), new LookupRepository<LaptopCategory>(Context.ProductCategories) }
            };
        }
    }
}