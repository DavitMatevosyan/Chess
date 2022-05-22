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
    /// Interaction logic for Blacks.xaml
    /// </summary>
    public partial class Blacks : Window, IFillPieces
    {
        public Blacks()
        {
            InitializeComponent();
        }

        public void FillPieces(List<Piece> pieces)
        {
            foreach (var piece in pieces.Where(p => p.Color == Models.Color.Black))
            {
                var image = new PieceImage(piece.Position.X,
                                           piece.Position.Y,
                                           piece.Color,
                                           piece.Type);
                image.Click += Black_Piece_Click;
                boardGrid.Children.Add(image);
                Grid.SetColumn(image, 8 - piece.Position.X);
                Grid.SetRow(image, piece.Position.Y-1);
            }
        }

        private void Black_Piece_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
