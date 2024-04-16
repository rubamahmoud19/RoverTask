using RoverTask.Rover.Enums;
using RoverTask.Rover.Models;

namespace RoverTask.Rover.Services
{
    public class MovementService : IMovementService
    {
        public SpaceShip HandleOutput(string input, SpaceShip ship, Planet planet)
        {
            input = input.ToUpper();
            switch (input)
            {
                case "R":
                case "L":
                    return RedirectTheShip(ship, input);
                case "M":
                    return MoveSpaceShip(ship, planet);
                default:
                    throw new Exception("Please enter a valid symbol r -> right, l -> left, m -> move");
            }
        }

        public SpaceShip MoveSpaceShip(SpaceShip ship, Planet planet)
        {
            var newCoordinate = new Coordinate { Xaxis = ship.coordinate.Xaxis, Yaxis = ship.coordinate.Yaxis };
            switch (ship.Direction)
            {
                case Direction.Left:
                    newCoordinate.Xaxis
                        -= 1;
                    break;
                case Direction.Right:
                    newCoordinate.Xaxis += 1;
                    break;
                case Direction.Bottom:
                    newCoordinate.Yaxis += 1;
                    break;
                case Direction.Top:
                    newCoordinate.Yaxis -= 1;
                    break;
            }
            if (newCoordinate.Xaxis > planet.Rows - 1 || newCoordinate.Yaxis > planet.Columns - 1 || newCoordinate.Xaxis < 0 || newCoordinate.Yaxis < 0)
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                ship.coordinate = newCoordinate;
            }
            return ship;
        }

        public SpaceShip RedirectTheShip(SpaceShip ship, string direction)
        {
            Movement movement = (Movement)System.Enum.Parse(typeof(Movement), direction);
            Direction newDirection = (Direction)(((int)ship.Direction + 4 + (int)movement) % 4);
            ship.Direction = newDirection;
            return ship;
        }
    }
}
