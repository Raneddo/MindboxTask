using System.Collections.Immutable;

namespace MindboxTask
{
    public interface IFigure
    {
        IImmutableList<double> Sides { get; }
        double GetSquare();
    }
}