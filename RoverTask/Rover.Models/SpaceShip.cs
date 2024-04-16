using RoverTask.Rover.Enums;
namespace RoverTask.Rover.Models
{
    public class SpaceShip
    {
        public string Name { get; set; }
        public Coordinate coordinate { get; set; }
        public Direction Direction { get; set; }
    }
}

