using System;
using MindboxTask.Factories;
using MindboxTask.Figures;
using Xunit;

namespace FiguresTests
{
    public class CircleUnitTests
    {
        private readonly IFigureFactory _figureFactory;
        
        public CircleUnitTests()
        {
            _figureFactory = new CircleFactory();
        }
        
        [Fact]
        public void CreateTest()
        {
            var circle = _figureFactory.CreateFigure(3.5);
            
            Assert.IsType<Circle>(circle);
            Assert.Equal(3.5, circle.Sides[0]);
            Assert.Equal(3.5, ((Circle) circle).Radius);
        }
        
        [Fact]
        public void TestExceptionOnNegativeRadius()
        {
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(-1));
        }
        
        [Fact]
        public void TestExceptionOnZeroRadius()
        {
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(0));
        }
        
        [Fact]
        public void TestExceptionOnSidesNotEqualToOne()
        {
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure(1, 2));
            Assert.Throws<ArgumentException>(() => _figureFactory.CreateFigure());
        }

        [Fact]
        public void GetSquareTest()
        {
            var circle = _figureFactory.CreateFigure(3);

            var square = circle.GetSquare();
            
            Assert.Equal(28.274333882, square, 7);
        }
    }
}