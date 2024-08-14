# DependencyTree

DependencyTree is a command-line tool for analyzing and visualizing the dependencies of .NET assemblies. It supports output in both text and DOT formats.

The DOT output can be visualized using tools like [Graphviz Online](https://dreampuf.github.io/GraphvizOnline). The result looking something like this:

![Example DOT output](https://private-user-images.githubusercontent.com/5099690/357863673-3e685e9b-0e1b-41b1-89ba-c52f7e992f91.svg?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjM2NDYxOTEsIm5iZiI6MTcyMzY0NTg5MSwicGF0aCI6Ii81MDk5NjkwLzM1Nzg2MzY3My0zZTY4NWU5Yi0wZTFiLTQxYjEtODliYS1jNTJmN2U5OTJmOTEuc3ZnP1gtQW16LUFsZ29yaXRobT1BV1M0LUhNQUMtU0hBMjU2JlgtQW16LUNyZWRlbnRpYWw9QUtJQVZDT0RZTFNBNTNQUUs0WkElMkYyMDI0MDgxNCUyRnVzLWVhc3QtMSUyRnMzJTJGYXdzNF9yZXF1ZXN0JlgtQW16LURhdGU9MjAyNDA4MTRUMTQzMTMxWiZYLUFtei1FeHBpcmVzPTMwMCZYLUFtei1TaWduYXR1cmU9MjQ1MWQyNDA0NjA1N2JiMmZiMGViMWU4ODEwZDIyMDk5ZWQ3MmJjYTdjNzMyMTZmMjdkNTcwNzE1ZWRiZjkyMiZYLUFtei1TaWduZWRIZWFkZXJzPWhvc3QmYWN0b3JfaWQ9MCZrZXlfaWQ9MCZyZXBvX2lkPTAifQ.Fz4X2gAH0ec7IfUNCMTtb305uNVJ4BW_oPonr6u5eJk)

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
DependencyTree -p <assembly-path> [-s <starts-with>] [-f <output-format>]
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
