using System.IO;
using UnityEngine;

//Connects with the filesystem and gives back the specific needed files.
public class FileSystem {

    //The directory of all the session data.
    string directory = Path.Combine(Application.streamingAssetsPath, "Sessions");

    //Gets all the file names in a folder.
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

    //Gives back the named sprite from a given session/game combination.
    public Sprite GetSprite(string session, string game, string spriteName)
    {
        return Resources.Load<Sprite>(Path.Combine(Path.Combine(Path.Combine(directory, session), game), spriteName));
    }

    //Gets the JSon data for a specific level.
    public string GetJson(string session, string game, string fileName)
    {
        return File.ReadAllText(Path.Combine(Path.Combine(Path.Combine(directory, session), game), fileName));
    }
}