using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredDoors
{
    public class DoorController
    {
        public List<Door> Doors { get; }

        public DoorController(int numDoors)
        {
            if (numDoors <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numDoors));
            }

            Doors = new List<Door>();

            for (int i = 0; i < numDoors; i++)
            {
                Doors.Add(new Door());   
            }
        }

        public string RunPass(int numPasses)
        {
            if (numPasses <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numPasses));
            }

            for (int pass = 0; pass < numPasses; pass++)
            {
                for (int doorNum = 0; doorNum < Doors.Count; doorNum++)
                {
                    if ((doorNum + 1) % (pass + 1) == 0)
                    {
                        Doors[doorNum].IsOpen = !Doors[doorNum].IsOpen;
                    }
                }
            }
            return GetDoorStates();
        }

        public string GetDoorStates()
        {
            var sb = new StringBuilder();

            foreach (var door in Doors)
            {
                sb.Append(door.GetState());
            }

            return sb.ToString();
        }
    }
}
