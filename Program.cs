using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoodComposition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var reader = new StreamReader(
                @"/Users/tracey.steinbach/RiderProjects/FoodComposition/FoodComposition/data/NutrientCSV/All solids & liquids per 100g-Table 1.csv")
            )
            {
                var header = reader.ReadLine();
                var units = reader.ReadLine();
                
                var foodDatabase = new List<Food>();
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Food food = FoodFactory.Instance.Create(line, header, units);
                    foodDatabase.Add(food);
                }

                //Move to query object
                var queryForMercuryInFood = foodDatabase.Where(food => food.Nutrients[Nutrient.Mercury] != null && food.Nutrients[Nutrient.Mercury].Amount != 0).OrderBy(food => food.Nutrients[Nutrient.Mercury].Amount)
                    .Select(food => food);

                foreach (var food in queryForMercuryInFood)
                {
                    Console.WriteLine(food);
                }
            }
        }
    }
}