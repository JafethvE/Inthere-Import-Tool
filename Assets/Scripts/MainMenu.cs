using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private GameObject levelButtonPrefab;

    [SerializeField]
    private Transform layout;

    [SerializeField]
    private Session session;

    private FileReader fileReader;

    private void Start()
    {
        fileReader = new FileReader();

        string[] sessionNames = fileReader.GetAllSessions();
        foreach(string sessionName in sessionNames)
        {
            GameObject newButtonObject = Instantiate(levelButtonPrefab);
            newButtonObject.transform.SetParent(layout);
            LevelButton newButton = newButtonObject.GetComponent<LevelButton>();
            newButton.SessionName = sessionName;
            newButton.Session = session;
        }
    }
}
