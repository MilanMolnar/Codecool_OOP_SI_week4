using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
   public abstract class Product
    {
        public long Barcode { get; protected set; }
        public string Name { get; protected set; }
        public string Manufacturer { get; protected set; }

        protected Product(long Barcode, string Name, string Manufacturer)
        {
            this.Barcode = Barcode;
            this.Name = Name;
            this.Manufacturer = Manufacturer;
        }
    }
}
