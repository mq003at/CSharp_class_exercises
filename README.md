# C Sharp Classess

Practice C# classes with Map Game challenge

## Requirements

Check 2 challenges below. Codes should be givent in `ClassGame/Program.cs`

### CountryGame

1. Defining a class to represent a country. Each country has the following:

    - Name
    - Population (millions of people)
    - Region (such as: Western Europe, East Asia etc)
    - Capital
    - GDP
    - An array of languages which has the following details:
        - Name
        - IsPrimary (If the language is the main language)
    - An array of cities where each has:
        - Name
        - IsCapital (If the city is the capital)
    - Population
    - List of countries that border with this country

2. Defining these methods:

    - HasBorder: Check if a country has border with another country, given the country name or a country object (use overloading)
    - Indexer methods to get back cities/city of the country
    - CheckWealth: Get the country’s wealthiness level (use an enum, such as: SuperPoor, Poor, Medium, Rich, SuperRich) based on the GDP per capita - GDPP (you define the range freely)
NOTES:
You may need to define extra classes/structs to represent different entity/object types (think about real life)
Use method overloading if needed
When defining properties, think about what should be: readonly, init-only or with private setter.

### Maze challenge

Imagine the maze comprises several rooms. Each room has 4 sides East-West-South-North. Each side can have door or not.
Player can go from one room to another if they are connected:
    - East door of one room can connect to West door of another if they both exist, and vice versa
    - South door of one room can connect to North door of another if they both exist, and vice versa
    - One room can connect to maximum 4 other rooms (as each room has 4 sides)
Players will win the game if they can find their way our of the maze (they enter a door, which does not lead to another room)

1. Create class `Room`
    - 4 fields or properties: East, West, South, North with value either 0 or 1 (0 means no door, 1 means door exists)
    - 4 fields or properties of connections: EastRoom, WestRoom, SouthRoom, NorthRoom of type Room or null. These are the connected rooms, therefore you must check if room is not null, they must be
    the valid connection
2. The constructor should accept 4 parameters, East, West, South, North. Connections should be all null at first.
3. Add methods to class `Room`
    - AddConnection accepts two: one paramater of type Room, and one parameter which indicates the direction (East, West, South, North) that 2 rooms should connect. Validate the connection
    before set the corresponding connection. For example: when call room1.AddConnection(room2, "East") --> if valid, then set EastRoom of room1 as room2, and set WestRoom of room2 as room1.
    Each side of a room can only connect with 1 room if valid.
4. Class `Player`
    - 2 fields/properties: `Name` of type string and `CurrentPosition` of type Room
    - Add method `Move`, which accepts a parameter (you decide the type) indicating the direction of the move. You should validate if the move if possible to make (CurrentPosition should has door
    in that direction). If players escape (no connected room after the move), then print out a message to let them know and return false. Otherwise, print out the message that they are still trapped
    and return true.

## Run the program

`dotnet run --project ClassGame`
