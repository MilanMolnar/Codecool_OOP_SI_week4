using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace InvProj.ViewModels
{
    class AddBookViewModel : Screen
    {

        private string _bookName;
        private int _bookPages;
        private int _bookPrice;

        public string BookName
        {
            get { return _bookName; }
            set 
            { 
                _bookName = value;
                NotifyOfPropertyChange(() => BookName);
            }
        }
        
        public int BookPrice
        {
            get { return _bookPrice; }
            set 
            {
                _bookPrice = value;
                NotifyOfPropertyChange(() => BookName);
            }
        }
        
        public int BookPages
        {
            get { return _bookPages; }
            set
            {
                _bookPages = value;
                NotifyOfPropertyChange(() => BookPages);
            }
        }

        public List<Product> listOfProducts = new List<Product>();

        public bool CanCommitChanges(string bookName, int bookPrice, int bookPages)
        {
            return !String.IsNullOrEmpty(bookName) && bookPrice != 0 && bookPages != 0;
        }
        public void CommitChanges(string bookName, int bookPrice, int bookPages)
        {
            PersistentStore ps = ShellViewModel.ps;
            ps.StoreBookProduct(BookName, BookPrice, BookPages);
            MessageBox.Show($"{BookName} has been added to the list");
        }
        
    }
}
