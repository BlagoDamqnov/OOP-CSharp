using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Lenght = length;
            this.Width = width;
            this.Height = height;
        }


       public double Lenght
        {
            get
            {
                return this.length;
            }
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

       
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double area = 2 * (this.Lenght * this.Width) +
                2 * (this.Lenght * this.Height) +
                2 * (this.Width * this.Height);
            return area;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.Lenght * this.Height) +
                (2 * this.Width * this.Height);
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.Width * this.Lenght * this.Height;
            return volume;
        }
    }
}

