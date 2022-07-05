using System;
using System.Collections.Generic;
using System.Text;

namespace _1.ClassBoxData
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public double Length 
        {
            get => this._length;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }

                this._length = value;
            }
        }
        public double Width 
        {
            get => this._width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }

                this._width = value;
            }
        }
        public double Height 
        {
            get => this._height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }

                this._height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double LataralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        public double SurfaceArea()
        {
            //2lw + 2lh + 2wh
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }


    }
}
