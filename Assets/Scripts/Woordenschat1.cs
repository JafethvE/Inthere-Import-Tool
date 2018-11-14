using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Woordenschat1 : Game {

    private Woordenschat1Question[] questions;

    [SerializeField]
    private Transform rocketSpawnLocation;

    [SerializeField]
    private Transform planet1SpawnLocation;

    [SerializeField]
    private Transform planet2SpawnLocation;

    [SerializeField]
    private Transform planet3SpawnLocation;

    [SerializeField]
    private GameObject rocketPrefab;

    [SerializeField]
    private GameObject planetPrefab;

    [SerializeField]
    private Transform canvas;

    [SerializeField]
    private Transform planets;

    private GameObject rocket;

    private GameObject planet1;

    private GameObject planet2;

    private GameObject planet3;

    private void Start()
    {
        fileReader = new FileReader();
        session = GameObject.Find("Session").GetComponent<Session>();
        StartGame();
    }

    protected override void StartGame()
    {
        string json = fileReader.GetJson(session.SessionName, "Woordenschat 1", "question.json");

        questions = JsonConvert.DeserializeObject<Woordenschat1Question[]>(json);

        base.StartGame();
    }

    protected override void AskQuestion()
    {
        SpawnPlanets();
        SpawnRocket();
    }

    private void SpawnRocket()
    {
        Destroy(rocket);
        rocket = Instantiate(rocketPrefab);
        rocket.transform.SetParent(canvas);
        rocket.transform.position = rocketSpawnLocation.position;
        Sprite sprite = fileReader.GetSprite(session.SessionName, "Woordenschat 1", questions[currentQuestion].Image);
        rocket.GetComponent<Image>().sprite = sprite;
    }

    private void SpawnPlanets()
    {
        int falseword = 0;
        int chance = Random.Range(1, 4);
        Destroy(planet1);
        Destroy(planet2);
        Destroy(planet3);
        planet1 = Instantiate(planetPrefab);
        planet1.transform.SetParent(planets);
        planet1.transform.position = planet1SpawnLocation.position;
        if(chance == 1)
        {
            planet1.GetComponentInChildren<Text>().text = questions[currentQuestion].CorrectWord;
        }
        else
        {
            planet1.GetComponentInChildren<Text>().text = questions[currentQuestion].FalseWords[falseword];
            falseword++;
        }

        planet2 = Instantiate(planetPrefab);
        planet2.transform.SetParent(planets);
        planet2.transform.position = planet2SpawnLocation.position;
        if (chance == 2)
        {
            planet2.GetComponentInChildren<Text>().text = questions[currentQuestion].CorrectWord;
        }
        else
        {
            planet2.GetComponentInChildren<Text>().text = questions[currentQuestion].FalseWords[falseword];
            falseword++;
        }

        planet3 = Instantiate(planetPrefab);
        planet3.transform.SetParent(planets);
        planet3.transform.position = planet3SpawnLocation.position;
        if (chance == 3)
        {
            planet3.GetComponentInChildren<Text>().text = questions[currentQuestion].CorrectWord;
        }
        else
        {
            planet3.GetComponentInChildren<Text>().text = questions[currentQuestion].FalseWords[falseword];
            falseword++;
        }
    }

    public override void NextQuestionButtonClicked()
    {
        base.NextQuestionButtonClicked();
        if (currentQuestion < questions.Length)
        {
            AskQuestion();
        }
        else
        {
            SceneManager.LoadScene("Woordenschat2");
        }
    }
}
