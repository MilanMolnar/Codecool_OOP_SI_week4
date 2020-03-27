using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
    class CmdProgram
    {
        private List<Product> cart = new List<Product>();
        private List<float> prices = new List<float>();

        public CmdProgram(string[] args)
        {
            
        }

        private void ListingMenuPoints(string[] menu)
        {
            foreach(string element in menu)
            {
                Console.WriteLine(element);
            }
        }
        public void run()
        {
            string[] createPlazaimplMenu = { "1) to create a new plaza.",
                                             "2) to exit."};

            string[] plazaImplMenu = { "1) to list all shops.",
                                       "2) to add a new shop.",
                                       "3) to remove an existing shop.",
                                       "4) enter a shop by name.",
                                       "5) to open the plaza.",
                                       "6) to close the plaza.",
                                       "7) to check if the plaza is open or not.",
                                       "8) leave the plaza"};

            string[] shopMenu = {   "1) to list available products.",
                                    "2) to find products by name.",
                                    "3) to display the shop's owner.",
                                    "4) to open the shop.",
                                    "5) to close the shop.",
                                    "6) to add new product to the shop.",
                                    "7) to add existing products to the shop.",
                                    "8) to buy a product by barcode.",
                                    "9) check price by barcode.",
                                    "10) go back to plaza."};

            while (true)
            {
                try
                {
                    Console.WriteLine("There are no plaza created yet! Press");
                    ListingMenuPoints(createPlazaimplMenu);
                    string answ = Console.ReadLine();
                    
                    if(answ == "1")
                    {
                        Console.Write("Give me the plaza name: ");
                        PlazaImpl plaza = new PlazaImpl(Console.ReadLine());
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine($"Welcome to the {plaza.Name}! Press ");
                                ListingMenuPoints(plazaImplMenu);
                                string plazansw = Console.ReadLine();
                                
                                if(plazansw == "1")
                                {
                                    foreach(IShop element in plaza.GetShops())
                                    {
                                        Console.WriteLine(element.ToString());
                                    }
                                }
                                else if(plazansw == "2")
                                {
                                    string[] shopquestions = { "Give me the shop Name: ",
                                                                "Give me the shop Owner: "};
                                    List<string> shopanswer = new List<string>();
                                    foreach(string element in shopquestions)
                                    {
                                        Console.Write(element);
                                        shopanswer.Add(Console.ReadLine());
                                    }
                                    plaza.AddShop(new ShopImpl(shopanswer[0], shopanswer[1]));
                                }
                                else if(plazansw == "3")
                                {
                                    Console.Write("Give me the shop Name what you want to remove: ");
                                    string removingPlaza = Console.ReadLine();
                                    if(plaza.GetShops().Count == 0)
                                    {
                                        Console.WriteLine("Create a shop first please");
                                    }
                                    foreach(IShop element in plaza.GetShops())
                                    {
                                        if(element.Name == removingPlaza)
                                        {
                                            plaza.RemoveShop(element);
                                            break;
                                        }
                                    }
                                }
                                else if(plazansw == "4")
                                {
                                    Console.Write("Give me the soph you want to enter! : ");
                                    string entryshop = Console.ReadLine();
                                    if (plaza.GetShops().Count == 0)
                                    {
                                        Console.WriteLine("Create a shop first please");
                                        return;
                                    }
                                    foreach (IShop element in plaza.GetShops())
                                    {
                                        if (element.Name == entryshop)
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine($"Welcome to the {element.Name} Shop!Press: ");
                                                    ListingMenuPoints(shopMenu);
                                                    string shopansw = Console.ReadLine();
                                                    if (shopansw == "1")
                                                    {
                                                        if (element.GetProducts().Count == 0)
                                                        {
                                                            Console.WriteLine("Create a product first please");

                                                        }
                                                        else
                                                        {
                                                            foreach (Product product in element.GetProducts())
                                                            {
                                                                Console.WriteLine(product.ToString());
                                                            }
                                                        }
                                                    }
                                                    else if (shopansw == "2")
                                                    {
                                                        Console.Write("Give me the product name what you: ");
                                                        Console.WriteLine(element.FindByName(Console.ReadLine()).ToString());
                                                    }
                                                    else if (shopansw == "3")
                                                    {

                                                        Console.WriteLine($"The shop's owner is {element.Owner}");
                                                    }
                                                    else if (shopansw == "4")
                                                    {
                                                        element.Open();
                                                        Console.WriteLine("The shop has been opened");
                                                    }
                                                    else if (shopansw == "5")
                                                    {
                                                        element.Close();
                                                        Console.WriteLine("The shop has been closed");
                                                    }
                                                    else if (shopansw == "6")
                                                    {
                                                        Console.Write("What kind of product you want to create: ");
                                                        string productType = Console.ReadLine().ToLower();
                                                        if (productType == "foodproduct" || productType == "food product")
                                                        {
                                                            string[] foodData = {"Give me the barcode : ",
                                                                                 "Give me the food name: ",
                                                                                 "Give me the manufacturer: ",
                                                                                 "Give me the food's calories: "};

                                                            string[] Datetime = {"Give me the warranty year: ",
                                                                                 "Give me the warranty month: ",
                                                                                 "Give me the warranty day: "};
                                                            List<string> DatetimeAnsw = new List<string>();
                                                            List<string> foodDataAnsw = new List<string>();
                                                            foreach (string data in foodData)
                                                            {
                                                                Console.Write(data);
                                                                foodDataAnsw.Add(Console.ReadLine());
                                                            }
                                                            foreach (string datatime in Datetime)
                                                            {
                                                                Console.Write(datatime);
                                                                DatetimeAnsw.Add(Console.ReadLine());
                                                            }
                                                            FoodProduct foodProduct = new FoodProduct(Convert.ToInt64(foodDataAnsw[0]),
                                                                                                        foodDataAnsw[1],
                                                                                                        foodDataAnsw[2],
                                                                                                        Convert.ToInt32(foodDataAnsw[3]),
                                                                                                        new DateTime(Convert.ToInt32(DatetimeAnsw[0]),
                                                                                                                     Convert.ToInt32(DatetimeAnsw[1]),
                                                                                                                     Convert.ToInt32(DatetimeAnsw[2])));
                                                            string[] quantityPrice = {"Give me the quantity: ",
                                                                                     "Give me the Price: "};
                                                            List<string> quantityPriceansw = new List<string>();
                                                            foreach (string data in quantityPrice)
                                                            {
                                                                Console.Write(data);
                                                                quantityPriceansw.Add(Console.ReadLine());
                                                            }
                                                            element.AddNewProduct(foodProduct, Convert.ToInt32(quantityPriceansw[0]), float.Parse(quantityPriceansw[1]));
                                                        }
                                                        else if (productType == "clothingproduct" || productType == "clothing product")
                                                        {
                                                            string[] clothdata = {"Give me the barcode : ",
                                                                                 "Give me the cloth name: ",
                                                                                 "Give me the manufacturer: ",
                                                                                 "Give me the material: ",
                                                                                 "Give me the type: " };
                                                            List<string> clothDataAnsw = new List<string>();
                                                            foreach (string data in clothdata)
                                                            {
                                                                Console.Write(data);
                                                                clothDataAnsw.Add(Console.ReadLine());
                                                            }
                                                            ClothingProduct clothing = new ClothingProduct(Convert.ToInt64(clothDataAnsw[0]),
                                                                                                            clothDataAnsw[1],
                                                                                                            clothDataAnsw[2],
                                                                                                            clothDataAnsw[3],
                                                                                                            clothDataAnsw[4]);
                                                            string[] quantityPrice = {"Give me the quantity: ",
                                                                                      "Give me the Price: "};
                                                            List<string> quantityPriceansw = new List<string>();
                                                            foreach (string data in quantityPrice)
                                                            {
                                                                Console.Write(data);
                                                                quantityPriceansw.Add(Console.ReadLine());
                                                            }
                                                            element.AddNewProduct(clothing, Convert.ToInt32(quantityPriceansw[0]), float.Parse(quantityPriceansw[1]));

                                                        }
                                                    }
                                                    else if (shopansw == "7")
                                                    {
                                                        Console.WriteLine("Product barcode and name: ");
                                                        foreach (Product product in element.GetProducts())
                                                        {

                                                            Console.WriteLine(product.Barcode + " " + product.Name);

                                                        }
                                                        Console.Write("Give me the barcode: ");
                                                        long barcodeansw = Convert.ToInt64(Console.ReadLine());
                                                        Console.Write("Give me the quantity: ");
                                                        int quantityansw = Convert.ToInt32(Console.ReadLine());
                                                        element.AddProduct(barcodeansw, quantityansw);

                                                    }
                                                    else if (shopansw == "8")
                                                    {
                                                        Console.WriteLine("Product barcode and name: ");
                                                        foreach (Product product in element.GetProducts())
                                                        {
                                                            Console.WriteLine(product.Barcode + " " + product.Name);
                                                        }
                                                        Console.Write("Give me the product's barcode which you want to buy: ");
                                                        long barcodeansw = Convert.ToInt64(Console.ReadLine());
                                                        Console.Write($"How many product you want to buy? : ");
                                                        int quantityansw = Convert.ToInt32(Console.ReadLine());
                                                        if (quantityansw == 1)
                                                        {
                                                            cart.Add(element.BuyProduct(barcodeansw));
                                                            prices.Add(element.GetPrice(barcodeansw));
                                                        }
                                                        else if (quantityansw > 1)
                                                        {
                                                            List<Product> buyedProduct = element.BuyProducts(barcodeansw, quantityansw);
                                                            foreach (Product product in buyedProduct)
                                                            {
                                                                cart.Add(product);
                                                                prices.Add(element.GetPrice(barcodeansw));
                                                            }
                                                        }
                                                    }
                                                    else if (shopansw == "9")
                                                    {
                                                        Console.Write("Product barcode and name: ");
                                                        foreach (Product product in element.GetProducts())
                                                        {

                                                            Console.WriteLine(product.Barcode + " " + product.Name);

                                                        }
                                                        Console.Write("Give me the barcode: ");
                                                        long barcodeansw = Convert.ToInt64(Console.ReadLine());
                                                        Console.WriteLine($"The product's price is {element.GetPrice(barcodeansw)}");
                                                    }
                                                    else if (shopansw == "10")
                                                    {
                                                        float finalPrice = 0;
                                                        foreach(float price in prices)
                                                        {
                                                            finalPrice += price;
                                                        }
                                                        Console.WriteLine("The product(s) you want to buy: ");
                                                        foreach (Product product in cart)
                                                        {
                                                            Console.WriteLine(product.ToString());
                                                        }
                                                        Console.WriteLine($"It will be {finalPrice}FT altogether");
                                                        Console.Write("You want to buy this product(s)? : ");

                                                        string buyansw = Console.ReadLine().ToLower();
                                                        if(buyansw == "yes" || buyansw == "y")
                                                        {
                                                            Console.WriteLine("Thank you for your visit");
                                                            cart.Clear();
                                                            prices.Clear();
                                                            break;
                                                        }
                                                        if (buyansw == "no" || buyansw == "n")
                                                        {
                                                            Console.WriteLine("Then please continue the purchase");
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                { Console.WriteLine(ex.Message); }
                                            }
                                        }
                                    }
                                }
                                else if(plazansw == "5")
                                {
                                    plaza.Open();
                                    Console.WriteLine("The plaza has been opened");
                                }
                                else if(plazansw == "6")
                                {
                                    plaza.Close();
                                    Console.WriteLine("The plaza has been closed");
                                }
                                else if(plazansw == "7")
                                {
                                    if (plaza.IsOpen())
                                        Console.WriteLine("The plaza is open");
                                    else
                                        Console.WriteLine("The plaza is closed");
                                }
                                else if(plazansw == "8")
                                {
                                    Console.WriteLine("you are leaving the plaza");
                                    break;
                                }

                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }


                    }
                    else if(answ == "2")
                    {
                        Console.WriteLine("Thank you for your visit, bye!");
                        break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
