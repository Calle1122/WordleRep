using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public TextAsset wordsTxtFile, validInputTxtFile;
    public string correctWord;

    public HashSet<string> allWordsHash = new HashSet<string>();
    public Dictionary<char, int> charCount = new Dictionary<char, int>();

    private string[] _allWords, _allValidInput;

    private void Start()
    {
        if (wordsTxtFile != null)
        {
            _allWords = ( wordsTxtFile.text.Split( '\n' ) );
            correctWord = _allWords[UnityEngine.Random.Range(0,_allWords.Length)];
            correctWord = correctWord.Trim();

            foreach (char c in correctWord)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount.Add(c, 1);
                }
            }

            _allValidInput = ( validInputTxtFile.text.Split( '\n' ) );
            foreach (string i in _allValidInput)
            {
                string newString = i;
                newString = newString.Trim();
                newString = newString.ToUpper();
                
                allWordsHash.Add(newString);
            }
        }
    }
}
