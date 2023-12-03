using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Tetris {
    public class Score {
        private readonly TextBlock _levelTxt;
        private readonly TextBlock _scoreTxt;
        private readonly int _gameAreaHeight;
        private readonly int _gameAreaWidth;
        private int _score = 0;
        private int _level = 1;

        public Score(TextBlock levelTxt, TextBlock scoreTxt,
            int gameAreaHeight, int gameAreaWidth) {
            levelTxt.Text = "1";
            _levelTxt = levelTxt;
            _scoreTxt = scoreTxt;
            _gameAreaHeight = gameAreaHeight;
            _gameAreaWidth = gameAreaWidth;
        }

        public List<int> CheckFullLines(List<Square> savedBlocks) {
            int count = 0;
            var lines = new List<int>();

            for(var i = 0; i <= _gameAreaHeight; i++) {
                count = savedBlocks.Count(p => p.PositionY == i);

                if(count != _gameAreaWidth) {
                    count = 0;
                }
                else {
                    lines.Add(i);
                }
            }
            return lines;
        }

        public int UpdateScore(int lines, int speed) {
            _score += 100 * lines;
            _scoreTxt.Text = _score.ToString();

            if(_score >= _level * 1000) {
                _level++;
                speed -= 200;
                _levelTxt.Text = _level.ToString();
                return speed;
            }
            return speed;
        }
    }
}