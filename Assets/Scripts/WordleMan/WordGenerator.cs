using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public TextAsset wordsTxtFile;
    public string correctWord;
    
    private string[] _allWords;

    private void Start()
    {
        if (wordsTxtFile != null)
        {
            _allWords = ( wordsTxtFile.text.Split( '\n' ) );
            correctWord = _allWords[UnityEngine.Random.Range(0,_allWords.Length)];
        }
    }
}
