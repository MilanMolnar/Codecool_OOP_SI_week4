using System.Collections.Generic;

namespace InvProj

{
    public abstract class Store : IStorageCapable
    {
        

        protected abstract void StoreProduct(Product product);

        protected Product CreateProduct(string type, string name, int price, int size)
        {
            if (type.Equals("CD"))
            {
                CdProduct cDProduct = new CdProduct(name, price, size);
                return cDProduct;
            }
            else
            {
                BookProduct bookProduct = new BookProduct(name, price, size);
                return bookProduct;
            }
        }
        public List<Product> LoadProducts()
        {
            return null;
        }
        
        public void store(Product product)
        {
            StoreProduct(product);
        }
        public void StoreCdProduct(string name, int price, int tracks)
        {
            Product cd = CreateProduct("CD", name, price, tracks);
            store(cd);
        }
        public void StoreBookProduct(string name, int price, int pages)
        {
            Product book = CreateProduct("Book", name, price, pages);
            store(book);

        }
        public abstract void SaveToXml(List<Product> products);

        public abstract void SaveToCsv(List<Product> products);
        public abstract List<Product> GetAllProduct();
    }
}