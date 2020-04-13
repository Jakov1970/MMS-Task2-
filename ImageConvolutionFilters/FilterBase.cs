using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//---------------------------------------------------
//
//GITHUB link https://github.com/Jakov1970/MMS-Task2- 
//za slucaj da ne mozete da se snadjete 
//
//---------------------------------------------------

namespace MeanRemovalAndSphere
{
    public abstract class FilterBase
    {
        public abstract string FilterName
        {
            get;
        }

        public abstract double Factor
        {
            get;
        }

        public abstract double Bias
        {
            get;
        }

        public abstract double[,] FilterMatrix
        {
            get;
        }
    }
}
