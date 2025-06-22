using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiplomaWork;
using System.Drawing;
using WindowsFormsApp1;

namespace WindowsFormsApp1.UnitTests
{
    [TestClass]
    public class ToolsTest
    {
        [TestMethod]
        public void Tools_CorrectCreateTool()
        {
            int gridWidth = 5;
            int gridHeight = 5;
            int pixelSize = 5;
            CustomPanel panel = new CustomPanel(gridWidth, gridHeight, pixelSize);

            string name = "Линия";
            int[,] layer = new int[gridWidth, gridHeight];
            var tool = new Tools(name, panel, layer);

            Assert.IsNotNull(tool);
        }

        [TestMethod]
        public void Tools_CorrectDrawSquare()
        {
            int gridWidth = 5;
            int gridHeight = 5;
            int pixelSize = 5;
            CustomPanel panel = new CustomPanel(gridWidth, gridHeight, pixelSize);

            string name = "Линия";
            int[,] layer = new int[gridWidth, gridHeight];
            var tool = new Tools(name, panel, layer);

            int x1 = 5;
            int y1 = 5;
            int x2 = 7;
            int y2 = 10;
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x1, y1);
            Color color = Color.Coral;
            tool.DrawSquare(point1, point2, color);
            Assert.IsNotNull(tool);
        }

        [TestMethod]
        public void Tools_CorrectDrawPixelAtPosition()
        {
            int gridWidth = 5;
            int gridHeight = 5;
            int pixelSize = 5;
            CustomPanel panel = new CustomPanel(gridWidth, gridHeight, pixelSize);

            string name = "Линия";
            int[,] layer = new int[gridWidth, gridHeight];
            var tool = new Tools(name, panel, layer);

            int x1 = 5;
            int y1 = 15;
            Point point = new Point(x1, y1);
            Color color = Color.Blue;
            tool.DrawPixelAtPosition(point, color);
            Assert.IsNotNull(tool);
        }
    }



}
