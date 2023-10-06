namespace NormValidator.Test
{
    public class CompettitionFaults : FaultType
    {
        public static CompettitionFaults InvalidData = new CompettitionFaults(nameof(InvalidData));

        public static CompettitionFaults AgeLimit = new CompettitionFaults(nameof(AgeLimit));

        public static CompettitionFaults NotSport = new CompettitionFaults(nameof(NotSport));

        public static CompettitionFaults PlayerSuspended = new CompettitionFaults(nameof(PlayerSuspended));

        private CompettitionFaults(string name) : base(name)
        {
        }    
    }
}
