namespace ToyRobotSimulator.Toy.Interface
{
    public interface IToyRobot
    {
        Direction Direction { get; set; }
        IPosition Position { get; set; }
        //IPosition WallPos { get; set; }

        // Sets the toy's position and direction.
        void Place(IPosition position, Direction direction);

        // Sets the wall's position.
        //void PlaceWall(IPosition wall);

        // Checks the next position of the toy based on the direction it's currently facing.
        IPosition GetNextPosition();

        // Gives new position value for either x or y coordinate on board
        int positionXY(int newPos, int i, int j, int k);

        // Rotates the direction of the toy 90 degrees to the left.
        void RotateLeft();

        // Rotates the direction of the toy 90 degrees to the right.
        void RotateRight();

        // Checks the new direction of the toy. The new direction is based on current direction and the rotation command (LEFT - Right)
        // identifies the side which the toy should be rotated on Left is -1 Right is 1      
        void Rotate(int rotationNumber);
        
    }
}
