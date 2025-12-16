---
title: IAuditable
uid: geaux.sharedkernal.entities.iauditable
---

# IAuditable

Interface for audit trail support.  
Provides UTC timestamps for creation and last modification.

```csharp
public interface IAuditable
{
    DateTime CreatedOn { get; }
    DateTime? ModifiedOn { get; }
}
