using UnityEngine;

public class Session : MonoBehaviour {

    private string sessionName;

    public string SessionName
    {
        get
        {
            return sessionName;
        }

        set
        {
            sessionName = value;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
