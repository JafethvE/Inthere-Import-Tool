using System.IO;
using UnityEngine;

public class FileSystem {

    public string[] GetFileNamesInFolder(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        FileInfo[] files = directoryInfo.GetFiles();
        string[] fileNames = new string[files.Length];
        int counter = 0;
        foreach (FileInfo file in files)
        {
            fileNames[counter] = file.Name;
            counter++;
        }
        return fileNames;
    }

    public Sprite GetSprite(string path)
    {
        return Resources.Load<Sprite>(path);
    }

    public string GetJSON(string path)
    {
        return File.ReadAllText(path);
    }
}
