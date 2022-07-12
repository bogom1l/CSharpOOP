using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double h, double w)
        {
            this.Width = w;
            this.Height = h;
        }
        public double Height 
        {
            get => this.height;
            private set => this.height = value;
        }
        public double Width
        {
            get => this.width;
            private set => this.width = value;
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
