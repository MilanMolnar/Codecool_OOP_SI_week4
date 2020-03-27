using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvProj
{
    class BookProduct : Product
    {
        public int NumOfPages { get; set; }

        public BookProduct(string name, int price, int numOfPages) : base(price, name)
        {
            NumOfPages = numOfPages;
        }
    }
}
