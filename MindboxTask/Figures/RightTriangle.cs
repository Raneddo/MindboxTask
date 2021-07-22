using System;
using System.Collections.Immutable;

namespace MindboxTask.Figures
{
    public class RightTriangle : Triangle
    {
        internal RightTriangle(IImmutableList<double> sides) : base(sides)
        {
        }

        public override double GetSquare()
        {
            return Sides[1] * Sides[2] / 2;
        }

        public static bool IsValidRightTriangle(double hypotenuse, double leg1, double leg2)
        {
            return Math.Abs(hypotenuse * hypotenuse - leg1 * leg1 - leg2 * leg2) <= double.Epsilon;
        }
    }
}