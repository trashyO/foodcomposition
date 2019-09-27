using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using System.Xml.Linq;

namespace FoodComposition
{
    [TestFixture]
    public class FoodFactoryTest
    {
        private string _lineCsv;
        private string _headerCsv;
        private string _unitsCsv;

        [SetUp]
        public void Setup()
        {
            _lineCsv = "F002258,31302,\"Cardamom seed, dried, ground\",1236,1012,8.3,10.8,1.72,6.7,5.8,28";
            _headerCsv = "Public Food Key,Classification,Food Name,\"Energy, with dietary fibre\",\"Energy, without dietary fibre\",Moisture (water),Protein,Nitrogen,Total Fat,Ash,Total dietary fibre";
            _unitsCsv = "g,g,g,kJ,kJ,g,g,g,g,g,g";
        }
        [TestCase]
        public void TestFoodFactoryMethodCreateSuccessfullyConstructsNewFood()
        {
            var  expectedNutrients = new Dictionary<Nutrient, Value>()
            {
                {Nutrient.EnergyWithFibre, new Value(1236, Unit.Kj)},
                {Nutrient.EnergyWithoutFibre, new Value(1012, Unit.Kj)},
                {Nutrient.Water, new Value(8.3, Unit.Gram)},
                {Nutrient.Protein, new Value(10.8, Unit.Gram)},
                {Nutrient.Nitrogen, new Value(1.72, Unit.Gram)},
                {Nutrient.TotalFat, new Value(6.7, Unit.Gram)},
                {Nutrient.Ash, new Value(5.8, Unit.Gram)},
                {Nutrient.TotalDietaryFibre, new Value(28, Unit.Gram)}
                };
            
            Food expected = new Food("F002258", "31302", "Cardamom seed, dried, ground", expectedNutrients);
            Food actual = FoodFactory.Instance.Create(_lineCsv, _headerCsv, _unitsCsv);
            
            actual.Should().NotBeNull("Create constructor called");
            actual.PublicFoodKey.Should().Be(expected.PublicFoodKey);
            actual.Category.Should().Be(expected.Category);
            actual.Description.Should().Be(expected.Description);

            actual.Nutrients.Count.Should().Be(expectedNutrients.Count);
            actual.Nutrients.Should().Equal(expectedNutrients);
        }

        [TestCase]
        public void TestFactoryMethodCreateSuccessfullyHandlesZeroValues()
        {
            _lineCsv = "F002258,31302,\"Cardamom seed, dried, ground\",0,1012,8.3,10.8,1.72,6.7,5.8,28";

            var  expectedNutrients = new Dictionary<Nutrient, Value>()
            {
                {Nutrient.EnergyWithFibre, new Value(0, Unit.Kj)},
            };
            
            Food actual = FoodFactory.Instance.Create(_lineCsv, _headerCsv, _unitsCsv);

            actual.Nutrients[Nutrient.EnergyWithFibre].Should().Be(expectedNutrients[Nutrient.EnergyWithFibre]);
        }
        
        [TestCase]
        public void TestFactoryMethodCreateSuccessfullyHandlesAllNullValues()
        {
            _lineCsv = "F002258,31302,\"Cardamom seed, dried, ground\",,,,,,,,";

            //TODO: figure out how to refactor to use Nullable<T> 
            var  expectedNutrients = new Dictionary<Nutrient, Value>()
            {
                {Nutrient.EnergyWithFibre, null},
                {Nutrient.EnergyWithoutFibre, null},
                {Nutrient.Water, null},
                {Nutrient.Protein, null},
                {Nutrient.Nitrogen, null},
                {Nutrient.TotalFat, null},
                {Nutrient.Ash, null},
                {Nutrient.TotalDietaryFibre, null}
                };
            
            Food actual = FoodFactory.Instance.Create(_lineCsv, _headerCsv, _unitsCsv);

            actual.Nutrients.Count.Should().Be(expectedNutrients.Count);
            actual.Nutrients.Should().Equal(expectedNutrients);
        }

        [TestCase]
        public void TestFactoryMethodCreateFailsIfCsvInputIsOfDifferentLengths()
        {
            _unitsCsv = "g,g,g,kJ,kJ,g,g,g,g,g";

            Action action = () => FoodFactory.Instance.Create(_lineCsv, _headerCsv, _unitsCsv);

            action.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Input arguments have different field lengths. lineCSV: 11, headerCSV: 11, unitCSV: 10");

        }
        
    }
}