using System;
using System.Collections.Generic;

namespace FoodComposition
{
    public enum Unit { Kj, Gram, Microgram, Milligram }
    
    public class UnitFactory
    {
        //TODO: create a generic factory type by merging unit and nutrient factories together
        public Dictionary<string, Unit> Units { get; }
        public static UnitFactory Default { get; } = new UnitFactory(new Dictionary<string, Unit>()
        {
            {"kJ", Unit.Kj},
            {"g", Unit.Gram},
            {"ug", Unit.Microgram},
            {"mg", Unit.Milligram}
        });

        private UnitFactory(Dictionary<string,Unit> units)
        {
            Units = units;
        }

        public Unit Lookup(string key)
        {
            return Units[key];
        }
    }

}