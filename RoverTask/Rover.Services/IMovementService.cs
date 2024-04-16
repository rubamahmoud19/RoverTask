using RoverTask.Rover.Models;

namespace RoverTask.Rover.Services
{
    public interface IMovementService
    {
        public SpaceShip MoveSpaceShip(SpaceShip ship, Planet planet);
        public SpaceShip RedirectTheShip(SpaceShip ship, string direction);
        public SpaceShip HandleOutput(string input, SpaceShip ship, Planet planet);
    }
}
