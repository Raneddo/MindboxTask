using System;
using System.Collections.Immutable;

namespace MindboxTask.Figures
{
    public class Circle : IFigure
    {
        internal Circle(double radius)
        {
            Radius = radius;
        }

        private IImmutableList<double> _sides;
        public IImmutableList<double> Sides => _sides ??= ImmutableList.Create(Radius);
        
        public double Radius { get; }

        public double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }
}