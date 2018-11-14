using System.IO;
using UnityEngine;

//Connects with the filesystem and gives back the specific needed files.
public class FileReader {

    //The directory of all the session data.
    private string directory = Path.Combine(Application.streamingAssetsPath, "Sessions");

    public string[] GetAllSessions()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
        DirectoryInfo[] sessions = directoryInfo.GetDirectories();
        string[] sessionNames = new string[sessions.Length];
        int counter = 0;
        foreach (DirectoryInfo session in sessions)
        {
            sessionNames[counter] = session.Name;
            counter++;
        }
        return sessionNames;
    }

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
        string path = "file://" + Path.Combine(Path.Combine(Path.Combine(Path.Combine(directory, session), game), "Images"), spriteName);
        WWW file = new WWW(path);
        while(!file.isDone)
        {

        }
        Sprite sprite = Sprite.Create(file.texture, new Rect(0, 0, file.texture.width, file.texture.height), Vector2.zero);
        return sprite;
    }

    //Gets the JSon data for a specific level.
    public string GetJson(string session, string game, string fileName)
    {
        return File.ReadAllText(Path.Combine(Path.Combine(Path.Combine(directory, session), game), fileName));
    }
}