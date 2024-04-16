using RoverTask.Rover.Models;
using Microsoft.Extensions.DependencyInjection;
using RoverTask.Rover.Services;
using RoverTask.Rover.Enums;
using System.Numerics;

var serviceProvider = new ServiceCollection().AddSingleton<IMovementService, MovementService>().BuildServiceProvider();
var moveService = serviceProvider.GetRequiredService<IMovementService>();


var planet = new Planet();
Console.WriteLine("Enter the rows");
planet.Rows = int.Parse(Console.ReadLine());
Console.WriteLine("Rows " + planet.Rows);
Console.WriteLine("Enter the columns");
planet.Columns = int.Parse(Console.ReadLine());
Console.WriteLine("Columns " + planet.Columns);
var spaceShip = new SpaceShip { Direction = Direction.Top, coordinate = new Coordinate { Xaxis = 0, Yaxis = 0 } };
//
string input;
Console.WriteLine("m -> move, right -> r, left -> l, for stop enter stop");
do
{
    input = Console.ReadLine();
    spaceShip = moveService.HandleOutput(input, spaceShip, planet);
    Console.WriteLine(spaceShip.Direction);
    Console.WriteLine($"coordinate: {spaceShip.coordinate.Xaxis}, {spaceShip.coordinate.Yaxis}");
} while (input.ToLower() != "stop");