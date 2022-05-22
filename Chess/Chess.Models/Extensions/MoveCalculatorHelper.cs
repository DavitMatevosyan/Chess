using Chess.Models.Domain;
using System;
using System.Collections.Generic;

namespace Chess.Models.Extensions
{
    public static class MoveCalculatorHelper
    {
        public static void CalculateAllMoves(this List<Piece> pieces, int[,] board, Color color)
        {
            foreach (var piece in pieces)
            {
                if (piece.Color != color)
                    continue;

                piece.Moves = CalculateMoves(piece, board, pieces);
            }
        }

        public static List<Position> CalculateMoves(Piece piece, int[,] board, List<Piece> pieces)
        {
            var moves = new List<Position>();
            foreach (var type in piece.MovingTypes)
            {
                switch (type)
                {
                    case MovingType.HorizontalVertical:
                        moves.AddRange(CalculateHorizontalVerticalMoves(piece, board, pieces));
                        break;
                    case MovingType.Diagonal:
                        moves.AddRange(CalculateDiagonalMoves(piece, board, pieces));
                        break;
                    case MovingType.Pawn:
                        moves.AddRange(CalculatePawnMoves(piece, board, pieces));
                        break;
                    case MovingType.Knight:
                        moves.AddRange(CalculateBishopMoves(piece, board, pieces));
                        break;
                    case MovingType.King:
                        moves.AddRange(CalculateKingMoves(piece, board, pieces));
                        break;
                    default:
                        break;
                }
            }

            return moves;
        }

        private static IEnumerable<Position> CalculateKingMoves(Piece piece, int[,] board, List<Piece> pieces)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Position> CalculateBishopMoves(Piece piece, int[,] board, List<Piece> pieces)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Position> CalculatePawnMoves(Piece piece, int[,] board, List<Piece> pieces)
        {
            var moves = new List<Position>();

            var pos = piece.Position;

            if (board[pos.Y, pos.X - 1] == 0)
                moves.Add(new Position(pos.X, pos.Y + 1));

            if (pos.X + 1 < 9)
            {
                if (board[pos.Y, pos.X] == 0)
                    moves.Add(new Position(pos.X + 1, pos.Y + 1));
            }

            if (pos.X - 1 > 0)
            {
                if (board[pos.Y, pos.X - 2] == 0)
                    moves.Add(new Position(pos.X - 1, pos.Y + 1));
            }

            if (piece.MoveCount == 0 && board[pos.Y + 1, pos.X - 1] == 0)
                moves.Add(new Position(pos.X, pos.Y + 2));

            piece.Moves.AddRange(moves);
            return moves;
        }

        private static IEnumerable<Position> CalculateDiagonalMoves(Piece piece, int[,] board, List<Piece> pieces)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Position> CalculateHorizontalVerticalMoves(Piece piece, int[,] board, List<Piece> pieces)
        {
            int row = piece.Position.Y + 1;
            int col = piece.Position.X;
            int color = piece.Color == Color.White ? 1 : -1;

            while (row <= 8)
            {
                int pieceType = board[8 - col, 8 - row];
                if (pieceType == color)
                {
                    break;
                }
                else if (pieceType != color)
                {
                    piece.Moves.Add(new Position(8 - col, 8 - row));
                    if (pieceType == color * (-1))
                        break;
                }
                row++;
            }
            row = piece.Position.Y - 1;
            while (row > 0)
            {
                int pieceType = board[8 - col, 8 - row];
                if (pieceType == color)
                {
                    break;
                }
                else if (pieceType != color)
                {
                    piece.Moves.Add(new Position(8 - col, 8 - row));
                    if (pieceType == color * (-1))
                        break;
                }
                row--;
            }

            return null; // TODO implement this;
        }

    }
}
