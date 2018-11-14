using UnityEngine;

public abstract class Game : MonoBehaviour
{
    protected FileReader fileReader;

    protected Session session;

    protected int currentQuestion;

    protected virtual void StartGame()
    {
        currentQuestion = 0;

        AskQuestion();
    }

    protected abstract void AskQuestion();

    public virtual void NextQuestionButtonClicked()
    {
        currentQuestion++;
    }
}