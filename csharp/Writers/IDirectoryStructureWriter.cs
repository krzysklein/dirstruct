using dirstruct.Model;

namespace dirstruct.Writers;

public interface IDirectoryStructureWriter
{
    void WriteDirectoryStructure(Directory? directory);
}