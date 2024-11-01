namespace DependencyTree.Models;

using System.Collections.Generic;
using System.Linq;

internal sealed class AssemblyReferenceInfo
{
    public required string Name { get; init; }
    public List<AssemblyReferenceInfo> References { get; } = new();

    public int DependencyDepth => this.References.Count == 0
        ? 0
        : this.References.Max(r => r.DependencyDepth) + 1;

    public IEnumerable<AssemblyReferenceInfo> Flatten()
    {
        yield return this;
        foreach (AssemblyReferenceInfo reference in this.References.SelectMany(r => r.Flatten()))
        {
            yield return reference;
        }
    }

    private bool Equals(AssemblyReferenceInfo other) => this.Name == other.Name;

    public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is AssemblyReferenceInfo other && this.Equals(other);

    public override int GetHashCode() => this.Name.GetHashCode();
}