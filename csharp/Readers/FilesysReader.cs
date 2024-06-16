using System.IO;
using ModelDirectory = dirstruct.Model.Directory;

namespace dirstruct.Readers;

public class FilesysReader(Options options) : IDirectoryStructureReader
{
    public Options Options { get; } = options;

    public ModelDirectory? ReadDirectoryStructure()
    {
        var dirInfo = new DirectoryInfo(Options.InputPath!);
        return ParseDirectoryStructure(dirInfo);
    }

    private static ModelDirectory? ParseDirectoryStructure(DirectoryInfo dirInfo, ModelDirectory? parent = null)
    {
        if (!dirInfo.Exists)
        {
            return null;
        }

        var dir = new ModelDirectory(dirInfo.Name, parent);

        foreach (var subDirInfo in dirInfo.EnumerateDirectories())
        {
            var subDir = ParseDirectoryStructure(subDirInfo, dir);
            if (subDir is not null)
            {
                dir.AddChild(subDir);
            }
        }

        return dir;
    }
}
