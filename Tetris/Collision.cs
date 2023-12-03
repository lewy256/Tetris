using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Tetris {
    public static class Collision {
        public static bool CheckLeftSide(List<Square> savedBlocks, Square[] block) {
            for(var i = 0; i < block.Length; i++) {
                if(savedBlocks.Any(s =>
                        s.PositionX == block[i].PositionX - 1 &&
                        s.PositionY == block[i].PositionY) || block[i].PositionX - 1 < 0) {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckRightSide(List<Square> savedBlocks, Square[] block, int gameAreaWidth) {
            for(var i = 0; i < block.Length; i++) {
                if(savedBlocks.Any(s =>
                        s.PositionX == block[i].PositionX + 1 &&
                        s.PositionY == block[i].PositionY) ||
                    block[i].PositionX + 1 == gameAreaWidth) {
                    return false;
                }

            }
            return true;
        }

        public static bool CheckBottomSide(List<Square> savedBlocks, Square[] block, int gameAreaHeight) {
            for(var i = 0; i < block.Length; i++) {
                if(savedBlocks.Any(s =>
                        s.PositionX == block[i].PositionX &&
                        s.PositionY == block[i].PositionY + 1) ||
                    block[i].PositionY == gameAreaHeight - 1) {
                    return false;
                }
            }
            return true;
        }

        public static void CheckTopSide(List<Square> savedBlocks) {
            if(savedBlocks.Any(s => s.PositionY == 1)) {
                MessageBox.Show("Game over");
                Environment.Exit(0);
            }
        }

        public static bool CheckRotation(List<Square> savedBlocks, Square[] block, int gameAreaWidth) {
            var tempBlock = new Square[block.Length];
            for(int i = 0; i < block.Length; i++) {
                tempBlock[i] = block[i];
            }
            tempBlock = Movement.Rotation(tempBlock);

            if(CheckLeftSide(savedBlocks, tempBlock) == false ||
                CheckRightSide(savedBlocks, tempBlock, gameAreaWidth) == false) {
                return false;
            }
            return true;
        }
    }

}