using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Move
    {
        public Position InitialPosition { get; }
        public Position FinalPosition { get; set; }
        public bool HasCaptured { get; }
        public List<Position> Captured { get; set; }
        public Move(Position initialPosition, Position finalPosition, bool capture = false)
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            HasCaptured = capture;
            Captured = new List<Position>();
            if(HasCaptured)
                Captured.Add(GetCapturedPosition(InitialPosition, FinalPosition));
        }
        public void AddCapture(Position newFinalPosition)
        {
            if(HasCaptured)
                return;

            Captured.Add(GetCapturedPosition(FinalPosition, newFinalPosition));
            FinalPosition = newFinalPosition;
        }

        private Position GetCapturedPosition(Position initialPosition, Position finalPosition)
        {
            int captureX = (initialPosition.X - finalPosition.X) / 2;
            int captureY = (initialPosition.Y - finalPosition.Y) / 2;
            return new Position(captureX, captureY);
        }
    }
}
