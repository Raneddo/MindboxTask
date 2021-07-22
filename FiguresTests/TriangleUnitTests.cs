using System;
using System.Collections.Generic;
using MindboxTask.Factories;
using MindboxTask.Figures;
using Xunit;

namespace FiguresTests
{
    public class TriangleUnitTests
    {
        private readonly IFigureFactory _figureFactory;
        
        public TriangleUnitTests()
        {
            _figureFactory = new TriangleFactory();
        }
        
        [Fact]
        public void CreateTest()
        {
            var triangle = _figureFactory.CreateFigure(1, 3, 4);
            
            Assert.IsType<Triangle>(triangle);
            Assert.IsNotType<RightTriangle>(triangle);
            Assert.Equal(new List<double> {4, 3, 1}, triangle.Sides);
        }
        
        [Fact]
        public void CreateRightTriangleTest()
        {
            var triangle = _figureFactory.CreateFigure(3, 4, 5);
            
            Assert.IsType<RightTriangle>(triangle);
            Assert.IsAssignableFrom<Triangle>(triangle);
            Assert.Equal(new List<double> {5, 4, 3}, triangle.Sides);
        }
        
        [Fact]
        public void TestExceptionOnNegativeSide()
        {
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(-1, 2, 3));
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(5, -2, 3));
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(5, 5, -1));
        }
        
        [Fact]
        public void TestExceptionOnZeroSide()
        {
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(1, 0, 1));
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(0, 1, 1));
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(0, 1, 1));
        }
        
        [Fact]
        public void GetSquareOfSimpleTriangleTest()
        {
            var triangle = _figureFactory.CreateFigure(1, 2, 2);

            var square = triangle.GetSquare();
            
            Assert.Equal(0.968246, square, 5);
        }
        
        [Fact]
        public void GetSquareOfRightTriangleTest()
        {
            var triangle = _figureFactory.CreateFigure(3, 4, 5);

            var square = triangle.GetSquare();
            
            Assert.Equal(6, square, 5);
        }
    }
}