using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgIC
{
    class individuo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int[] Xbin { get; set; }
        public int[] Ybin { get; set; }
        public int Value { get; set; }
        public int Xdist { get; set; }
        public bool Evolved { get; set; }
        public int Phenotype { get; set; }
        

    }
}
