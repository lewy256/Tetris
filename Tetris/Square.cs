using System.Windows.Media;

namespace Tetris {
    public class Square {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Brush Color { get; set; }
        public string Id { get; set; }

        public Square(int positionX, int positionY) {
            PositionX = positionX;
            PositionY = positionY;
        }

        public Square(int positionX, int positionY, Brush color) {
            PositionX = positionX;
            PositionY = positionY;
            Color = color;
        }
    }
}