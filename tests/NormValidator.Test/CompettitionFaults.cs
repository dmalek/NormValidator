namespace NormValidator.Test
{
    public class CompettitionFaults : FaultType
    {
        public static CompettitionFaults InvalidData = new CompettitionFaults(nameof(InvalidData));

        public static CompettitionFaults AgeLimit = new CompettitionFaults(nameof(AgeLimit));
        
        private CompettitionFaults(string name) : base(name)
        {
        }    
    }
}
