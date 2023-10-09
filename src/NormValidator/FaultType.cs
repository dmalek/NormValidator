using System.Reflection;

namespace NormValidator;

public abstract class FaultType : IComparable
{
    public string Name { get; private set; }

    protected FaultType(string name) => (Name) = (name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : FaultType =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not FaultType otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Name.Equals(otherValue.Name);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object? other)
    {
        string? otherName = null;
        if (other != null && other is FaultType)
        {
            otherName = ((FaultType)other).Name;
        }

        return Name.CompareTo(otherName);
    } 

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public static bool operator ==(FaultType left, FaultType right)
    {
        if (ReferenceEquals(left, null))
        {
            return ReferenceEquals(right, null);
        }

        return left.Equals(right);
    }

    public static bool operator !=(FaultType left, FaultType right)
    {
        return !(left == right);
    }
}
