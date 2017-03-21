﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    public class GraphicsCard : ILookupEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsArchived { get; set; }

        public bool IsValid
        {
            get
            {
                return true;
            }
            
        }

       
    }
}
