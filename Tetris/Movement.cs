namespace Tetris {
    public static class Movement {
        public static Square[] MoveDownBlock(Square[] block) {
            for(var i = 0; i < block.Length; i++) {
                block[i].PositionY++;
            }

            return block;
        }

        public static Square[] MoveLeftBlock(Square[] block) {
            for(var i = 0; i < block.Length; i++) {
                block[i].PositionX--;

            }
            return block;
        }

        public static Square[] MoveRightBlock(Square[] block) {
            for(var i = 0; i < block.Length; i++) {
                block[i].PositionX++;

            }
            return block;
        }

        public static Square[] Rotation(Square[] block) {
            //int cosine = (int)Math.Cos(Math.PI / 2) -> 0;
            //int sine=(int)Math.Sin(-Math.PI / 2) -> -1; rotation right
            //block[0] -> the central square in the block for rotating 

            int tempPositionX = 0;
            int tempPositionY = 0;

            for(int i = 0; i < block.Length; i++) {
                tempPositionX = block[0].PositionY - block[i].PositionY + block[0].PositionX;

                tempPositionY = block[i].PositionX - block[0].PositionX + block[0].PositionY;

                block[i] = new Square(tempPositionX, tempPositionY, block[0].Color);
            }

            return block;
        }

    }
}