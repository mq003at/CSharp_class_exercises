using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Program1
{
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
            var Finland = new Country("Finland", 5);
            // Country.HasBorder(Finland);
            // Country.HasBorder("Finland");
            // Country.CheckWealth(Finland);
            // var FinCities = Finland[0..4];
            // var FirstCity = Finland[0];
            /* Write methods to print FinCities and FirstCity */

            //Challenge 2
            /* write your own game */
        }

        class Country
        {
            /* provide your code for challenge 1 here */
            private string _name,
                _region;
            private City _capitalCity;
            private City[] _cities;
            public int Population { get; set; }
            public int GDP { get; set; }
            public City CapitalCity { get; set; }
            public List<Country> BorderCountry { get; set; }

            // public string capitalCity
            // {
            //     get { return _capitalCity.Name; }
            //     set { _capitalCity = value; }
            // }

            // Should we encapsulate languages more?
            public List<Language> Language { get; set; }

            // Constructor
            public Country(string name, int numberOfCities)
            {
                _name = name;
                _cities = new City[numberOfCities];
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

            // Get/set Language
            // public Language this[Index index]
            // {
            //     get
            //     {
            //         if (index < 0 || index >= Language.Count())
            //             Console.WriteLine("Out of range.");
            //         else
            //             return Language[index];
            //     }
            //     set
            //     {
            //         if (index < 0 || index >= Language.Count())
            //             Console.WriteLine("Out of range.");
            //         else
            //             Language[index] = value;
            //     }
            // }

            // Get/set Cities
            public City this[int i]
            {
                get { return _cities[i]; }
                set { _cities[i] = value; }
            }

            // HasBorder: params can be Country object or a string
            static void HasBorder(Country country) { }

            static void HasBorder(string countryName)
            {
                foreach (Country country in BorderCountry)
                {
                    if (country.Name == countryName)
                    {
                        Console.WriteLine();
                        return;
                    }
                }
                Console.WriteLine(
                    $"Country {_name} doesn't share a border with country {countryName}."
                );
            }
        }

        // Each city has a name, is a capital city and population
        public struct City
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

            // Implicit operator to convert City struct to string when it is called in Country
            public static implicit operator string(City city)
            {
                return city.Name;
            }
        }

        public struct Language
        {
            public string Name { get; set; }
            public bool IsDefault { get; set; }

            public Language(string name, bool isDefault)
            {
                Name = name;
                IsDefault = isDefault;
            }

            // Implicit operator
            public static implicit operator string(Language language)
            {
                return language.Name;
            }
        }

        public void nameValidation(ref string name, object value)
        {
            if (!(value is string))
                Console.WriteLine("Value assigned must be a string.");
            else if (string.IsNullOrEmpty(name) || name.Length < 3)
                Console.WriteLine("Invalid name. Length must greater than 3.");
            else
                name = value.ToString();
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
}
