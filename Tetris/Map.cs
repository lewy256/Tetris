using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Tetris {
    public class Map {
        private readonly Drawing _drawing;

        public Map(Canvas gameArea, int rectangleSize) {
            _drawing = new Drawing(gameArea, rectangleSize);
        }

        public List<Square> SavedBlocks { get; private set; } = new List<Square>();

        public Square[] DrawBlock(Square[] block) {
            for(int i = 0; i < block.Length; i++) {
                block[i].Id = _drawing.DrawSquare(block[i]);
            }
            return block;
        }

        public void SaveBlock(Square[] block) {
            for(int i = 0; i < block.Length; i++) {
                SavedBlocks.Add(block[i]);
            }
        }

        public void DeleteBlock(Square[] block) {
            for(int i = 0; i < block.Length; i++) {
                _drawing.CleanSquare(block[i].Id);
            }

        }

        public void CleanFullLine(int line) {
            var squaresToDelete = SavedBlocks.Where(s => s.PositionY == line).ToList();

            foreach(var square in squaresToDelete) {
                SavedBlocks.Remove(square);
                _drawing.CleanSquare(square.Id);
            }
            ReorganizeBlocks(line);
        }

        private void ReorganizeBlocks(int line) {
            var squaresToMove = SavedBlocks.Where(s => s.PositionY < line).ToList();

            foreach(var square in squaresToMove) {
                SavedBlocks.Remove(square);
                _drawing.CleanSquare(square.Id);

                square.PositionY++;
                _drawing.DrawSquare(square);
                SavedBlocks.Add(square);
            }
        }
    }
}