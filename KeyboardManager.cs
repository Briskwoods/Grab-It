using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    public char[] dictionary;                        // This is the word/item we're trying to identify split into letters, for now is initialised here but can be obtained from the game manager and split into this list on a per letter basis

    public char[] m_typedLetter;
    public char[] m_tempHold;

    [SerializeField] private GameManager m_gameManager;

    public TextMeshProUGUI[] inputFields;

    public int counter = 0;

    public string m_dictionaryWord;
    public string m_guessedWord;

    public float m_restartDelay = 2.5f;

    public WrongAnswerManager WrongAnswerManager_;

    public CorrectAnswerManager CorrectAnswerManager_;

    public ExtendArm ExtendArm_;

    public FailHandSequence FailHandSequence_;

    public GrabSequence GrabSequence_;

    public SlotsAdjust UpdateSlotsAdjust;

    // Start is called before the first frame update
    void Start()
    {
        RefreshEverything();
    }

    public void KeyPressed(string _key)
    {
        ValidationCheck(_key);
    }
    

    public void BackSpace()
    {
        if (counter > 0) //Check if we are at the start of the word
        {
            counter--;
            inputFields[counter].text = "";

            //Grow Arm
            ExtendArm_.ReduceSize();
        }
    }

    public void ValidationCheck(string letter)
    {
        m_typedLetter = letter.ToLower().ToCharArray();
        m_tempHold[counter] = m_typedLetter[0];
        inputFields[counter].text = "" + letter;
        counter++;

        //Grow Arm
        ExtendArm_.IncreaseSize();

        switch (counter.Equals(dictionary.Length)) //Check if the word is complete before validation
        {
            case true:
                // Collate both dictionaries and check if words are the same
                m_dictionaryWord = new string(dictionary);
                m_guessedWord = new string(m_tempHold);

                switch (m_guessedWord.Equals(m_dictionaryWord))
                {
                    case true:
                        // On level complete
                        GrabSequence_.GrabObject();
                        CorrectAnswerManager_.StartPump();
                        break;
                    case false:
                        WrongAnswerManager_.StartPump();
                        FailHandSequence_.StartFailSequence();
                        StartCoroutine(DelayBeforeRestart(m_restartDelay));
                        break;
                }
                break;
            case false:
                break;
        }
    }

    public void Restart()
    {
        counter = 0;
        RefreshEverything();
        m_tempHold = new char[dictionary.Length];
        ClearFields(inputFields);
    }

    public void ClearFields(TextMeshProUGUI[] inputFields)
    {
        for (int i = 0; i < inputFields.Length; i++)
        {
            switch (inputFields[i].enabled == true)
            {
                case true:
                    inputFields[i].text = "";
                    break;
                case false:
                    break;
            }
        }
    }

    IEnumerator DelayBeforeRestart(float delay)
    {
        yield return new WaitForSeconds(delay);
        Restart();
    }


    // Used on level reset
    public void RefreshEverything()                 
    {
        counter = 0;
        dictionary = null;
        dictionary = ControlCenter.Instance.GameManager_.m_wordToType.ToLower().ToCharArray();
        Debug.Log(ControlCenter.Instance.GameManager_.m_wordToType);
        m_tempHold = new char[dictionary.Length];
        UpdateSlotsAdjust.AdjustWordLength(dictionary.Length);
        ClearFields(inputFields);
    }
}
