using System;
using System.Collections.Immutable;
using System.Linq;

namespace MindboxTask.Figures
{
    public class Triangle : IFigure
    {
        /// <summary>
        /// Triangle with sides ordered by desc
        /// </summary>
        /// <param name="sides"></param>
        /// <exception cref="ArgumentException"></exception>
        internal Triangle(IImmutableList<double> sides)
        {
            Sides = sides.ToImmutableList();
        }

        public IImmutableList<double> Sides { get; }

        public virtual double GetSquare()
        {
            var perimeterHalf = Sides.Sum() / 2;
            
            var multUnderSqrt = Sides
                .Select(x => perimeterHalf - x)
                .Aggregate(perimeterHalf, (a, b) => a * b);

            return Math.Sqrt(multUnderSqrt);
        }
    }
}