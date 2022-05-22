using System.Collections.Generic;

namespace Chess.Models.Domain
{
    public class Piece
    {
        public int Id { get; set; }
        public Type Type { get; set; }

        public Color Color { get; set; }
        public List<MovingType> MovingTypes { get; set; }
        public List<Position> Moves { get; set; } = new List<Position>();
        public Position Position { get; set; }

        public int MoveCount { get; set; } = 0;

        public Piece()
        {

        }

        public Piece(Type type,
                    List<MovingType> movingTypes,
                    Position position, 
                    Color color)
        {
            Type = type;
            MovingTypes = movingTypes;
            Position = position;
            Color = color;
        }
    }
}
