using System;
using System.Windows.Media;

namespace Tetris {
    public static class Block {
        public static Square[] CreateRandomBlock(int blockSpeed) {
            var shape = new Random().Next(6);
            Square[] chosenBlock = GetBlock(shape);

            MainWindow.UpdateSpeed(blockSpeed);

            return chosenBlock;
        }

        private static Square[] GetBlock(int shape) {
            //the first element is the central square for rotating the block
            Square[,] squares = {
                //L block
                {new Square(6, 0),new Square(5, 0), new Square(7, 0) , new Square(7, 1) },
                //I block
                { new Square(6, 0),new Square(4, 0), new Square(5, 0),new Square(7, 0) },
                //J block
                { new Square(6, 1),new Square(5, 1),  new Square(7, 1), new Square(7, 0) },
                //O block 
                { new Square(5, 0), new Square(5, 1), new Square(6, 0), new Square(6, 1) },
                //S block
                { new Square(6, 0), new Square(7, 0), new Square(5, 1), new Square(6, 1) },
                //T block
                {  new Square(6, 1),new Square(6, 0), new Square(5, 1), new Square(7, 1) },
                //Z block
                {new Square(6, 1), new Square(5, 0), new Square(6, 0) , new Square(7, 1) }
            };

            int blockSize = squares.GetLength(1);

            Square[] block = new Square[blockSize];

            for(int i = 0; i < blockSize; i++) {
                block[i] = squares[shape, i];
                block[i].Color = Colors[shape];
            }

            return block;
        }
        private static SolidColorBrush[] Colors = {
            Brushes.Indigo, Brushes.LawnGreen, Brushes.DeepSkyBlue, Brushes.Yellow, Brushes.Magenta, Brushes.Orange,
            Brushes.Red
        };
    }
}