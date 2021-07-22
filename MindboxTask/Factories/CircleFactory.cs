using System;
using System.Collections.Generic;
using System.Linq;
using MindboxTask.Figures;

namespace MindboxTask.Factories
{
    public class CircleFactory : IFigureFactory
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sides">One element array with radius</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Sides count != 1</exception>
        /// <exception cref="ArgumentException">Not positive radius</exception>
        public IFigure CreateFigure(params double[] sides)
        {
            if (sides.Length != 1)
            {
                throw new ArgumentException("Circle have only one side (radius)");
            }

            var radius = sides.First();
            if (radius <= 0)
            {
                throw new ArgumentException("Radius can't be negative or zero");
            }
            
            return new Circle(radius);
        }
    }
}