public class Woordenschat1Question : Question {

    string correctWord;
    string[] falseWords;
    string imageName;

    public string ImageName
    {
        get
        {
            return imageName;
        }

        set
        {
            imageName = value;
        }
    }

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
