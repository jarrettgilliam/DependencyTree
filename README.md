# DependencyTree

DependencyTree is a command-line tool for analyzing and visualizing the dependencies of .NET assemblies. It supports output in both text and DOT formats.

## Features

- Analyze .NET assembly dependencies.
- Output results in text format.
- Output results in DOT format for graph visualization.

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/jarrettgilliam/DependencyTree.git
    cd DependencyTree
    ```

2. Build the project:
    ```sh
    dotnet build
    ```

## Usage

Run the tool with the required options:

```sh
dotnet run --project DependencyTree -- -p <assembly-path> [-s <starts-with>] [-f <output-format>]
```

## Options
* `-p`, `--assembly-path` (required): The path to the root assembly.
* `-s`, `--starts-with`: Only include assemblies whose name starts with this value.
* `-f`, `--output-format`: The output format. Options are Text (default) and DOT.

## Examples

Analyze dependencies and output in text format:

```sh
DependencyTree -p /path/to/your/assembly.dll
```

Analyze dependencies and output in DOT format:

```sh
DependencyTree -p /path/to/your/assembly.dll -f DOT
```
