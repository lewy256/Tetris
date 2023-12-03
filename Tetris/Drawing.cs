using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tetris {
    public class Drawing {
        private readonly Canvas _gameArea;
        private readonly int _rectangleSize;

        public Drawing(Canvas gameArea, int rectangleSize) {
            _gameArea = gameArea;
            _rectangleSize = rectangleSize;
        }

        public string DrawSquare(Square square) {
            if(square.Id is null) {
                square.Id = Guid.NewGuid().ToString();
            }

            var rect = new Rectangle {
                Width = _rectangleSize,
                Height = _rectangleSize,
                Fill = square.Color,
                Uid = square.Id
            };

            _gameArea.Children.Add(rect);

            Canvas.SetTop(rect, square.PositionY * _rectangleSize);
            Canvas.SetLeft(rect, square.PositionX * _rectangleSize);

            return square.Id;
        }

        public void CleanSquare(string id) {
            var rect = FindUid(_gameArea, id);
            _gameArea.Children.Remove(rect);
        }

        private UIElement FindUid(DependencyObject parent, string uid) {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            for(int i = 0; i < count; i++) {
                var el = VisualTreeHelper.GetChild(parent, i) as UIElement;
                /*          if(el == null) {
                              continue;
                          }*/

                if(el.Uid == uid) {
                    return el;
                }

                el = FindUid(el, uid);
                if(el != null) {
                    return el;
                }
            }
            return null;
        }
    }
}
