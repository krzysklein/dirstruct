using CommandLine;
using dirstruct;
using dirstruct.Readers;
using dirstruct.Writers;
using EnumsNET;
using System;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(options =>
    {
        var readerType = options.Input.GetAttributes()!.Get<Options.ImplementationTypeAttribute>()!.Type;
        var reader = Activator.CreateInstance(readerType, options) as IDirectoryStructureReader;

        var writerType = options.Output.GetAttributes()!.Get<Options.ImplementationTypeAttribute>()!.Type;
        var writer = Activator.CreateInstance(writerType, options) as IDirectoryStructureWriter;

        var dir = reader!.ReadDirectoryStructure();
        writer!.WriteDirectoryStructure(dir);
    });
;