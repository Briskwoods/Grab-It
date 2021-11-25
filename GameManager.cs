using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [TextArea(2, 2)]
    public string m_wordToType;

    [SerializeField] private KeyboardManager m_keyboardManager;

    // Start is called before the first frame update
    void Start()
    {
        m_keyboardManager = FindObjectOfType<KeyboardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // !!!FOR TESTING ONLY!! Call SplitWord Function to refresh the keyboard manager with the word thats going to be typed. Basically click to refresh the dictionary on the Keyboard manager
        switch (Input.GetMouseButtonDown(0))
        {
            case true:
                SplitWord(m_wordToType, m_keyboardManager);
                break;
            case false:
                break;
        }
    }

    public void SplitWord(string wordToSplit, KeyboardManager keyboard)
    {
        // Clear Dictionary
        keyboard.dictionary = null;

        // Splits the Word into letters and places them within an array 
        //keyboard.dictionary = wordToSplt.Split(char.Parse(" "));

        m_keyboardManager.dictionary = m_wordToType.ToCharArray();



        for (int i = 0; i < keyboard.dictionary.Length; i++)
        {
            Debug.Log(keyboard.dictionary[i]);
        }
    }
}
