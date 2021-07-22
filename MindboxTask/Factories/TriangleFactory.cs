using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MindboxTask.Figures;

namespace MindboxTask.Factories
{
    public class TriangleFactory : IFigureFactory
    {
        public IFigure CreateFigure(params double[] sides)
        {
            if (sides.Length != 3)
            {
                throw new ArgumentException("Invalid sides count for triangle");
            }

            if (sides.Any(x => x <= 0))
            {
                throw new ArgumentException("Sides can't be zero or negative");
            }
            
            var ordered =  sides.OrderByDescending(x => x).ToImmutableList();

            if (ordered[0] > ordered[1] + ordered[2])
            {
                throw new ArgumentException("One side cannot be greater than the sum of the other two");
            }

            if (RightTriangle.IsValidRightTriangle(ordered[0], ordered[1], ordered[2]))
            {
                return new RightTriangle(ordered);
            }
            else
            {
                return new Triangle(ordered);
            }
        }
    }
}