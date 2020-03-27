using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace PlazaProject
{
    public class ShopImpl : IShop
    {

        public string Name { get; }

        public string Owner { get; }
        public bool IsOpen { get; set; }


        private Dictionary<long, ShopImpl.ShopEntryImpl> DictProducts;

        public ShopImpl(string Name, string Owner)
        {
            this.Name = Name;
            this.Owner = Owner;
            IsOpen = true;

            DictProducts = new Dictionary<long, ShopImpl.ShopEntryImpl>();

        }

        public void Open()
        {
            IsOpen = true;
        }
        public void Close()
        {
            IsOpen = false;
        }
        public List<Product> GetProducts()
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            List<Product> allProduct = new List<Product>();
            for (int i = 0; i < DictProducts.Count; i++)
            {
                allProduct.Add(DictProducts.ElementAt(i).Value.Product);
            }
            return allProduct;


        }
        public Product FindByName(string Name)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count >= 1)
            {
                for (int i = 0; i < DictProducts.Count; i++)
                {
                    if (DictProducts.ElementAt(i).Value.Product.Name == Name)
                    {

                        return DictProducts.ElementAt(i).Value.Product;
                    }
                }
                throw new NoSuchProductException("There is no such product in the shop");
            }
            else
                throw new NoSuchProductException("The shop is empty sorry");

        }
        public float GetPrice(long barcode)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count >= 1)
            {
                for (int i = 0; i < DictProducts.Count; i++)
                {
                    if (DictProducts.ElementAt(i).Key == barcode)
                    {
                        return DictProducts.ElementAt(i).Value.Price;
                    }
                }
                throw new NoSuchProductException("There is no such product in the shop");
            }
            else
                throw new NoSuchProductException("The shop is empty sorry");
        }
        public bool HasProduct(long barcode)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count >= 1)
            {
                for (int i = 0; i < DictProducts.Count; i++)
                {
                    if (DictProducts.ElementAt(i).Key == barcode)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void AddNewProduct(Product product, int quantity, float price)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count >= 1)
            {
                foreach (long element in DictProducts.Keys)
                {
                    if (element == product.Barcode)
                        throw new ProductAlreadyExistException("This product is already in the shop");
                }
                ShopEntryImpl shopEntry = new ShopEntryImpl(product, quantity, price);
                DictProducts[product.Barcode] = shopEntry;
            }
            else
            {
                ShopEntryImpl shopEntry = new ShopEntryImpl(product, quantity, price);
                DictProducts[product.Barcode] = shopEntry;
            }



        }
        public void AddProduct(long barcode, int quantity)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (HasProduct(barcode) == true)
            {

                DictProducts[barcode].Quantity += quantity;
            }
            else
            {
                throw new NoSuchProductException("There is no such product sorry");
            }
        }
        public Product BuyProduct(long barcode)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (HasProduct(barcode) == true && DictProducts[barcode].Quantity == 0)
            {
                throw new OutOfStockException("This product run out of the stock");

            }
            else if(HasProduct(barcode) == true)
            {
                return DictProducts[barcode].Product;
            }
            else
            {
                throw new NoSuchProductException("There is no such product sorry");
            }

           
        }
        public List<Product> BuyProducts(long barcode, int quantity)
        {
            List<Product> BuyedProducts = new List<Product>();
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (HasProduct(barcode) == true && (DictProducts[barcode].Quantity == 0 || DictProducts[barcode].Quantity < quantity))
            {
                throw new OutOfStockException("This product run out of the stock");
            }
            else if (HasProduct(barcode) == true)
            {
                for (int index = 1; index <= quantity; index++)
                {
                    BuyedProducts.Add(DictProducts[barcode].Product);
                }
                return BuyedProducts;
            }
            else
            {
                throw new NoSuchProductException("There is no such product in this shop");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name : {this.Name}, Owner : {this.Owner}");
            return sb.ToString();
        }



        class ShopEntryImpl
        {

            public Product Product { get; set; }

            public int Quantity { get; set; }

            public float Price { get; set; }
            public ShopEntryImpl(Product Product, int Quantity, float Price)
            {
                this.Product = Product;
                this.Quantity = Quantity;
                this.Price = Price;

            }

            public void IncreaseQuantity(int amount)
            {
                Quantity += amount;
            }
            public void DecraseQuantity(int amount)
            {
                Quantity -= amount;
            }
        }
    }
    
}
