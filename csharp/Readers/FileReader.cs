using System.Collections.Generic;
using System.IO;
using System.Linq;
using ModelDirectory = dirstruct.Model.Directory;

namespace dirstruct.Readers;

public class FileReader(Options options) : IDirectoryStructureReader
{
    public Options Options { get; } = options;

    public ModelDirectory? ReadDirectoryStructure()
    {
        using var reader = new StreamReader(Options.InputPath!);
        var root = new ModelDirectory("");
        string? line;
        var indentedDirsLookup = new Dictionary<int, ModelDirectory>();

        // Read input line-by-line
        while ((line = reader.ReadLine()) is not null)
        {
            // Parse indent and name, skip if only whitespaces found
            var (indent, name) = GetIndentAndName(line);
            if (indent < 0)
            {
                continue;
            }

            // Create directory node
            var dir = new ModelDirectory(name!);

            // Find parent in lookup map
            var parentIndents = indentedDirsLookup.Keys
                .Where(x => x < indent)
                .ToArray();
            var parent = (parentIndents.Length > 0)
                ? indentedDirsLookup[parentIndents.Max()]
                : root;

            // Attach to parent
            parent.AddChild(dir);

            // Add to lookup map
            indentedDirsLookup[indent] = dir;
        }

        return root;
    }

    private static (int, string?) GetIndentAndName(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (!char.IsWhiteSpace(line[i]))
            {
                return (i, line.Substring(i));
            }
        }

        return (-1, null);
    }
}
