using System;
using System.Collections.Generic;
using System.Linq;
using RandomDataGenerator.Randomizers;
using RandomDataGenerator.FieldOptions;

namespace zajecia8
{

    public class Person
    {
        public int id;
        public string Name;
        public string Surname;
        public int Age;
        public string Country;
        public Person(int id, string name, string surname, int age, string country)
        {
            this.id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Country = country;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
//            List<int> lista = Enumerable.Range(100, 150).ToList();
//            List<int> podzielnePrzez3 = lista.Where(x => x % 3 == 0).ToList();
//            double mean = podzielnePrzez3.Average();
//            int sum = podzielnePrzez3.Sum();
//            foreach (var item in lista)
//            {
//                Console.WriteLine(item);
//            }
//
//            Console.WriteLine("Srednia: " + mean);
//            Console.WriteLine("Suma: " + sum);
//
//            int nrStrony = 2;
//            int elemNaStronie = 10;
//            var strona = lista.Skip(elemNaStronie * (nrStrony)).Take(elemNaStronie);
//            foreach (var item in strona)
//            {
//                Console.WriteLine(item);
//            }

//            List<Person> people = lista.Select(x =>
//            new Person(){
//                id = x,
//                Name = x.ToString(),
//                Surname = "abc"
//            }).ToList();
//
//            foreach (var person in people)
//            {
//                Console.WriteLine($"{person.id}, {person.Name}, {person.Surname}");
//            }
//
//            List<string> surnames = people.Select(x => x.Surname).ToList();
//            foreach (var surname in surnames)
//            {
//                Console.WriteLine($"{surname}");
//            }

//            people[33].Surname = "cba";
//            Person searched = people.FirstOrDefault(x => x.Surname == "cba");
//            Console.WriteLine($"{searched.id}, {searched.Name}, {searched.Surname}");

            var nameGen = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var surnameGen = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            var ageGen = RandomizerFactory.GetRandomizer(new FieldOptionsByte(){Min = 0, Max = 121});
            var countryGen = RandomizerFactory.GetRandomizer(new FieldOptionsCountry());
            List<Person> persons = Enumerable
                .Range(1, 10000)
                .Select(x => new Person(
                    x, 
                    nameGen.Generate(), 
                    surnameGen.Generate(),
                    ageGen.Generate().Value,
                    countryGen.Generate()
                ))
                .ToList();

//            foreach (var person in persons)
//            {
//                Console.WriteLine($"{person.id}, {person.Name}, {person.Surname}");
//            }
            List<Person> sortedPeople = persons
                .OrderBy(person => person.Surname)
                .ThenBy(person => person.Name)
                .ToList();
            
            foreach (var person in sortedPeople)
            {
                Console.WriteLine(
                    $"{person.id}," +
                    $" nazwisko i imie: {person.Surname} {person.Name}, " +
                    $"age: {person.Age}, country: {person.Country}"
                    ); 
            }
            
            ChoosePeople(persons, "New Zealand", 23, 54);
        }

        static void ChoosePeople(List<Person> people, string country, int minAge, int maxAge)
        {
            List<Person> peopleFromCountry = people.Where(
                person => person.Country == country).ToList();
            List<Person> chosenOnes = peopleFromCountry.Where(
                person => person.Age >= minAge && person.Age <= maxAge).ToList();
            Console.WriteLine("Chosen Ones:");
            foreach (var chosen in chosenOnes)
            {
                Console.WriteLine($"{chosen.Name}, {chosen.Surname}, {chosen.Country}, {chosen.Age}");
            }
        }
    }
}