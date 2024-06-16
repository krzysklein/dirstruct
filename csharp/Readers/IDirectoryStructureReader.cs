using dirstruct.Model;

namespace dirstruct.Readers;

public interface IDirectoryStructureReader
{
    Directory? ReadDirectoryStructure();
}