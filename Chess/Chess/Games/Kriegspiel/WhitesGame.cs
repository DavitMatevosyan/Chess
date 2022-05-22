using Chess.Models.Domain;
using Chess.Models.Extensions;
using System;
using System.Collections.Generic;

namespace Chess.Games.Kriegspiel
{
    public class WhitesGame
    {
        private int[,] board;

        public WhitesGame()
        {
            board = new int[8, 8];
        }

        internal IEnumerable<Position> GetAvailableMoves(IEnumerable<Piece> pieces, Piece piece)
        {
            foreach (var p in pieces)
            {
                board[p.Position.Y - 1, p.Position.X - 1] = 1;
            }

            // todo remove list piece
            return MoveCalculatorHelper.CalculateMoves(piece, board, new List<Piece>()); 
        }
    }
}
