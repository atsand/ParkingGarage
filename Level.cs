using System;
namespace BonusLab13
{
    public class Level
    {
        //An array represtenting the layout of the parking level
        public ParkingSpot[] SpotArray { get; set; }
        public int FloorNumber { get; set; }

        //When a level is created, it is populated with an array of parking spots and given a floor number
        public Level(int number)
        {
            SpotArray = new ParkingSpot[] {
                new ParkingSpot(true, 1, 1),
                new ParkingSpot(true, 1, 2),
                new ParkingSpot(true, 2, 3),
                new ParkingSpot(true, 2, 4),
                new ParkingSpot(true, 2, 5),
                new ParkingSpot(true, 3, 6),
                new ParkingSpot(true, 3, 7),
                new ParkingSpot(true, 3, 8),
                new ParkingSpot(true, 3, 9),
                new ParkingSpot(true, 3, 10)};

            this.FloorNumber = number;
        }
    }
}
