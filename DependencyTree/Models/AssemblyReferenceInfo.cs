namespace DependencyTree.Models;

using System.Collections.Generic;

internal sealed class AssemblyReferenceInfo
{
    public required string Name { get; init; }
    public List<AssemblyReferenceInfo> References { get; } = new();
}