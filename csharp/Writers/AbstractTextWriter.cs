using System.IO;
using ModelDirectory = dirstruct.Model.Directory;

namespace dirstruct.Writers;

public abstract class AbstractTextWriter(
    Options options, 
    TextWriter textWriter, 
    AbstractTextWriter.AbstractTextWriterFormatOptions formatOptions) 
    : IDirectoryStructureWriter
{
    public Options Options { get; } = options;
    public TextWriter TextWriter { get; } = textWriter;
    public AbstractTextWriterFormatOptions FormatOptions { get; } = formatOptions;

    public class AbstractTextWriterFormatOptions
    {
        public bool AddHyphen { get; set; }
    }

    public void WriteDirectoryStructure(ModelDirectory? directory)
    {
        WriteDirectoryStructure(directory, 0);
    }

    private void WriteDirectoryStructure(ModelDirectory? directory, int indent)
    {
        if (directory is null)
        {
            return;
        }

        WriteIndent(indent);
        if (FormatOptions.AddHyphen)
        {
            TextWriter.Write("- ");
        }
        TextWriter.WriteLine(directory.Name);

        foreach (var subDir in directory.Children)
        {
            WriteDirectoryStructure(subDir, indent + Options.IndentSpaces);
        }
    }

    private void WriteIndent(int indent)
    {
        for (int i = 0; i < indent; i++)
        {
            TextWriter.Write(' ');
        }
    }
}
