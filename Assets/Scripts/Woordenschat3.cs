using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class Woordenschat3 : Game {

    private Woordenschat3Question[] questions;

    [SerializeField]
    private Transform rockets;

    [SerializeField]
    private Transform planets;

    [SerializeField]
    private Transform rocket1SpawnLocation;

    [SerializeField]
    private Transform rocket2SpawnLocation;

    [SerializeField]
    private Transform rocket3SpawnLocation;

    [SerializeField]
    private Transform planet1SpawnLocation;

    [SerializeField]
    private Transform planet2SpawnLocation;

    [SerializeField]
    private Transform planet3SpawnLocation;

    [SerializeField]
    private GameObject wordRocketPrefab;

    [SerializeField]
    private GameObject planetPrefab;

    private GameObject wordRocket1;

    private GameObject wordRocket2;

    private GameObject wordRocket3;

    private GameObject planet1;

    private GameObject planet2;

    private GameObject planet3;

    // Use this for initialization
    void Start() {
        fileReader = new FileReader();

        session = GameObject.Find("Session").GetComponent<Session>();

        StartGame();
    }

    protected override void StartGame()
    {
        string json = fileReader.GetJson(session.SessionName, "Woordenschat 3", "question.json");

        questions = JsonConvert.DeserializeObject<Woordenschat3Question[]>(json);

        base.StartGame();
    }

    protected override void AskQuestion()
    {
        string[] dutchWords = new string[3];
        string[] englishWords = new string[3];

        int i = 0;
        foreach (Combination combination in questions[currentQuestion].Combinations)
        {
            dutchWords[i] = combination.Dutch;
            englishWords[i] = combination.English;
            i++;
        }

        RandomiseArray(dutchWords);
        RandomiseArray(englishWords);

        SpawnPlanets(englishWords);
        SpawnRockets(dutchWords);
    }

    private void SpawnPlanets(string[] words)
    {
        Destroy(planet1);
        Destroy(planet2);
        Destroy(planet3);
        Destroy(wordRocket1);
        Destroy(wordRocket2);
        Destroy(wordRocket3);
        planet1 = Instantiate(planetPrefab);
        planet1.transform.SetParent(planets);
        planet1.transform.position = planet1SpawnLocation.position;
        planet1.GetComponentInChildren<Text>().text = words[0];

        planet2 = Instantiate(planetPrefab);
        planet2.transform.SetParent(planets);
        planet2.transform.position = planet2SpawnLocation.position;
        planet2.GetComponentInChildren<Text>().text = words[1];

        planet3 = Instantiate(planetPrefab);
        planet3.transform.SetParent(planets);
        planet3.transform.position = planet3SpawnLocation.position;
        planet3.GetComponentInChildren<Text>().text = words[2];
    }

    private void SpawnRockets(string[] words)
    {
        wordRocket1 = Instantiate(wordRocketPrefab);
        wordRocket1.transform.SetParent(rockets);
        wordRocket1.transform.position = rocket1SpawnLocation.position;
        wordRocket1.GetComponent<Text>().text = words[0];

        wordRocket2 = Instantiate(wordRocketPrefab);
        wordRocket2.transform.SetParent(rockets);
        wordRocket2.transform.position = rocket2SpawnLocation.position;
        wordRocket2.GetComponent<Text>().text = words[1];

        wordRocket3 = Instantiate(wordRocketPrefab);
        wordRocket3.transform.SetParent(rockets);
        wordRocket3.transform.position = rocket3SpawnLocation.position;
        wordRocket3.GetComponent<Text>().text = words[2];
    }

    private void RandomiseArray(string[] array)
    {
        for (var i = array.Length - 1; i > 0; i--)
        {
            var r = Random.Range(0, i + 1);
            var tmp = array[i];
            array[i] = array[r];
            array[r] = tmp;
        }
    }

    public override void NextQuestionButtonClicked()
    {
        base.NextQuestionButtonClicked();
        if (currentQuestion < questions.Length)
        {
            AskQuestion();
        }
    }
}
