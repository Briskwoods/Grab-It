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

        dictionary = m_gameManager.m_wordToType.ToCharArray();

        for (int i = 0; i < dictionary.Length; i++)
        {
            Debug.Log(dictionary[i]);
        }
    }

    public void ValidationCheck(string letter)
    {
        // Debug checking if this works. 
        //Debug.Log("button pressed is " + letter);

        // Validating letters pressed with letters in the dictionary, sends a right or wrong response, can be used in the game manager to clear the keyboard and/or etc

        // Attempt 1
        //switch (letter == dictionary[0]/* Not actual check condition */)
        //{
        //    case true:
        //        Debug.Log("True");

        //        // Code to Go to Next Line 
        //        Debug.Log("Next Line");


        //        break;
        //    case false:
        //        Debug.Log("False");
        //        Debug.Log("Clear Board");
        //        break;
        //}

        // Attempt 2
        // Clears only where letter is wrong

        m_tempHold = letter.ToCharArray();
        switch (m_tempHold[0] == dictionary[counter]/* Not actual check condition */)
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
                Debug.Log("Clear Tile");
                break;
        }



    }


}
