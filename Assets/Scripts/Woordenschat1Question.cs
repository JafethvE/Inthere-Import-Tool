public class Woordenschat1Question {

    //The correct answer fitting with the image.
    private string correctWord;

    //The false words that will be shown to the player.
    private string[] falseWords;

    //The filename of the image used.
    private string image;

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

    public string Image
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
        }
    }
}
