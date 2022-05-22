using Chess.Models.Domain;
using System.Collections.Generic;

namespace Chess.WPF.Helpers
{
    public interface IFillPieces
    {
        void FillPieces(List<Piece> pieces);
    }

}
