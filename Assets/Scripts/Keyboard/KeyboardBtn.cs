using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardBtn : MonoBehaviour
{
    [SerializeField] private char keyChar;

    private WordInput _wordInput;

    private void Awake()
    {
        _wordInput = GameObject.Find("WordleManager").GetComponent<WordInput>();
    }

    public void SendKeyChar()
    {
        _wordInput.EnterChar(keyChar);
    }
}
