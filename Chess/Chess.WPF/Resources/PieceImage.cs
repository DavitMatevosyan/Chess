using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.WPF.Resources
{
    public class PieceImage : Button
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public Models.Color Color { get; set; }
        public Models.Type Type { get; set; }

        public PieceImage(int row, int column, Models.Color color, Models.Type type)
        {
            Row = row;
            Column = column;
            Color = color;
            Type = type;

            Background = Brushes.Transparent;
            BorderThickness = new Thickness(0);

            SetImageSource($"/Images/Pieces/{Color.ToString()}{Type.ToString()}.png");
        }

        private void SetImageSource(string source)
        {
            var panel = new StackPanel();
            panel.Children.Add(new Image() { Source = new BitmapImage(new Uri(source, UriKind.Relative))});

            Content = panel;
        }
    }
}
