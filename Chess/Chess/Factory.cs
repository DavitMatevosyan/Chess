using Chess.Games;
using Chess.Games.Kriegspiel;
using Chess.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Factory
    {
        public Game Game { get; private set; }
        public WhitesGame WhitesGame { get; private set; }
        //public BlacksGame BlacksGame { get; private  set; }

        public void Initialize(GameType gameType)
        {
            Game = new Game(gameType);
            WhitesGame = new WhitesGame();
            //BlacksGame = new BlacksGame();
        }

        public IEnumerable<Position> GetAvailableMoves(Position piecePosition)
        {
            var piece = Game.Pieces.Where(x => x.Position.X == piecePosition.X && x.Position.Y == piecePosition.Y).FirstOrDefault();

            if (piece is null)
                return new List<Position>();

            if (piece.Color == Models.Color.White)
                return WhitesGame.GetAvailableMoves(Game.Pieces.Where(x => x.Color== Models.Color.White), piece);

            //if (piece.Color == Models.Color.Black)
            //    return BlacksGame.GetAvailableMoves();

            return new List<Position>();

        }
    }
}
