using System;
using System.Collections.Generic;

namespace FoodComposition
{
    public enum Nutrient
    {
        EnergyWithFibre,
        EnergyWithoutFibre,
        Water,
        Protein,
        Nitrogen,
        TotalFat,
        Ash,
        TotalDietaryFibre,
        Alcohol,
        Fructose,
        Glucose,
        Sucrose,
        Maltose,
        Lactose,
        Galactose,
        Maltotriose,
        TotalSugars,
        AddedSugars,
        FreeSugars,
        Starch,
        ResistantStarch,
        AvailableCarbohydratesWithoutSugarAlcohols,
        AvailableCarbohydratesWithSugarAlcohols,
        OxalicAcid,
        Aluminium,
        Arsenic,
        Cadmium,
        Calcium,
        Chromium,
        Copper,
        Fluoride,
        Iodine,
        Iron,
        Lead,
        Magnesium,
        Manganese,
        Mercury,
        Molybdenum,
        Nickel,
        Phosphorus,
        Potassium,
        Selenium,
        Sodium,
        Sulphur,
        Tin,
        Zinc,
        Retinol,
        VitaminE, Null
    };

    public class NutrientFactory
    {
        public Dictionary<string, Nutrient> Nutrients { get; }
        public static NutrientFactory Default { get; } = new NutrientFactory(new Dictionary<string, Nutrient>()
        {
            {"Energy, with dietary fibre", Nutrient.EnergyWithFibre},
            {"Energy, without dietary fibre", Nutrient.EnergyWithoutFibre},
            {"Moisture (water)", Nutrient.Water},
            {"Protein", Nutrient.Protein},
            {"Nitrogen", Nutrient.Nitrogen},
            {"Total Fat", Nutrient.TotalFat},
            {"Ash", Nutrient.Ash},
            {"Total dietary fibre", Nutrient.TotalDietaryFibre},
            {"Alcohol", Nutrient.Alcohol},
            {"Fructose", Nutrient.Fructose},
            {"Glucose", Nutrient.Glucose},
            {"Sucrose", Nutrient.Sucrose},
            {"Maltose", Nutrient.Maltose},
            {"Lactose", Nutrient.Lactose},
            {"Galactose", Nutrient.Galactose},
            {"Maltotriose", Nutrient.Maltotriose},
            {"Total sugars", Nutrient.TotalSugars},
            {"Added sugars", Nutrient.AddedSugars},
            {"Free sugars", Nutrient.FreeSugars},
            {"Starch", Nutrient.Starch},
            {"Resistant starch", Nutrient.ResistantStarch},
            {"Available carbohydrate, without sugar alcohols", Nutrient.AvailableCarbohydratesWithoutSugarAlcohols},
            {"Available carbohydrate, with sugar alcohols", Nutrient.AvailableCarbohydratesWithSugarAlcohols},
            {"Oxalic acid", Nutrient.OxalicAcid},
            {"Aluminium (Al)", Nutrient.Aluminium},
            {"Arsenic (As)", Nutrient.Arsenic},
            {"Cadmium (Cd)", Nutrient.Cadmium},
            {"Calcium (Ca)", Nutrient.Calcium},
            {"Chromium (Cr)", Nutrient.Chromium},
            {"Copper (Cu)", Nutrient.Copper},
            {"Fluoride (F)", Nutrient.Fluoride},
            {"Iodine (I)", Nutrient.Iodine},
            {"Iron (Fe)", Nutrient.Iron},
            {"Lead (Pb)", Nutrient.Lead},
            {"Magnesium (Mg)", Nutrient.Magnesium},
            {"Manganese (Mn)", Nutrient.Manganese},
            {"Mercury (Hg)", Nutrient.Mercury},
            {"Molybdenum (Mo)", Nutrient.Molybdenum},
            {"Nickel (Ni)", Nutrient.Nickel},
            {"Phosphorus (P)", Nutrient.Phosphorus},
            {"Potassium (K)", Nutrient.Potassium},
            {"Selenium (Se)", Nutrient.Selenium},
            {"Sodium (Na)", Nutrient.Sodium},
            {"Sulphur (S)", Nutrient.Sulphur},
            {"Tin (Sn)", Nutrient.Tin},
            {"Zinc (Zn)", Nutrient.Zinc},
            {"Retinol (preformed vitamin A)", Nutrient.Retinol},
            {"Vitamin E", Nutrient.VitaminE}
        });

        public NutrientFactory(Dictionary<string,Nutrient> nutrients)
        {
            Nutrients = nutrients ?? throw new ArgumentNullException(nameof(nutrients));
        }

        public Nutrient Lookup(string key)
        {
            if (!Nutrients.ContainsKey(key))
            {
                return Nutrient.Null;
            }
            
            return Nutrients[key];
        }
    }
}