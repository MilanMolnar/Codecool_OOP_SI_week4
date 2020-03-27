using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace InvProj.ViewModels
{
    class AddCdViewModel : Screen
    {
        private string _cdName;
        private int _cdNumOfTracks;
        private int _cdPrice;

        public string CdName
        {
            get { return _cdName; }
            set 
            { 
                _cdName = value;
                NotifyOfPropertyChange(() => CdName);
            }
        }
        
        public int CdPrice
        {
            get { return _cdPrice; }
            set 
            {
                _cdPrice = value;
                NotifyOfPropertyChange(() => CdName);
            }
        }
        
        public int CdNumOfTracks
        {
            get { return _cdNumOfTracks; }
            set
            {
                _cdNumOfTracks = value;
                NotifyOfPropertyChange(() => CdNumOfTracks);
            }
        }

        public List<Product> listOfProducts = new List<Product>();

        public bool CanCommitChanges(string cdName, int cdPrice, int cdNumOfTracks)
        {
            return !String.IsNullOrEmpty(cdName) && cdPrice != 0 && cdNumOfTracks != 0;
        }
        public void CommitChanges(string cdName, int cdPrice, int cdNumOfTracks)
        {
            PersistentStore ps = ShellViewModel.ps;
            ps.StoreCdProduct(CdName, CdPrice, CdNumOfTracks);

            MessageBox.Show($"{CdName} has been added to the list");
        }
    }
}
