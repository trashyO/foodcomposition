using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FoodComposition
{
    public class Food
    {
        public string PublicFoodKey { get; }
        public string Category { get; }
        public string Description { get; }
        public Dictionary<Nutrient, Value> Nutrients { get; }
        
        public Food(string publicFoodKey, string category, string description, Dictionary<Nutrient,Value> nutrients)
        {
            PublicFoodKey = publicFoodKey;
            Category = category;
            Description = description;
            Nutrients = nutrients;
        }
        
        public static Value IsEmpty(string field, Unit unit)
        {
            if (field.Equals(String.Empty))
            {
                return null;
            }

            return new Value(double.Parse(field), unit);
        }

        public override string ToString()
        {
            return
                $"Key: {PublicFoodKey} Category: {Category} Description: {Description} Mercury: {Nutrients[Nutrient.Mercury].Amount} {Nutrients[Nutrient.Mercury].Unit}";
        }
    }
}