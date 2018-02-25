using System;
namespace BonusLab13
{
    public class ParkingSpot
    { 
        public bool Open { get; set; }
        public int Size { get; set; }
        public int SpotNumber { get; set; }

        //When a parking spot is created it is marked as open (true/false), given a size 1-3, and assigned a spot number
        public ParkingSpot(bool open,int size, int spotNumber )
        {
            this.Open = open;
            this.Size = size;
            this.SpotNumber = spotNumber;
        }
    }
}
