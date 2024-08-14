namespace DependencyTree;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using CommandLine;
using DependencyTree.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
    }

    private static void Run(Options options)
    {
        try
        {
            AssemblyReferenceInfo rootAssembly =
                GetReferenceInfo(options.AssemblyPath, options) ??
                throw new InvalidOperationException("Root assembly not found.");

            if (options.OutputFormat == OutputFormat.Text)
            {
                OutputAsText(rootAssembly);
            }
            else if (options.OutputFormat == OutputFormat.DOT)
            {
                OutputAsDOT(rootAssembly);
            }
            else
            {
                throw new InvalidOperationException("Invalid output format.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Environment.Exit(1);
        }
    }

    [UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "This function uses reflection, but not on itself.")]
    private static AssemblyReferenceInfo? GetReferenceInfo(string assemblyPath, Options options)
    {
        if (!File.Exists(assemblyPath))
        {
            return null;
        }

        Assembly assembly = Assembly.LoadFrom(assemblyPath);
        AssemblyReferenceInfo assemblyInfo = new()
        {
            Name = assembly.GetName().Name ?? throw new InvalidOperationException("Assembly name not found.")
        };

        string assemblyDirectory =
            Path.GetDirectoryName(assemblyPath) ??
            throw new InvalidOperationException("Assembly directory not found.");

        AssemblyName[] references = assembly.GetReferencedAssemblies();

        foreach (AssemblyName assemblyName in references)
        {
            if (options.AssemblyNameStartsWith is { } startsWith &&
                assemblyName.Name?.StartsWith(startsWith, StringComparison.OrdinalIgnoreCase) != true)
            {
                continue;
            }

            assemblyInfo.References.Add(
                GetReferenceInfo(Path.Combine(assemblyDirectory, $"{assemblyName.Name}.dll"), options) ??
                new AssemblyReferenceInfo { Name = assemblyName.Name ?? throw new InvalidOperationException("Assembly name not found.") });
        }

        return assemblyInfo;
    }

    private static void OutputAsText(AssemblyReferenceInfo assemblyInfo, int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}{assemblyInfo.Name}");
        foreach (AssemblyReferenceInfo reference in assemblyInfo.References)
        {
            OutputAsText(reference, depth + 1);
        }
    }

    private static void OutputAsDOT(AssemblyReferenceInfo rootAssembly)
    {
        List<string> output = new();

        output.Add("digraph G {");
        AddDOTEntries(rootAssembly, output);
        output.Add("}");

        output.ForEach(Console.WriteLine);
    }

    private static void AddDOTEntries(AssemblyReferenceInfo assemblyInfo, List<string> output)
    {
        foreach (AssemblyReferenceInfo reference in assemblyInfo.References)
        {
            string line = $"""  "{assemblyInfo.Name}" -> "{reference.Name}";""";

            if (!output.Contains(line))
            {
                output.Add(line);
            }

            AddDOTEntries(reference, output);
        }
    }
}