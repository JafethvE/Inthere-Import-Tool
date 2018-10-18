using UnityEngine;

public class Level : MonoBehaviour {

    public enum Game {Woordenschat1, Woordenschat2, Woordenschat3,  Accuratesse, FoneemHerkenning, Productie, Snelheid, TypeWriter, Uitleg, AccuratesseEen, AccuratesseTwee};

    private FileSystem fileSystem;

    private string currentSession;

    private Game currentGame;

    private Question[] questions;

    public Game CurrentGame
    {
        get
        {
            return currentGame;
        }

        set
        {
            currentGame = value;
        }
    }

    public string CurrentSession
    {
        get
        {
            return currentSession;
        }

        set
        {
            currentSession = value;
        }
    }

    public void Start()
    {
        fileSystem = new FileSystem();
        StartLevel();
    }

    private string GetCurrentGameName()
    {
        string currentGameName;
        switch (currentGame)
        {
            case Game.Woordenschat1:
                currentGameName = "Woordenschat 1";
                break;
            case Game.Woordenschat2:
                currentGameName = "Woordenschat 2";
                break;
            case Game.Woordenschat3:
                currentGameName = "Woordenschat 3";
                break;
            default:
                currentGameName = "Woordenschat 1";
                break;
        }
        return currentGameName;
    }

    private void StartLevel()
    {
        currentSession = "Sessie 1 Klank-letter";
        currentGame = Game.Woordenschat1;
        string json = fileSystem.GetJSON(CurrentSession, GetCurrentGameName(), "Question.json");
        Debug.Log(json);
    }
}