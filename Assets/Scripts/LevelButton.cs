using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    [SerializeField]
    private Button button;

    [SerializeField]
    private Text buttonText;

    [SerializeField]
    private Session session;

    private string sessionName;

    public Session Session
    {
        get
        {
            return session;
        }

        set
        {
            session = value;
        }
    }

    public string SessionName
    {
        get
        {
            return sessionName;
        }

        set
        {
            sessionName = value;
            buttonText.text = value;
        }
    }

    public void StartSession()
    {
        Session.SessionName = sessionName;
        SceneManager.LoadScene("Woordenschat1");
    }
}
