using System.IO;

namespace dirstruct.Writers;

public class FileWriter(Options options) : AbstractTextWriter(options, new StreamWriter(options.OutputPath!), Format)
{
    private static readonly AbstractTextWriterFormatOptions Format = new()
    {
        AddHyphen = false
    };
}