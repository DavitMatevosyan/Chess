using Chess.Models.Domain;
using System.Collections.Generic;

namespace Chess.Games
{
    public interface IEngine
    {
        public List<Piece> Init();
        public void Start();
    }
}
