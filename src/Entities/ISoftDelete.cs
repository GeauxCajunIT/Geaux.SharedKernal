// // <copyright company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.Entities;

public interface ISoftDelete
{
    /// <summary>Flag indicating whether the entity is soft deleted.</summary>
    bool IsDeleted { get; }
}
