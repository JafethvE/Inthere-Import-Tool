using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

//Generates and manages the level based on the data it gets from the imported JSon.
public class Level : MonoBehaviour {

    //The different minigames the level employs.
    public enum Game {Woordenschat1, Woordenschat2, Woordenschat3,  Accuratesse, FoneemHerkenning, Productie, Snelheid, TypeWriter, Uitleg, AccuratesseEen, AccuratesseTwee};

    //To communicate with the filesystem.
    private FileSystem fileSystem;

    //The name of the current session.
    private string currentSession;

    //The game the player is currently playing.
    private Game currentGame;

    //The questions for the current game.
    //This might be rewritten in the future to work with the other minigames.
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

    //Use this for initialisation.
    public void Start()
    {
        fileSystem = new FileSystem();
        StartLevel();
    }

    //Gives back the current game name as a string.
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

    //Starts the level on the game that we
    private void StartLevel()
    {
        currentSession = "Sessie 1 Klank-letter";
        currentGame = Game.Woordenschat1;
        string json = fileSystem.GetJSON(CurrentSession, GetCurrentGameName(), "Question.json");
        List<Woordenschat1Question> questions = JsonConvert.DeserializeObject<List<Woordenschat1Question>>(json);
        int counter = 0;
        foreach(Woordenschat1Question question in questions)
        {
            Debug.Log("Correct word " + counter + ": " + question.correctWord);
            Debug.Log("Image name " + counter + ": " + question.image);
            int counter2 = 0;
            foreach(string falseword in question.falseWords)
            {
                Debug.Log("Question " + counter + " false answer " + counter2 + ": " + falseword);
                counter2++;
            }
            counter++;
        }
    }
}