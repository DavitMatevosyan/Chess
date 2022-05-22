using Chess.Models.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Models.Domain
{
    public class Board
    {
        public int Id { get; set; }
        public List<Piece> Pieces { get; set; }

        public int TotalAvailableMovesWhites { get; set; }
        public int TotalAvailableMovesBlacks { get; set; }

        private int[,] _board = new int[9, 9];

        public void CalculateAvailableMoves(List<Piece> pieces, Color color)
        {
            FillPieces();
            pieces.CalculateAllMoves(_board, color);
        }

        private void FillPieces()
        {
            foreach (var piece in Pieces)
            {
                _board[8 - piece.Position.Y, 8 - piece.Position.X] = piece.Color == Color.White ? 1 : -1;
            }
        }
    }
}
