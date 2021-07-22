using System.Collections.Generic;

namespace MindboxTask.Factories
{
    public interface IFigureFactory
    {
        public IFigure CreateFigure(params double[] sides);
    }
}