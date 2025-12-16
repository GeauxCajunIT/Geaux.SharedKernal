---
title: ISoftDelete
uid: geaux.sharedkernal.entities.isoftdelete
---

# ISoftDelete

Interface for soft delete support.  
Provides a flag indicating logical deletion.

```csharp
public interface ISoftDelete
{
    bool IsDeleted { get; }
}