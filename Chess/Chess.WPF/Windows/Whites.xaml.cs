using Chess.Games.Kriegspiel;
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
    /// Interaction logic for Whites.xaml
    /// </summary>
    public partial class Whites : Window, IFillPieces
    {
        public Factory _factory { get; set; }

        public Whites()
        {
            InitializeComponent();
        }

        public void FillPieces(List<Piece> pieces)
        {
            foreach (var piece in pieces.Where(p => p.Color == Models.Color.White))
            {
                var image = new PieceImage(piece.Position.X,
                                           piece.Position.Y,
                                           piece.Color,
                                           piece.Type);
                image.Click += White_Piece_Click;
                boardGrid.Children.Add(image);
                Grid.SetColumn(image, piece.Position.X - 1);
                Grid.SetRow(image, 8 - piece.Position.Y );

            }
        }

        private void White_Piece_Click(object sender, RoutedEventArgs e)
        {
            var piecePosition = new Position();
            if(sender is PieceImage piece)
            {
                piecePosition.X = piece.Row;
                piecePosition.Y = piece.Column;
            }

            var moves = _factory.GetAvailableMoves(piecePosition);

            ShowAvailableMoves(moves);
        }

        private void ShowAvailableMoves(IEnumerable<Position> positions)
        {
          //  RemoveAvailableMoveLabels();

            foreach (var pos in positions)
            {
                var img = new MoveImage();
                boardGrid.Children.Add(img);
                Grid.SetRow(img, 8 - pos.Y);
                Grid.SetColumn(img, pos.X-1);
            }
        }

        private void RemoveAvailableMoveLabels()
        {
            var moveListLabel = new List<MoveImage>();
            foreach (var child in boardGrid.Children)
            {
                if (child is MoveImage img)
                {
                    moveListLabel.Add(img);
                }
            }
            foreach (var label in moveListLabel)
            {
                boardGrid.Children.Remove(label);
            }
        }
    }
}
