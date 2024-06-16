using System;

namespace dirstruct.Writers;

public class ConsoleWriter(Options options) : AbstractTextWriter(options, Console.Out, Format)
{
    private static readonly AbstractTextWriterFormatOptions Format = new()
    {
        AddHyphen = true
    };
}
