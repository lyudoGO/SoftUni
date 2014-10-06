using System;


namespace Problem01Shapes
{
    class Triangle : BasicShape
    {
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
            : base(sideA, sideB)
        {
            this.SideC = sideC;
        }

        public double SideC
        {
            get { return this.sideC; }
            set { this.sideC = value; }
        }

        public override double CalculateArea()
        {
            double area = Math.Sqrt((this.Width + this.Height - this.sideC) * (this.Width - this.Height + this.sideC) *
                ( - this.Width + this.Height + this.sideC) * (this.Width + this.Height + this.sideC)) / 4;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width + this.Height + this.SideC;
            return this.Width;
        }
             
    }
}
