using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class FileDrawer : IClearableDrawer
{
    private readonly string _filePath;

    public FileDrawer(string filePath)
    {
        _filePath = filePath;
    }

    public void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void Draw(string content)
    {
        File.AppendAllText(_filePath, content);
    }
}