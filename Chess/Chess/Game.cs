using Chess.Games;
using Chess.Games.Kriegspiel;
using Chess.Models.Domain;
using System.Collections.Generic;

namespace Chess
{
    public class Game
    {
        private IEngine _engine;

        public GameType Type { get; set; }
        public List<Piece> Pieces { get; private set; } 


        public Game(GameType gameType)
        {
            Type = gameType;

            if (Type == GameType.Kriegspiel)
                _engine = new KriegspielEngine();
        }


        public void InitializeGame()
        {

           // WhitesGame = new WhitesGame();
            //BlacksGame = new BlacksGame();
            Pieces = _engine.Init();
        }

        public void StartGame()
        {
            _engine.Start();
        }
    }
}
