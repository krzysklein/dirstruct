using System.IO;
using ModelDirectory = dirstruct.Model.Directory;

namespace dirstruct.Writers;

public class FilesysWriter(Options options) : IDirectoryStructureWriter
{
    public Options Options { get; } = options;

    public void WriteDirectoryStructure(ModelDirectory? directory)
    {
        var dirInfo = new DirectoryInfo(Options.OutputPath!);
        CreateDirectoryStructure(dirInfo, directory);
    }

    private static void CreateDirectoryStructure(DirectoryInfo dirInfo, ModelDirectory? directory)
    {
        if (directory is null)
        {
            return;
        }

        if (!string.IsNullOrWhiteSpace(directory.Name))
        {
            dirInfo = dirInfo.CreateSubdirectory(directory.Name);
        }

        foreach (var subDir in directory.Children)
        {
            CreateDirectoryStructure(dirInfo, subDir);
        }
    }
}
