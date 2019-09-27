using System;
using System.Collections.Generic;

namespace FoodComposition
{
    //TODO: Create a generic factory object and combine FoodFactory with NutrientFactory.
    public class FoodFactory
    {
        public static FoodFactory Instance { get; } = new FoodFactory();

        private FoodFactory()
        {
        }

        //TODO: Figure out how to externalise the dependencies for Nutrient and Food Factory
        public Food Create(string lineCSV, string headerCSV, string unitsCSV)
        {
            var fields = CsvHelper.SplitCSV(lineCSV);
            var header = CsvHelper.SplitCSV(headerCSV);
            var units = CsvHelper.SplitCSV(unitsCSV);

            if (fields.Length != header.Length || fields.Length != units.Length)
            {
                throw new ArgumentOutOfRangeException($"Input arguments have different field lengths. " +
                                                      $"lineCSV: {fields.Length}, headerCSV: {header.Length}, unitCSV: {units.Length}");
            }
            
            var publicFoodKey = fields[0];
            var classification = fields[1];
            var description = fields[2];

            //TODO: we could initialise the dictionary once then just clone it and populate the values for each line.
            var nutrients = new Dictionary<Nutrient, Value>();
                    
            for (int i = 3; i < fields.Length; i++)
            {
                var value = fields[i];

                var nutrient = NutrientFactory.Default.Lookup(header[i]);
                if (nutrient != Nutrient.Null)
                {
                    Console.WriteLine($"Adding Nutrient {nutrient} to the dictionary with index {i} with unit value of {units[i]}");
                    nutrients[nutrient] = Food.IsEmpty(value, UnitFactory.Default.Lookup(units[i]));
                }
            }

            return new Food(publicFoodKey, classification, description, nutrients);
        }
    }
}