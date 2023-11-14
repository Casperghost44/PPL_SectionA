using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPL_SectionA.InventorySearchParallel
{
    public class InventoryItem
    {
        public string Barcode { get; set; }
        public int Type { get; set; }

        public override string ToString()
        {
            return $"Barcode: {Barcode} for type {Type}";
        }
    }
}
