using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
    interface IPlaza
    {
        bool IsOpen();
        List<IShop> GetShops();
        
        void AddShop(IShop shop);
        void RemoveShop(IShop shop);
        IShop FindShopByName(string name);
        
        void Open();
        void Close();
        
    }
}
