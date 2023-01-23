using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    private static void Main(string[] args)
    {

        //Challenge 1
        /* create variables from these countries
        Finland: 
        - Name: Finland
        - Population: 5530719
        - Region: Europe,
        - Capital: Helsinki
        - GDP: 27.3
        - Languages: Finnish, Swedish
        - Cities: Helsinki, Tampere, Lahti, Porvo, Kemi
        - Borders: Norway, Sweden, Russia
         */
        var Finland = new Country();
        Country.HasBorder(Finland);
        Country.HasBorder("Finland");
        Country.CheckWealth(Finland);
        var FinCities = Finland[0..4];
        var FirstCity = Finland[0];
        /* Write methods to print FinCities and FirstCity */
        
        //Challenge 2
        /* write your own game */
    }

    class Country
    {
        /* provide your code for challenge 1 here */
    }

    class Room
    {
        /* provide your code for challenge 2 here */
    }

    class Player
    {
        /* provide your code for challenge 2 here */
    }
}

