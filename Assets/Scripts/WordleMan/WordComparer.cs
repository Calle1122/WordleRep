using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordComparer : MonoBehaviour
{
    [SerializeField] private GameObject gameOverObj, winObj;
    [SerializeField] private TextMeshProUGUI gameOverCorrectTxt, winCorrectTxt;
    
    public bool hasEnteredLastWord = false;
    private bool _hasWon = false;
    
    private WordInput _inputMan;
    private WordGenerator _wordGen;
    private ColorManager _colorMan;

    private string _correctWord, _enteredWord;
    
    private void Awake()
    {
        _inputMan = GetComponent<WordInput>();
        _wordGen = GetComponent<WordGenerator>();
        _colorMan = GetComponent<ColorManager>();
    }

    public void CompareWords()
    {
        SetWords();
        
        //
        //Compare the words
        //
        
        //Make correct char array
        char[] correctChars = new char[_correctWord.Length]; 
        
        for (int i = 0; i < _correctWord.Length; i++) { 
            correctChars[i] = _correctWord[i]; 
        } 
        
        //Make entered char array
        char[] enteredChars = new char[_enteredWord.Length]; 
        
        for (int i = 0; i < _enteredWord.Length; i++) { 
            enteredChars[i] = _enteredWord[i]; 
        }

        int charIndex = 0;

        Dictionary<char, int> coloredCounter = new Dictionary<char, int>();

        foreach (char c in enteredChars)
        {
            if (!coloredCounter.ContainsKey(c))
            {
                coloredCounter.Add(c, 0);
            }
        }

        foreach (char c in enteredChars)
        {
            if (c == correctChars[charIndex])
            {
                if (coloredCounter[c] < _wordGen.charCount[c])
                {
                    _colorMan.SetBackColor(charIndex, "green", c);
                    coloredCounter[c]++;
                }
            }

            charIndex++;
            if (charIndex == correctChars.Length)
            {
                charIndex = correctChars.Length - 1;
            }
        }

        charIndex = 0;
        
        foreach (char c in enteredChars)
        {
            if (correctChars.Contains(c) && c != correctChars[charIndex])
            {
                if (coloredCounter[c] < _wordGen.charCount[c])
                {
                    _colorMan.SetBackColor(charIndex, "yellow", c);
                    coloredCounter[c]++;
                }
            }

            else
            {
                _colorMan.SetBackColor(charIndex, "grey", c);
            }
            
            charIndex++;
            if (charIndex == correctChars.Length)
            {
                charIndex = correctChars.Length - 1;
            }
        }
        
        //Check if word is correct
        if (_enteredWord == _correctWord)
        {
            WinGame();
        }
        
        //Check if player has lost the game
        CheckForLose();
    }

    private void WinGame()
    {
        _hasWon = true;
            
        winObj.SetActive(true);
        winCorrectTxt.text = _correctWord;
            
        _inputMan.inputEnabled = false;
    }
    
    private void CheckForLose()
    {
        if (hasEnteredLastWord == true && !_hasWon)
        {
            gameOverObj.SetActive(true);
            gameOverCorrectTxt.text = _correctWord;
            _inputMan.inputEnabled = false;
        }
    }

    private void SetWords()
    {
        _correctWord = _wordGen.correctWord.ToUpper().Trim();
        _enteredWord = _inputMan.enteredString.ToUpper().Trim();

        
    }
}
