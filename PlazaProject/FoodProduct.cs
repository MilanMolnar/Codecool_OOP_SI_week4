using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
    class FoodProduct : Product
    {
        public int Calories { get; }
        public DateTime bestbefore;
        public FoodProduct(long Barcode,string Name,string Manufacturer,int Calories,DateTime Bestbefore) : base(Barcode,Name,Manufacturer)
        {
            this.Calories = Calories;
            bestbefore = Bestbefore;
        }
        public bool IsStillConsumable()
        {
            return true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Barcode : {this.Barcode}, Name : {this.Name}, Manufacturer : {this.Manufacturer}, Calories : {this.Calories}, Bestbefore : {this.bestbefore}");
            return sb.ToString();
        }

    }
}
