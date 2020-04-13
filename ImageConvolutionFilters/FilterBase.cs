/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
