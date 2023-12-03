using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;


namespace Tetris {
    public partial class MainWindow : Window {
        private static DispatcherTimer gameTickTimer = new DispatcherTimer();
        private readonly Game game;

        public MainWindow() {
            InitializeComponent();

            game = new Game(GameArea, ScoreTxt, LevelTxt, rectangleSize: 20);
            gameTickTimer.Tick += GameTickTimer_Tick;

        }

        public static void UpdateSpeed(int milliseconds) {
            gameTickTimer.Interval = new TimeSpan(0, 0, 0, 0, milliseconds);
        }

        private void MainWindow_OnContentRendered(object sender, EventArgs e) {
            game.Initialize();

            gameTickTimer.Start();
        }

        private void GameTickTimer_Tick(object sender, EventArgs e) {
            game.Pipeline();
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e) {
            game.Keyboard(e.Key);

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }
    }
}