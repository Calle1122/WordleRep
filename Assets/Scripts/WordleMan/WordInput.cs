using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    [SerializeField] private CameraShake camShaker;
    public bool shakeMode = true;
    
    public string enteredString;

    public bool inputEnabled = true;

    private WordAreaManager _wordMan;
    private WordComparer _wordComparer;
    
    private int _charCounter = 0;
    private List<string> _keyInputs = new List<string>();

    private void Awake()
    {
        _wordMan = GetComponent<WordAreaManager>();
        _wordComparer = GetComponent<WordComparer>();
        
        _keyInputs.Add("Q");
        _keyInputs.Add("W");
        _keyInputs.Add("E");
        _keyInputs.Add("R");
        _keyInputs.Add("T");
        _keyInputs.Add("Y");
        _keyInputs.Add("U");
        _keyInputs.Add("I");
        _keyInputs.Add("O");
        _keyInputs.Add("P");
        _keyInputs.Add("A");
        _keyInputs.Add("S");
        _keyInputs.Add("D");
        _keyInputs.Add("F");
        _keyInputs.Add("G");
        _keyInputs.Add("H");
        _keyInputs.Add("J");
        _keyInputs.Add("K");
        _keyInputs.Add("L");
        _keyInputs.Add("Z");
        _keyInputs.Add("X");
        _keyInputs.Add("C");
        _keyInputs.Add("V");
        _keyInputs.Add("B");
        _keyInputs.Add("N");
        _keyInputs.Add("M");
    }

    private void Update()
    {
        if (inputEnabled)
        {
            GetInput();
        }
    }

    private void GetInput()
    {
        //Backspace input
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DoBackSpace();
        }
        
        //Enter input
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DoEnter();
        }
        
        //Keyboard character input
        if (_charCounter < 5)
        {
            foreach (char c in Input.inputString)
            {
                if (_keyInputs.Contains(c.ToString().ToUpper()))
                {
                    EnterChar(c);
                }
            }
        }
    }

    public void EnterChar(char c)
    {
        if (_charCounter < 5)
        {
            if (shakeMode)
            {
                camShaker.shouldShake = true;
            }
            
            _wordMan.CurrentRowTxts()[_charCounter].text = c.ToString().ToUpper();
            _charCounter++;

            if (_charCounter == 5)
            {
                string newEntered = _wordMan.CurrentRowTxts()[0].text + _wordMan.CurrentRowTxts()[1].text + _wordMan.CurrentRowTxts()[2].text + _wordMan.CurrentRowTxts()[3].text + _wordMan.CurrentRowTxts()[4].text;
                    
                SetEnteredString(newEntered);
            }
        }
    }

    public void DoBackSpace()
    {
        _charCounter--;
        if (_charCounter < 0)
        {
            _charCounter = 0;
        }
            
        _wordMan.CurrentRowTxts()[_charCounter].text = null;
            
        SetEnteredString(null);
    }

    public void DoEnter()
    {
        if (_charCounter == 5)
        {
            if (_wordMan.rowCounter == 4)
            {
                _wordComparer.hasEnteredLastWord = true;
            }

            _wordMan.activeRow.GetComponent<CameraShake>().shouldShake = true;
            
            _wordComparer.CompareWords();
            _wordMan.NextRowActive();
        }
    }
    
    private void SetEnteredString(string newString)
    {
        enteredString = newString;
    }

    public void ResetCharCounter()
    {
        _charCounter = 0;
    }
}
