using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FoodComposition
{
    [TestFixture]
    public class NutrientFactoryTest
    {
        [Test]
        public void TestConstructNutrientFactoryWithDictionaryOfNutrients()
        {
            var nutrients = new Dictionary<string, Nutrient>()
            {
                {"Energy, with dietary fibre", Nutrient.EnergyWithFibre},
                {"Energy, without dietary fibre", Nutrient.EnergyWithoutFibre},
                {"Moisture (water)", Nutrient.Water}
            };

            var nutrientFactory = new NutrientFactory(nutrients);
            nutrientFactory.Nutrients.Should().BeEquivalentTo(nutrients);
        }

        [Test]
        public void TestConstructNutrientFactoryWithDictionaryCantBeNull()
        {
            Action action = () => new NutrientFactory(null);

            action.Should().Throw<ArgumentNullException>().WithMessage("*Parameter name: nutrients*");
        }

        //TODO: Handle case where field name repeats due to % and unit being used. Throw away %?
        [Test]
        public void TestDefaultNutrientFactoryAssembledWithCompleteListOfNutrients()
        {
            var expectedNutrients = new Dictionary<string, Nutrient>()
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
            };
            NutrientFactory.Default.Nutrients.Should().BeEquivalentTo(expectedNutrients);
        }

        [TestCase("Energy, with dietary fibre", Nutrient.EnergyWithFibre)]
        [TestCase("Energy, without dietary fibre", Nutrient.EnergyWithoutFibre)]
        [TestCase("Moisture (water)", Nutrient.Water)]
        [TestCase("Mercury (Hg)", Nutrient.Mercury)]
        public void TestLookupNutrient(string key, Nutrient expected)
        {
            NutrientFactory.Default.Lookup(key).Should().Be(expected);
        }

        [Test]
        public void TestLookupNutrientHandlesNull()
        {
            Action action = () => NutrientFactory.Default.Lookup(null);
            
            action.Should().Throw<ArgumentNullException>().WithMessage("*Parameter name: key*");
        }

        [Test]
        public void TestReturnsNullIfNotFound()
        {
            NutrientFactory.Default.Lookup("missing").Should().Be(Nutrient.Null);
        }
    }
}