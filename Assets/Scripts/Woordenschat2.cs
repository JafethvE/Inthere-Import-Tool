using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Woordenschat2 : Game {

    private Woordenschat2Question[] questions;

    [SerializeField]
    private Transform englishWordSpawnLocation;

    [SerializeField]
    private Transform dutchWords;

    [SerializeField]
    private Transform dutchWord1SpawnLocation;

    [SerializeField]
    private Transform dutchWord2SpawnLocation;

    [SerializeField]
    private Transform dutchWord3SpawnLocation;

    [SerializeField]
    private GameObject dutchWordPrefab;

    [SerializeField]
    private GameObject englishWordPrefab;

    [SerializeField]
    private Transform canvas;

    private GameObject englishWord;

    private GameObject dutchWord1;

    private GameObject dutchWord2;

    private GameObject dutchWord3;

    void Start()
    {
        fileReader = new FileReader();
        session = GameObject.Find("Session").GetComponent<Session>();
        StartGame();
    }

    protected override void StartGame()
    {
        string json = fileReader.GetJson(session.SessionName, "Woordenschat 2", "question.json");

        questions = JsonConvert.DeserializeObject<Woordenschat2Question[]>(json);

        base.StartGame();
    }

    protected override void AskQuestion()
    {
        SpawnEnglishWord();
        SpawnDutchWords();
    }

    private void SpawnEnglishWord()
    {
        Destroy(englishWord);
        englishWord = Instantiate(englishWordPrefab);
        englishWord.GetComponent<Text>().text = questions[currentQuestion].WordToTranslate;
        englishWord.transform.SetParent(canvas);
        englishWord.transform.position = englishWordSpawnLocation.position;
    }

    private void SpawnDutchWords()
    {
        int falseWord = 0;
        int chance = Random.Range(1, 4);
        Destroy(dutchWord1);
        Destroy(dutchWord2);
        Destroy(dutchWord3);
        dutchWord1 = Instantiate(dutchWordPrefab);
        dutchWord1.transform.SetParent(dutchWords);
        dutchWord1.transform.position = dutchWord1SpawnLocation.position;
        if(chance == 1)
        {
            dutchWord1.GetComponent<Text>().text = questions[currentQuestion].CorrectWord;
        }
        else
        {
            dutchWord1.GetComponent<Text>().text = questions[currentQuestion].FalseWords[falseWord];
            falseWord++;
        }

        dutchWord2 = Instantiate(dutchWordPrefab);
        dutchWord2.transform.SetParent(dutchWords);
        dutchWord2.transform.position = dutchWord2SpawnLocation.position;
        if (chance == 2)
        {
            dutchWord2.GetComponent<Text>().text = questions[currentQuestion].CorrectWord;
        }
        else
        {
            dutchWord2.GetComponent<Text>().text = questions[currentQuestion].FalseWords[falseWord];
            falseWord++;
        }

        dutchWord3 = Instantiate(dutchWordPrefab);
        dutchWord3.transform.SetParent(dutchWords);
        dutchWord3.transform.position = dutchWord3SpawnLocation.position;
        if (chance == 3)
        {
            dutchWord3.GetComponent<Text>().text = questions[currentQuestion].CorrectWord;
        }
        else
        {
            dutchWord3.GetComponent<Text>().text = questions[currentQuestion].FalseWords[falseWord];
            falseWord++;
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
            SceneManager.LoadScene("Woordenschat3");
        }
    }
}
