namespace DependencyTree.Models;

using CommandLine;

internal sealed class Options
{
    [Option('p', "assembly-path", HelpText = "The path to the root assembly.", Required = true)]
    required public string AssemblyPath { get; set; }

    [Option('s', "starts-with", HelpText = "Only include assemblies whose name starts with this value.")]
    public string? AssemblyNameStartsWith { get; set; }

    [Option('f', "output-format", HelpText = "The output format. Options are Text and DOT", Default = Models.OutputFormat.Text)]
    public OutputFormat OutputFormat { get; set; }
}