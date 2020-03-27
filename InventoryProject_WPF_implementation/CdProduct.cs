using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvProj
{
    class CdProduct : Product
    {
        public int NumOfTracks { get; set; }
        public CdProduct(string name, int price, int numOfTracks) : base(price, name)
        {
            NumOfTracks = numOfTracks;
        }
    }
    
}
