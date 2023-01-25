using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassGame
{
    public class Room
    {
        public string Name { get; set; }
        public bool DoorNorth { get; set; }
        public bool DoorEast { get; set; }
        public bool DoorWest { get; set; }
        public bool DoorSouth { get; set; }

        private Room? _roomNorth;
        private Room? _roomEast;
        private Room? _roomWest;
        private Room? _roomSouth;
        public Room? RoomNorth
        {
            get => _roomNorth;
            set => _roomNorth = value;
        }
        public Room? RoomEast
        {
            get => _roomEast;
            set => _roomEast = value;
        }
        public Room? RoomWest
        {
            get => _roomWest;
            set => _roomWest = value;
        }
        public Room? RoomSouth
        {
            get => _roomSouth;
            set => _roomSouth = value;
        }

        public Room(string name, bool doorNorth, bool doorEast, bool doorWest, bool doorSouth)
        {
            Name = name;
            DoorNorth = doorNorth;
            DoorEast = doorEast;
            DoorWest = doorWest;
            DoorSouth = doorSouth;
        }

        public void AddConnection(Room destinationRoom, string direction)
        {
            SwitchConnection(destinationRoom, direction.ToLower());
        }

        private void SwitchConnection(Room destinationRoom, string direction)
        {
            switch (direction)
            {
                case "north":
                    ImplementConnection(
                        destinationRoom,
                        destinationRoom.RoomSouth,
                        ref _roomNorth,
                        direction
                    );
                    break;

                case "east":
                    ImplementConnection(
                        destinationRoom,
                        destinationRoom.RoomWest,
                        ref _roomEast,
                        direction
                    );
                    break;

                case "west":
                    ImplementConnection(
                        destinationRoom,
                        destinationRoom.RoomEast,
                        ref _roomWest,
                        direction
                    );
                    break;

                case "south":
                    ImplementConnection(
                        destinationRoom,
                        destinationRoom.RoomNorth,
                        ref _roomSouth,
                        direction
                    );
                    break;
            }
        }

        private void ImplementConnection(
            Room destinationRoom,
            Room shouldBeCurrentRoom,
            ref Room currentRoomDirection,
            string direction
        )
        {
            if (shouldBeCurrentRoom == null || shouldBeCurrentRoom == this)
            {
                // shouldBeCurrentRoom = this; ---> Can you tell me how to make this work? I cannot get the reference of Loung.RoomSouth
                currentRoomDirection = destinationRoom;
                Console.WriteLine($"{Name} is now connected to {destinationRoom.Name} using {direction}ern door.");
            }
            else
            {
                Console.WriteLine(
                    $"Invalid request. There is already {shouldBeCurrentRoom.Name} available."
                );
            }
        }
    }
}
