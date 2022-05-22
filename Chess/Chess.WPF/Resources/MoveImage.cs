using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.WPF.Resources
{
    public class MoveImage : Image
    {
        public MoveImage() : base()
        {
            Source = new BitmapImage(new Uri("/Images/moveIcon.png", UriKind.Relative));
        }
    }
}
