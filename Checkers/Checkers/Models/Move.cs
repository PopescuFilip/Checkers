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
        
        private bool _hasCaptured;
        public bool HasCaptured { get { return _hasCaptured; } }
        public List<Position> Captured { get; set; }
        public Move(Position initialPosition, Position finalPosition)
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            _hasCaptured = false;
            Captured = new List<Position>();
        }
        public void AddCapture(Position newFinalPosition)
        {
            if(HasCaptured)
                return;
            _hasCaptured = true;
            Captured.Add(FinalPosition);
            //Captured.Add(GetCapturedPosition(FinalPosition, newFinalPosition));
            FinalPosition = newFinalPosition;
        }
        public Position Next()
        {
            int nextX = FinalPosition.X + (FinalPosition.X - InitialPosition.X);
            int nextY = FinalPosition.Y + (FinalPosition.Y - InitialPosition.Y);
            return new Position(nextX, nextY);
        }
        private Position GetCapturedPosition(Position initialPosition, Position finalPosition)
        {
            int captureX = (initialPosition.X - finalPosition.X) / 2;
            int captureY = (initialPosition.Y - finalPosition.Y) / 2;
            return new Position(captureX, captureY);
        }
    }
}
