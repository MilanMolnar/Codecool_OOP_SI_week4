using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using InvProj.Models;
using System.Xml.Linq;
using Microsoft.Win32;

namespace InvProj.ViewModels
{
    class ListProductsViewModel : Screen
    {

        private string _allProductPrice = ShellViewModel.allPrice.ToString();
        private BindableCollection<Product> _allProduct = new BindableCollection<Product>(ShellViewModel.allProduct);

        public string AllProductPrice
        {
            get { return _allProductPrice; }
            set 
            {
                _allProductPrice = value;
                NotifyOfPropertyChange(() => AllProductPrice);
            }
        }
        

        public BindableCollection<Product> AllProduct
        {
            get { return _allProduct; }
            set 
            {
                _allProduct = value;
                NotifyOfPropertyChange(() => AllProduct);
            }
        }

        public void SaveToXml()
        {
            ShellViewModel.ps.SaveToXml(ShellViewModel.ps.GetAllProduct());
            MessageBox.Show("State saved to MyDocuments, as an xml document");
        }
        public void SaveToCsv()
        {
            ShellViewModel.ps.SaveToCsv(ShellViewModel.ps.GetAllProduct());
            MessageBox.Show("State saved to MyDocuments, as a csv document");
        }

        public void LoadFromXml()
        {
            ShellViewModel.ps.ClearProducts();
            string filePath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog()== true)
            {
                filePath = fileDialog.FileName;
            }

            try
            {
                XElement element = XElement.Load(filePath);
                var productNodes = element.Elements("product");
                List<Product> products = new List<Product>();

                foreach (var node in productNodes)
                {
                    ShellViewModel.ps.StoreBookProduct(node.Descendants().First().Value, Convert.ToInt32(node.Descendants().Last().Value), 0);
                }
                AllProduct = new BindableCollection<Product>(ShellViewModel.ps.GetAllProduct());
                var temp = 0;
                foreach (var product in ShellViewModel.ps.GetAllProduct())
                {
                    temp += product.Price;
                }
                AllProductPrice = temp.ToString();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
