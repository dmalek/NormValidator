namespace NormValidator.Test
{
    public class CompettitionFaults : FaultType
    {
        public static CompettitionFaults InvalidData = new CompettitionFaults(nameof(InvalidData), 100);

        public static CompettitionFaults AgeLimit = new CompettitionFaults(nameof(AgeLimit), 200);

        public static CompettitionFaults NotSport = new CompettitionFaults(nameof(NotSport), 300);

        public static CompettitionFaults PlayerSuspended = new CompettitionFaults(nameof(PlayerSuspended), 310);

        #region Custom fault properies
        public int Code { get; set; }
        public string  Message { get; set; }
        private CompettitionFaults(string name) : base(name)
        {
        }

        private CompettitionFaults(string name, int code) : base(name)
        {
            Code = code;
            Message = string.Empty;
        }

        private CompettitionFaults(string name, int code, string message) : base(name)
        {
            Code = code;
            Message = message;
        }

        #endregion
    }
}
