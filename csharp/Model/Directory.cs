using System.Collections.Generic;

namespace dirstruct.Model;

public class Directory(string name, Directory? parent = null)
{
    public string Name { get; } = name;
    public Directory? Parent { get; private set; } = parent;
    public IReadOnlyList<Directory> Children => _children.AsReadOnly();
    private List<Directory> _children = [];

    public void AddChild(Directory child)
    {
        _children.Add(child);
        child.Parent = this;
    }
}
