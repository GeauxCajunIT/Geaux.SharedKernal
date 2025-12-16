// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.Entities;

/// <summary>
/// NOTE: Use `readonly record struct` for most cases in C# 10+
/// See: https://nietras.com/2021/06/14/csharp-10-record-struct/
/// 
/// For this class implementation, reference:
/// See: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
/// </summary>
[Serializable]
public abstract class ValueObject : IComparable, IComparable<ValueObject>
{
    private int? _cachedHashCode;

    /// <summary>
    /// Gets the components used to determine equality for the value object.
    /// </summary>
    protected abstract IEnumerable<object> GetEqualityComponents();


    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }


    /// <inheritdoc />
    public override int GetHashCode()
    {
        if (!_cachedHashCode.HasValue)
        {
            _cachedHashCode = GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        return _cachedHashCode.Value;
    }


    /// <inheritdoc />
    public int CompareTo(object? obj)
    {
        if (obj == null)
            return 1;

        var thisType = GetUnproxiedType(this);
        var otherType = GetUnproxiedType(obj);

        if (thisType != otherType)
            return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);

        var other = (ValueObject)obj;

        var components = GetEqualityComponents().ToArray();
        var otherComponents = other.GetEqualityComponents().ToArray();

        for (var i = 0; i < components.Length; i++)
        {
            var comparison = CompareComponents(components[i], otherComponents[i]);
            if (comparison != 0)
                return comparison;
        }

        return 0;
    }

    private static int CompareComponents(object? object1, object? object2)
    {
        if (object1 is null && object2 is null)
            return 0;

        if (object1 is null)
            return -1;

        if (object2 is null)
            return 1;

        if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
            return comparable1.CompareTo(comparable2);

        return object1.Equals(object2) ? 0 : -1;
    }


    /// <inheritdoc />
    public int CompareTo(ValueObject? other)
    {
        return CompareTo(other as object);
    }

    /// <summary>
    /// Determines whether one ValueObject instance is less than another.
    /// </summary>
    /// <remarks>Null is considered less than any non-null ValueObject. This operator relies on the CompareTo
    /// implementation of ValueObject for non-null comparisons.</remarks>
    /// <param name="left">The first ValueObject to compare, or null.</param>
    /// <param name="right">The second ValueObject to compare, or null.</param>
    /// <returns>true if left is less than right; otherwise, false. If left is null and right is not null, returns true. If both
    /// are null, returns false.</returns>
    public static bool operator <(ValueObject? left, ValueObject? right)
    {
        if (left is null)
        {
            // null is considered less than any non-null
            return right is not null;
        }

        return left.CompareTo(right) < 0;
    }

    /// <summary>
    /// Determines whether one <see cref="ValueObject"/> instance is greater than another.
    /// </summary>
    /// <remarks>If <paramref name="left"/> is <see langword="null"/>, the result is always false. Comparison
    /// is performed using the <see cref="ValueObject.CompareTo(ValueObject?)"/> method.</remarks>
    /// <param name="left">The first <see cref="ValueObject"/> to compare, or <see langword="null"/>.</param>
    /// <param name="right">The second <see cref="ValueObject"/> to compare, or <see langword="null"/>.</param>
    /// <returns>true if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, false.</returns>
    public static bool operator >(ValueObject? left, ValueObject? right)
    {
        if (left is null)
        {
            // null is never greater than anything
            return false;
        }

        return left.CompareTo(right) > 0;
    }

    /// <summary>
    /// Determines whether one ValueObject instance is less than or equal to another.
    /// </summary>
    /// <remarks>Null is considered less than or equal to any ValueObject instance.</remarks>
    /// <param name="left">The first ValueObject to compare, or null.</param>
    /// <param name="right">The second ValueObject to compare, or null.</param>
    /// <returns>true if left is less than or equal to right; otherwise, false. If left is null, returns true.</returns>
    public static bool operator <=(ValueObject? left, ValueObject? right)
    {
        if (left is null)
        {
            // null is less than or equal to anything
            return true;
        }

        return left.CompareTo(right) <= 0;
    }

    /// <summary>
    /// Determines whether one ValueObject instance is greater than or equal to another.
    /// </summary>
    /// <remarks>Null is considered equal only to null. If left is null and right is not null, the result is
    /// false.</remarks>
    /// <param name="left">The first ValueObject to compare. Can be null.</param>
    /// <param name="right">The second ValueObject to compare. Can be null.</param>
    /// <returns>true if left is greater than or equal to right; otherwise, false. If both left and right are null, returns true.</returns>
    public static bool operator >=(ValueObject? left, ValueObject? right)
    {
        if (left is null)
        {
            // null is only >= null
            return right is null;
        }

        return left.CompareTo(right) >= 0;
    }

    private static Type GetUnproxiedType(object obj)
    {
        const string EFCoreProxyPrefix = "Castle.Proxies.";
        const string NHibernateProxyPostfix = "Proxy";

        var type = obj.GetType();
        var typeString = type.ToString();

        if (typeString.Contains(EFCoreProxyPrefix, StringComparison.Ordinal) ||
            typeString.EndsWith(NHibernateProxyPostfix, StringComparison.Ordinal))
        {
            return type.BaseType!;
        }

        return type;
    }

    /// <summary>
    /// Determines whether two value objects are equal.
    /// </summary>
    /// <param name="left">The first value object to compare.</param>
    /// <param name="right">The second value object to compare.</param>
    /// <returns>
    /// <see langword="true"/> if both value objects are equal or both are <see langword="null"/>;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two value objects are not equal.
    /// </summary>
    /// <param name="left">The first value object to compare.</param>
    /// <param name="right">The second value object to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the value objects are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(ValueObject? left, ValueObject? right) => !(left == right);

}

