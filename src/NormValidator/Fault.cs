namespace NormValidator
{
    public class Fault<T>
    {
        private readonly T? _value = default(T);
        private readonly string _message = string.Empty;

        public Fault(T value)
        {
            _value = value;
        }

        public Fault(T value, string message)
        {
            _value = value;
            _message = message;
        }

        public T? Value => _value;
        public string Message => _message;

        public override string ToString() => _message;
    }
}
