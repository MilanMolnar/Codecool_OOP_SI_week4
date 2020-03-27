using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvProj
{
    interface IStorageCapable
    {
        List<Product> GetAllProduct();

        void StoreCdProduct(String name, int price, int track);

        void StoreBookProduct(String name, int price, int pages);
    }
}
