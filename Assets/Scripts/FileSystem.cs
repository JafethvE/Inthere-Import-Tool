using System.IO;
using UnityEngine;

public class FileSystem {

    string directory = Path.Combine(Application.streamingAssetsPath, "Sessions");

    public string[] GetFileNamesInFolder(string session, string folder)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(session, folder));
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

    public Sprite GetSprite(string session, string game, string spriteName)
    {
        return Resources.Load<Sprite>(Path.Combine(Path.Combine(Path.Combine(directory, session), game), spriteName));
    }

    public string GetJSON(string session, string game, string fileName)
    {
        return File.ReadAllText(Path.Combine(Path.Combine(Path.Combine(directory, session), game), fileName));
    }
}