using Chess.Games;
using Chess.Models.Domain;
using Chess.WPF.Helpers;
using Chess.WPF.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chess.WPF.Windows
{
    /// <summary>
    /// Interaction logic for Engine.xaml
    /// </summary>
    public partial class Engine : Window, IFillPieces
    {
        private Factory _factory;

        public Engine()
        {
            InitializeComponent();
            _factory = new Factory();
        }

        public void FillPieces(List<Piece> pieces)
        {
            foreach (var piece in pieces)
            {
                var image = new Image() { Source = new BitmapImage(new Uri($"/Images/Pieces/{piece.Color.ToString()}{piece.Type.ToString()}.png", UriKind.Relative)) };
                boardGrid.Children.Add(image);
                Grid.SetColumn(image, piece.Position.X - 1);
                Grid.SetRow(image, 8 - piece.Position.Y);
            }
        }

        /// <summary>
        /// Fills all boards with their pieces and then runs Whites and Blacks boards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kriegspiel_Click(object sender, RoutedEventArgs e)
        {
            _factory.Initialize(GameType.Kriegspiel);

            _factory.Game.InitializeGame();
            FillPieces(_factory.Game.Pieces);

            var whites = new Whites();
            whites._factory = _factory;
            var blacks = new Blacks();
            //blacks.Game = _factory;

            whites.FillPieces(_factory.Game.Pieces);
            blacks.FillPieces(_factory.Game.Pieces);

            whites.Show();
            blacks.Show();

            _factory.Game.StartGame();
            whites.turnLabel.Visibility = Visibility.Visible;
        }
    }
}
