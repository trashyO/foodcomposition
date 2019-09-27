namespace FoodComposition
{
    public class Value
    {
        public double Amount { get; }
        public Unit Unit { get; }
        
        public Value(double amount, Unit unit)
        {
            Amount = amount; 
            Unit = unit;
        }

        //TODO: add tests that check the alternate flows for referenceequals etc.
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            Value other = (Value) obj;
            return Amount.Equals(other.Amount) && Unit == other.Unit;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ (int) Unit;
            }
        }
    }
}