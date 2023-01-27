using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassGame
{
    public class Player
    {
        public string Name { get; set; }
        private Room _currentPosition;

        public Room CurrentPosition
        {
            get => _currentPosition;
            set => _currentPosition = value;
        }

        public Player(string name, Room currentPosition)
        {
            Name = name;
            _currentPosition = currentPosition;
        }

        public void Move(string direction)
        {
            switch (direction.ToLower())
            {
                case "north":
                    AttemptToMove(_currentPosition.DoorNorth, _currentPosition.RoomNorth);
                    break;
                case "east":
                    AttemptToMove(_currentPosition.DoorEast, _currentPosition.RoomEast);
                    break;
                case "west":
                    AttemptToMove(_currentPosition.DoorWest, _currentPosition.RoomWest);
                    break;
                case "south":
                    AttemptToMove(_currentPosition.DoorSouth, _currentPosition.RoomSouth);
                    break;
            }
        }

        private void AttemptToMove(bool doorDirection, Room destinationRoom)
        {
            if (doorDirection == false)
                Console.WriteLine("Trapped. There is no door that way");
            else if (destinationRoom != null)
            {
                // I could write this part to check 4 doors, but it would be realistic if I just check for "entrance". It would be weird if you just cannot find any doors after walking through one.
                CurrentPosition = destinationRoom;
                if (destinationRoom.Name == "Entrance")
                    Console.WriteLine("Congratulations! You escaped Castlevania!");
                else
                {
                    Console.WriteLine(
                        $"Move from {CurrentPosition.Name} to {destinationRoom.Name}."
                    );
                }
            }
            else
            {
                Console.WriteLine(
                    "There is a door here, but no room behind. Have you added the room yet?"
                );
            }
        }
    }
}
