using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private int m_difficultyLevel;

    [SerializeField] private char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public char[] dictionary;                        // This is the word/item we're trying to identify split into letters, for now is initialised here but can be obtained from the game manager and split into this list on a per letter basis

    public char[] m_variablesToGuess;

    public char[] m_myGuess;

    public string m_dictionaryWord;
    public string m_guessedWord;

    //public TextMeshProUGUI[] inputFields;
    //public GameManager gameManager;

    public int counter = 0;

    public float m_guessDelay = 2f;
    public float m_restartDelay = 2.5f;

    public FailHandSequence FailHandSequence_;

    public ExtendArm ExtendArm_;

    public GrabSequence GrabSequence_GrabObject;

    // Start is called before the first frame update
    void Start()
    {
        dictionary = ControlCenter.Instance.GameManager_.m_wordToType.ToLower().ToCharArray();
        EnemyRangeRandomiser(m_difficultyLevel);
        
        // Jeff - Debug comment
        //EnemyValidationCheck();
        m_myGuess = new char[dictionary.Length];
    }

    public void DelayBefore()
    {
        Invoke("RefreshEverything", 2f);
    }

    // Used on level reset
    [ContextMenu("Refresh Everything")]
    public void RefreshEverything()                 // Function to update the enemy dictionary
    {
        // Reset counter to 0;
        counter = 0;
        // Clear Dictionary
        dictionary = null;
        // Set new characters to dictionary
        dictionary = ControlCenter.Instance.GameManager_.m_wordToType.ToLower().ToCharArray();
        //dictionary = gameManager.m_wordToType.ToLower().ToCharArray();                        // Debug Stmt
        // Refresh the variables to guess from as well
        EnemyRangeRandomiser(m_difficultyLevel);
        // Refresh Guess size as well
        m_myGuess = new char[dictionary.Length];
        // Clear both word fields
        m_dictionaryWord = null;
        m_guessedWord = null;
        // Start guessing on Refresh
        GuessLetter();
    }

    public void EnemyRangeRandomiser(int range)
    {
        switch (range)
        {
            case 1:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                break;
            case 2:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i=1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 3:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 4:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 5:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 6:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 7:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 8:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 9:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 10:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_difficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
        }
    }


    // Used on level reset
    [ContextMenu("Randomise Letters to Guess")]
    public void Randomise()
    {
        EnemyRangeRandomiser(m_difficultyLevel);
    }

    [ContextMenu("Guess a Letter")]
    public void GuessLetter()
    {
        // Guesses a letter within the range and adds it to the array
        m_myGuess[counter] = m_variablesToGuess[Random.Range(0, m_difficultyLevel)];
        EnemyRangeRandomiser(m_difficultyLevel);
        counter++;

        ExtendArm_.IncreaseSize();

        switch (counter != dictionary.Length)
        {
            case true:
                m_variablesToGuess[0] = dictionary[counter];
                StartCoroutine(GuessAfterDelay(m_guessDelay));
                break;
            case false:
                // Validate word created
                EnemyValidationCheck();
                break;
        }
    }


    [ContextMenu("Validation Check")]
    public void EnemyValidationCheck()
    {

        // Collate both dictionaries and check if words are the same
        m_dictionaryWord = new string(dictionary);
        m_guessedWord = new string(m_myGuess);

        switch (m_guessedWord.Equals(m_dictionaryWord))
        {
            case true:
                Invoke("CorrectGuess", 1f);
                Debug.Log("Correct!");
                // Game Over Fn
                break;
            case false:
                Debug.Log("Wrong!");
                StartCoroutine(PauseBeforeRestart(m_restartDelay));
                break;
        }
    }

    public void CorrectGuess()
    {
        GrabSequence_GrabObject.GrabObject();
    }

    [ContextMenu("Restart Guess")]
    public void Restart()
    {
        m_myGuess = new char[dictionary.Length];
        counter = 0;
        m_variablesToGuess[0] = dictionary[counter];
        GuessLetter();
    }

    IEnumerator GuessAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GuessLetter();
    }

    IEnumerator PauseBeforeRestart(float delay)
    {
        //Slap Back
        FailHandSequence_.StartFailSequence();

        yield return new WaitForSeconds(delay);
        Restart();
    }

    public void StopAllJobs()
    {
        StopAllCoroutines();
    }
}
