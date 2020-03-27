using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using InvProj.Models;

namespace InvProj.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public static PersistentStore ps = new PersistentStore();
        public static int allPrice = 0;
        public static List<Product> allProduct;
        public void LoadAddCd()
        {
            ActivateItem(new AddCdViewModel());
        }
        public void LoadAddBook()
        {
            ActivateItem(new AddBookViewModel());
        }
        public void LoadListProducts()
        {
            var temp = 0;
            foreach (var product in ps.GetAllProduct())
            {
                temp += product.Price;
            }
            allPrice = temp;
            allProduct = ps.GetAllProduct();
            ActivateItem(new ListProductsViewModel());
        }
        public void SettingsButton()
        {
            MessageBox.Show("Settings tab is not implemented yet :C");
        }
    }
}
