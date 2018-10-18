public class Woordenschat2Question : Question {

    private string correctWord;
    private string wordToTranslate;
    private string[] falseWords;

    public string[] FalseWords
    {
        get
        {
            return falseWords;
        }

        set
        {
            falseWords = value;
        }
    }

    public string WordToTranslate
    {
        get
        {
            return wordToTranslate;
        }

        set
        {
            wordToTranslate = value;
        }
    }

    public string CorrectWord
    {
        get
        {
            return correctWord;
        }

        set
        {
            correctWord = value;
        }
    }
}
