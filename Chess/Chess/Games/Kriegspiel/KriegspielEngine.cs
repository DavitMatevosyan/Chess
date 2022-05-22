using Chess.Models;
using Chess.Models.Domain;
using System.Collections.Generic;

namespace Chess.Games.Kriegspiel
{
    public class KriegspielEngine : IEngine
    {
        private List<Piece> pieceList;
        
        
        public  bool whiteTurn { get; private set; }

        public KriegspielEngine()
        {
            pieceList = new List<Piece>();
        }

        public List<Piece> Init()
        {
            for (int i = 1; i <= 8; i++)
                pieceList.Add(new Piece(Type.Pawn, new List<MovingType> { MovingType.Pawn }, new Position(i, 2), Color.White));
            pieceList.Add(new Piece(Type.Rook, new List<MovingType> { MovingType.HorizontalVertical }, new Position(1, 1), Color.White));
            pieceList.Add(new Piece(Type.Knight, new List<MovingType> { MovingType.Knight }, new Position(2, 1), Color.White));
            pieceList.Add(new Piece(Type.Bishop, new List<MovingType> { MovingType.Diagonal }, new Position(3, 1), Color.White));
            pieceList.Add(new Piece(Type.Queen, new List<MovingType> { MovingType.Diagonal, MovingType.HorizontalVertical }, new Position(4, 1), Color.White));
            pieceList.Add(new Piece(Type.King, new List<MovingType> { MovingType.King }, new Position(5, 1), Color.White));
            pieceList.Add(new Piece(Type.Bishop, new List<MovingType> { MovingType.Diagonal }, new Position(6, 1), Color.White));
            pieceList.Add(new Piece(Type.Knight, new List<MovingType> { MovingType.Knight }, new Position(7, 1), Color.White));
            pieceList.Add(new Piece(Type.Rook, new List<MovingType> { MovingType.HorizontalVertical }, new Position(8, 1), Color.White));

            for (int i = 1; i <= 8; i++)
                pieceList.Add(new Piece(Type.Pawn, new List<MovingType> { MovingType.Pawn }, new Position(i, 7), Color.Black));
            pieceList.Add(new Piece(Type.Rook, new List<MovingType> { MovingType.HorizontalVertical }, new Position(1, 8), Color.Black));
            pieceList.Add(new Piece(Type.Knight, new List<MovingType> { MovingType.Knight }, new Position(2, 8), Color.Black));
            pieceList.Add(new Piece(Type.Bishop, new List<MovingType> { MovingType.Diagonal }, new Position(3, 8), Color.Black));
            pieceList.Add(new Piece(Type.Queen, new List<MovingType> { MovingType.Diagonal, MovingType.HorizontalVertical }, new Position(4, 8), Color.Black));
            pieceList.Add(new Piece(Type.King, new List<MovingType> { MovingType.King }, new Position(5, 8), Color.Black));
            pieceList.Add(new Piece(Type.Bishop, new List<MovingType> { MovingType.Diagonal }, new Position(6, 8), Color.Black));
            pieceList.Add(new Piece(Type.Knight, new List<MovingType> { MovingType.Knight }, new Position(7, 8), Color.Black));
            pieceList.Add(new Piece(Type.Rook, new List<MovingType> { MovingType.HorizontalVertical }, new Position(8, 8), Color.Black));

            return pieceList;
        }

        public void Start()
        {
            whiteTurn = true;
        }
    }
}
