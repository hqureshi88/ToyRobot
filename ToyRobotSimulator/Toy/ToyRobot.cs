using System;
using ToySimulator.Toy.Interface;

namespace ToySimulator.Toy
{

    public class ToyRobot : IToyRobot
    {
        public Direction Direction { get; set; }
        public IPosition Position { get; set; }
     
        // Sets the toy's position and direction.
        public void Place(IPosition position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        // Determines the next position of the toy based on the direction it's currently facing.
        public IPosition GetNextPosition()
        {
            var newPosition = Factory.CreatePosition(Position.X, Position.Y);
            int posY = newPosition.Y;
            int posX = newPosition.X;

            switch (Direction)
            {
                case Direction.North:
                    newPosition.Y = positionXY(posY, 5, 1, 1);
                    break;
                case Direction.East:
                    newPosition.X = positionXY(posX, 5, 1, 1);
                    break;
                case Direction.South:
                    newPosition.Y = positionXY(posY, 1, 5, -1);
                    break;
                case Direction.West:
                    newPosition.X = positionXY(posX, 1, 5, -1);
                    break;
            }
            return newPosition;
        }

        // This method is called when change in direction is called from switch
        // statement
        public int positionXY(int newPos, int i, int j, int k)
        {
            if (newPos == i)
            {
                newPos = j;
            }
            else
            {
                newPos = newPos + k;
            }
            return newPos;
        }

        // Rotates the direction of the toy 90 degreesto the left.
        public void RotateLeft()
        {
            Rotate(-1);
        }

        // Rotates the direction of the toy 90 degrees to the right.
        public void RotateRight()
        {
            Rotate(1);
        }

        // Determines the new direction of the toy. The new direction is based
        // on current direction and the rotation command (LEFT - Right)
        // the code uses the enumerate values for the NSEW and a modulus
        // operator to calculate the new direction.
        public void Rotate(int rotationNumber)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction newDirection;
            if ((Direction + rotationNumber) < 0)
                newDirection = directions[directions.Length - 1];
            else
            {
                var index = ((int)(Direction + rotationNumber)) % directions.Length;
                newDirection = directions[index];
            }
            Direction = newDirection;
        }
    }
}
