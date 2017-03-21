
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    public enum Condition
    {
        [EntityDescription("Poor is bad")]
        Poor,
        [EntityDescription("Not bad")]
        Average,
        [EntityDescription("Double Plus Good")]
        Excellent
    }
}