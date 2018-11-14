public class Woordenschat2Question {

    //The correct English word.
    private string correctWord;

    //The Dutch word that the player must translate.
    private string wordToTranslate;

    //The false answers shown to the player.
    private string[] falseWords;

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
}
