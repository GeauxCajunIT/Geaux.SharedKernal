---
title: ValueObject
uid: geaux.sharedkernal.entities.valueobject
---

# ValueObject

Base type for DDD value objects.
Implements equality and comparison semantics based on components.

```csharp
public abstract class ValueObject : IComparable, IComparable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();
    // equality, comparison, operators...
}
```
