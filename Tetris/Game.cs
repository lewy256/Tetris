using System.Windows.Controls;
using System.Windows.Input;

namespace Tetris {
    public class Game {
        private readonly int _gameAreaWidth;
        private readonly int _gameAreaHeight;
        private readonly Map _map;
        private readonly Score _score;
        private Square[] _currentBlock;
        private int _speed = 600;

        public Game(Canvas gameArea, TextBlock scoreTxt, TextBlock levelTxt, int rectangleSize) {
            _gameAreaWidth = (int)(gameArea.Width / rectangleSize);
            _gameAreaHeight = (int)(gameArea.Height / rectangleSize);

            _map = new Map(gameArea, rectangleSize);
            _score = new Score(levelTxt, scoreTxt, _gameAreaHeight, _gameAreaWidth);
        }

        public void Initialize() {
            _currentBlock = Block.CreateRandomBlock(_speed);
        }

        public void Pipeline() {
            _map.DeleteBlock(_currentBlock);
            _currentBlock = _map.DrawBlock(_currentBlock);


            if(!Collision.CheckBottomSide(_map.SavedBlocks, _currentBlock, _gameAreaHeight)) {
                Collision.CheckTopSide(_map.SavedBlocks);
                _map.SaveBlock(_currentBlock);

                var lines = _score.CheckFullLines(_map.SavedBlocks);

                if(lines.Count != 0) {
                    foreach(var line in lines) {
                        _map.CleanFullLine(line);
                    }
                    _speed = _score.UpdateScore(lines.Count, _speed);
                }

                _currentBlock = Block.CreateRandomBlock(_speed);
                _currentBlock = _map.DrawBlock(_currentBlock);
            }

            _currentBlock = Movement.MoveDownBlock(_currentBlock);
        }

        public void Keyboard(Key e) {
            switch(e) {
                case Key.Down:
                    MainWindow.UpdateSpeed(1);
                    break;
                case Key.Left:
                    if(Collision.CheckLeftSide(_map.SavedBlocks, _currentBlock)) {
                        Movement.MoveLeftBlock(_currentBlock);
                    }
                    break;
                case Key.Right:
                    if(Collision.CheckRightSide(_map.SavedBlocks, _currentBlock, _gameAreaWidth)) {
                        Movement.MoveRightBlock(_currentBlock);
                    }
                    break;
                case Key.Up:
                    if(Collision.CheckRotation(_map.SavedBlocks, _currentBlock, _gameAreaWidth)) {
                        _map.DeleteBlock(_currentBlock);
                        _currentBlock = Movement.Rotation(_currentBlock);
                        _currentBlock = _map.DrawBlock(_currentBlock);
                    }
                    break;
            }
        }
    }
}