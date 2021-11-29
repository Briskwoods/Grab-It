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

    public char m_myGuess;

    //public TextMeshProUGUI[] inputFields;

    public int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        dictionary = ControlCenter.Instance.GameManager_.m_wordToType.ToLower().ToCharArray();
        EnemyRangeRandomiser(m_difficultyLevel);
        EnemyValidationCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshDictionary(string word)                 // Function to update the enemy dictionary
    {
        // Clear Dictionary
        dictionary = null;
        // Set new characters to dictionary
        dictionary = ControlCenter.Instance.GameManager_.m_wordToType.ToLower().ToCharArray();
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
                for (int i=1; i < 2; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 3:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 3; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 4:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 4; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 5:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 5; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 6:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 6; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 7:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 7; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 8:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 8; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 9:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 9; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 10:
                m_variablesToGuess = new char[m_difficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < 10; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
        }
    }

    [ContextMenu("EnemyValidationCheck")]
    public void EnemyValidationCheck()
    {
        m_myGuess = m_variablesToGuess[Random.Range(0, m_difficultyLevel)];

        switch (m_myGuess.Equals(dictionary[counter]))
        {
            case true:
                Debug.Log("True");
                Debug.Log("" + m_myGuess);
                //inputFields[counter].text = "" + letter;
                EnemyRangeRandomiser(m_difficultyLevel);
                counter++;
                m_variablesToGuess[0] = dictionary[counter];
                // Code to Go to Next Line 
                Debug.Log("Next Line");


                break;
            case false:
                Debug.Log("False");
                Debug.Log("Currently on " + counter);
                break;
        }
    }
}
