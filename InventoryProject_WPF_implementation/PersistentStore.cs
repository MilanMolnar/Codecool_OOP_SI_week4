using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace InvProj
{
    public class PersistentStore : Store
    {
        private List<Product> products { get; set; } = new List<Product>();
        protected override void StoreProduct(Product product)
        {
            products.Add(product);
        }
        public override List<Product> GetAllProduct()
        {
            return products;
        }

        public override void SaveToXml(List<Product> products)
        {
            XElement root = new XElement("products");
            foreach (var product in products)
            {
                root.Add(
                    new XElement("product", 
                        new XElement("name", product.Name), 
                        new XElement("price", product.Price)));
            }
            root.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ProductXml.xml"));
        }

        public void ClearProducts()
        {
            products.Clear();
        }

        public override void SaveToCsv(List<Product> products)
        {
            using (var w = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ProductCsv.csv")))
            for (int i = 0; i < products.Count; i++)
            {
                var line = string.Format($"[{i}] Product name: {products[i].Name} price: {products[i].Price}");
                w.WriteLine(line);
                w.Flush();
            }
        }
    }
}