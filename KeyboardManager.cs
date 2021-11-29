using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    public char[] dictionary;                        // This is the word/item we're trying to identify split into letters, for now is initialised here but can be obtained from the game manager and split into this list on a per letter basis

    public char[] m_tempHold;

    [SerializeField] private GameManager m_gameManager;

    public TextMeshProUGUI[] inputFields;

    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // For the first word, will add a function to split on completion of a word/level
        //dictionary = m_gameManager.m_wordToType.Split(char.Parse(" "));

        dictionary = m_gameManager.m_wordToType.ToLower().ToCharArray(); //Evans - Always convert to lower case before converting to char

        for (int i = 0; i < dictionary.Length; i++)
        {
            Debug.Log(dictionary[i]);
        }
    }

    public void KeyPressed(string _key)
    {
        ValidationCheck(_key);
    }

    public void ValidationCheck(string letter)
    {
        // Clears only where letter is wrong
        m_tempHold = letter.ToLower().ToCharArray();//Evans - Convert To Lower then to Char
        switch (m_tempHold[0].Equals(dictionary[counter]) /* Not actual check condition */)
        {
            case true:
                Debug.Log("True");
                inputFields[counter].text = "" + letter;
                
                counter++;
                // Code to Go to Next Line 
                Debug.Log("Next Line");


                break;
            case false:
                Debug.Log("False");
                break;
        }
    }
}
