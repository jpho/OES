using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    public class LaptopCategory : IEntity, ILookupEntity
    {
        public int Id { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsArchived { get; set; }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}