using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


//---------------------------------------------------
//
//GITHUB link https://github.com/Jakov1970/MMS-Task2- 
//za slucaj da ne mozete da se snadjete 
//
//---------------------------------------------------


namespace MeanRemovalAndSphere
{
    class SphereFilter : FilterBase
    {
        public override string FilterName
        {
            get { return "SphereFilter"; }
        }

        private double factor = 1.0 / 8.0;
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { 1, 1, 1, },
                            { 1, 1, 1, },
                            { 1, 1, 1, }, };

        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }

        public struct FloatPoint
        {
            public double X;
            public double Y;
        }

        public static bool Sphere(Bitmap b, bool bSmoothing)
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            FloatPoint[,] fp = new FloatPoint[nWidth, nHeight];
            Point[,] pt = new Point[nWidth, nHeight];

            Point mid = new Point();
            mid.X = nWidth / 2;
            mid.Y = nHeight / 2;

            double theta, radius;
            double newX, newY;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    int trueX = x - mid.X;
                    int trueY = y - mid.Y;
                    theta = Math.Atan2((trueY), (trueX));

                    radius = Math.Sqrt(trueX * trueX + trueY * trueY);

                    double newRadius = radius * radius / (Math.Max(mid.X, mid.Y));

                    newX = mid.X + (newRadius * Math.Cos(theta));

                    if (newX > 0 && newX < nWidth)
                    {
                        fp[x, y].X = newX;
                        pt[x, y].X = (int)newX;
                    }
                    else
                    {
                        fp[x, y].X = fp[x, y].Y = 0.0;
                        pt[x, y].X = pt[x, y].Y = 0;
                    }

                    newY = mid.Y + (newRadius * Math.Sin(theta));

                    if (newY > 0 && newY < nHeight && newX > 0 && newX < nWidth)
                    {
                        fp[x, y].Y = newY;
                        pt[x, y].Y = (int)newY;
                    }
                    else
                    {
                        fp[x, y].X = fp[x, y].Y = 0.0;
                        pt[x, y].X = pt[x, y].Y = 0;
                    }
                }

            if (bSmoothing)
                OffsetFilterAbs(b, pt);

            return true;
        }



        public static bool OffsetFilterAbs(Bitmap b, Point[,] offset)
        {
            int xOffset, yOffset;

            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    xOffset = offset[x, y].X;
                    yOffset = offset[x, y].Y;
                              
                    if (yOffset >= 0 && yOffset < b.Height && xOffset >= 0 && xOffset < b.Width)
                    {
                        Color c1 = b.GetPixel(x, y);
                        int r1 = c1.R;
                        int g1 = c1.G;
                        int b1 = c1.B;

                        //r1 = (byte)((yOffset * r1) + (xOffset * 3));
                        //g1 = (byte)((yOffset * g1) + (xOffset * 3) + 1);
                        //b1 = (byte)((yOffset * b1) + (xOffset * 3) + 2);

                        r1 = (byte)((yOffset * r1) + (xOffset * 3));
                        g1 = (byte)((yOffset * g1) + (xOffset * 3) + 1);
                        b1 = (byte)((yOffset * b1) + (xOffset * 3) + 2);

                        b.SetPixel(x, y, Color.FromArgb(r1, g1, b1));
                    }
                }
            }
            
            return true;

        }

    }



}

