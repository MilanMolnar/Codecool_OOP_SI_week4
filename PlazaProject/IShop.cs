using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
    interface IShop
    {
        string Name { get;}
        string Owner { get;}
        bool IsOpen { get; set; }
        List<Product> GetProducts();
        void Open();
        void Close();
        Product FindByName(string name);
        float GetPrice(long barcode);
        bool HasProduct(long barcode);
        void AddNewProduct(Product product, int qunatity, float price);
        void AddProduct(long barcode, int quantity);
        Product BuyProduct(long barcode);
        List<Product> BuyProducts(long barcode, int qunatity);

    }
}
