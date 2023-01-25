using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClassGame
{
    class Program
    {     
        private static void Main(string[] args)
        {
            // Console.Clear();
            Console.WriteLine(new string('*', 80));
            Console.WriteLine("Challenge 1:");
            Console.WriteLine(new string('*', 80));

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
            var Finland = new Country("Finland", 5, "Europe", 27.3);
            var Norway = new Country("Norway", 1, "Europe", 20.0);
            var Sweden = new Country("Sweden", 1, "Europe", 20.0);
            var Russia = new Country("Russia", 1, "Europe", 20.0);

            var Helsinki = new City("Helsinki", true, 50000);
            var Tampere = new City("Tampere", false, 50000);
            var Lahti = new City("Lahti", false, 50000);
            var Porvo = new City("Porvo", false, 50000);
            var Kemi = new City("Kemi", false, 50000);

            var Finnish = new Language("Finnish", true);
            var Swedish = new Language("Swedish", true);

            Finland.Population = 5530719;
            Finland.CapitalCity = Helsinki;
            Finland.Languages.Add(Finnish);
            Finland.Languages.Add(Swedish);
            Finland[0] = Helsinki;
            Finland[1] = Tampere;
            Finland[2] = Lahti;
            Finland[3] = Porvo;
            Finland[4] = Kemi;
            Finland.BorderCountries.Add(Sweden);
            Finland.BorderCountries.Add(Norway);
            Finland.BorderCountries.Add(Russia);

            Console.WriteLine(
                $"Testing: {Finland.Name} {Finland.Population} {Finland.Region} {Finland.CapitalCity.Name} {Finland.GDP}."
            );

            // Get the languages.
            Console.Write("Testing: Finland has language: ");
            foreach (Language lang in Finland.Languages)
            {
                Console.Write($"{lang.Name} ");
            }
            Console.WriteLine("");

            // Get the cities.
            Console.Write("Testing: Finland has cities: ");
            foreach (City city in Finland.Cities)
            {
                Console.Write($"{city.Name} ");
            }
            Console.WriteLine("");

            // Get Border Countries
            Console.Write("Testing: Countries neighboring Finland are: ");
            foreach (Country country in Finland.BorderCountries)
            {
                Console.Write($"{country.Name} ");
            }
            Console.WriteLine("");
            Country.HasBorder(Finland);
            Country.HasBorder("Finland");

            // First city and wealth check
            var FinCities = Finland[0..4];
            var FirstCity = Finland[0];
            Console.WriteLine($"Finland's first city: {FirstCity.Name}.");
            Console.WriteLine($"Wealth check: {Country.CheckWealth(Finland)}.");

            //Challenge 2
            /* write your own game */
            Console.WriteLine("\n" + new string('*', 80));
            Console.WriteLine("Challenge 2:");
            Console.WriteLine(new string('*', 80));

            // Room creation
            var Entrance = new Room("Entrance", true, false, false, false);
            var Lounge = new Room("Lounge", true, true, true, true);

            Entrance.AddConnection(Lounge, "north");
            Console.WriteLine($"North of room {Entrance.Name} is {Entrance.RoomNorth.Name}.");
        }

        class Country
        {
            /* provide your code for challenge 1 here */
            private string _name,
                _region;
            private City _capitalCity;
            private City[] _cities;
            public int Population { get; set; }
            public double GDP { get; set; }
            public City CapitalCity
            {
                get { return _capitalCity; }
                set { _capitalCity = value; }
            }
            public List<Country> BorderCountries { get; set; }
            public List<Language> Languages { get; set; }
            public City[] Cities
            {
                get { return _cities; }
            }
            public static Dictionary<string, Country> Countries = new Dictionary<string, Country>();

            // Constructor
            public Country(string name, int numberOfCities, string region, double gdp)
            {
                _name = name;
                _cities = new City[numberOfCities];
                _region = region;
                _capitalCity = new City("Placeholder", true, 0);
                GDP = gdp;
                Languages = new List<Language>();
                BorderCountries = new List<Country>();
                Countries.Add(name, this);
            }

            // Get/set name & region
            public string Name
            {
                get { return _name; }
                set { nameValidation(ref _name, value); }
            }

            public string Region
            {
                get { return _region; }
                set { nameValidation(ref _name, value); }
            }

            public City this[Index index]
            {
                get => _cities[index];
                set => _cities[index] = value;
            }

            // Get/set Cities. This will overload the [] of Country[]. Testing Exception.
            // public City this[int index]
            // {
            //     get
            //     {
            //         if (index < 0 || index >= _cities.Length)
            //             throw new ArgumentOutOfRangeException("Index is out of range");
            //         else
            //             return _cities[index];
            //     }
            //     set
            //     {
            //         if (index < 0 || index >= _cities.Length)
            //             throw new ArgumentOutOfRangeException("Index is out of range");
            //         else
            //             _cities[index] = value;
            //     }
            // }

            public City[] this[Range range] => _cities[range];

            // HasBorder: params can be Country object or a string
            public static void HasBorder(Country country)
            {
                Console.Write($"Country {country.Name} share its borders with: ");
                foreach (Country bCountry in country.BorderCountries)
                {
                    Console.Write($"{bCountry.Name} ");
                }
                Console.Write("\n");
            }

            public static void HasBorder(string countryName)
            {
                Country countryInstance = Countries[countryName];
                HasBorder(countryInstance);
            }

            public static string CheckWealth(Country country) 
            {
                return CheckWealthOnGDPP(country.GDP);
            }
        }

        // Each city has a name, is a capital city and population
        public class City
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set { nameValidation(ref _name, value); }
            }
            public bool IsCapital { get; set; }
            public int Population { get; set; }

            public City(string name, bool isCapital, int population)
            {
                _name = name;
                IsCapital = isCapital;
                Population = population;
            }
        }

        public class Language
        {
            public string Name { get; set; }
            public bool IsDefault { get; set; }

            public Language(string name, bool isDefault)
            {
                Name = name;
                IsDefault = isDefault;
            }
        }

        // Extension method
        // public class LanguageListToString
        // {
        //     public static string GetAll(this List<Language> languages)
        //     {
        //         string result = "";
        //         foreach (Language lang in languages)
        //         {
        //             result += language.Name + ", ";
        //         }
        //         return result.TrimEnd(',', ' ');
        //     }
        // }

        static public void nameValidation(ref string name, object value)
        {
            name = "Placeholder";
            if (!(value is string))
                Console.WriteLine("Value assigned must be a string.");
            else if (value.ToString() == null || value.ToString().Length < 3)
                Console.WriteLine("Invalid name. Length must greater than 3.");
            else
                name = value.ToString();
        }

        // Enum
        public enum GDPP
        {
            SuperPoor = 5,
            Poor = 10,
            Medium = 15,
            Rich = 20,
            SuperRich = 25
        }

        // Patern matching C# 9.0 testing
        public static string CheckWealthOnGDPP(double GDP) => GDP switch
        {
            < (double) GDPP.SuperPoor => "Super Poor",
            < (double) GDPP.Poor => "Poor",
            < (double) GDPP.Medium => "Medium",
            < (double) GDPP.Rich => "Rich",
            < (double) GDPP.SuperRich => "Super Rich",
            _ => "Hyper Rich"
        }; 
    }
}
