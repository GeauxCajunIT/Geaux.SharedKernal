// // <copyright company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.SharedKernal.Entities;

using System;

public interface IAuditable
{
    /// <summary>UTC timestamp when the entity was created.</summary>
    DateTime CreatedOn { get; }

    /// <summary>UTC timestamp when the entity was last modified.</summary>
    DateTime? ModifiedOn { get; }

}
