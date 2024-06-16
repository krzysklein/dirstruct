using CommandLine;
using System;

namespace dirstruct;

public class Options
{
    [Option('i', "input", Default = InputType.filesys, HelpText = "Input type")]
    public InputType Input { get; set; }

    [Value(0, MetaName = "Input", Default = ".", HelpText = "Input path")]
    public string? InputPath { get; set; }

    [Option('o', "output", Default = OutputType.console, HelpText = "Output type")]
    public OutputType Output { get; set; }

    [Value(1, MetaName = "Output", HelpText = "Output path")]
    public string? OutputPath { get; set; }

    [Option("indent-spaces", Default = 2, HelpText = "Num of spaces treated as unit of indent")]
    public int IndentSpaces { get; set; }

    public enum InputType
    {
        [ImplementationType(typeof(Readers.FilesysReader))]
        filesys,

        [ImplementationType(typeof(Readers.FileReader))]
        file
    }

    public enum OutputType
    {
        [ImplementationType(typeof(Writers.FilesysWriter))]
        filesys,

        [ImplementationType(typeof(Writers.FileWriter))]
        file,

        [ImplementationType(typeof(Writers.ConsoleWriter))]
        console
    }

    public class ImplementationTypeAttribute(Type type) : Attribute
    {
        public Type Type { get; } = type;
    }
}
