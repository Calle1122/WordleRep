using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    private WordAreaManager _wordMan;
    private KeyboardDictionary _keyDic;

    private Image[] _activeRowBacks; 
    
    private Color _yellow, _green, _grey;

    private void Awake()
    {
        _wordMan = GetComponent<WordAreaManager>();
        _keyDic = GetComponent<KeyboardDictionary>();
        
        _yellow = new Color32(255, 238, 52, 255);
        _green = new Color32(68, 217, 83, 255);
        _grey = new Color32(58, 58, 58, 255);
    }

    public void SetBackColor(int backIndex, string colorName, char c)
    {
        _activeRowBacks = _wordMan.CurrentRowBacks();
        
        switch (colorName)
        {
            case "green":

                _activeRowBacks[backIndex].color = _green;
                _keyDic.keyDic[c.ToString()].image.color = _green;
                _keyDic.keyDic[c.ToString()].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                
                break;
            
            case "yellow":

                _activeRowBacks[backIndex].color = _yellow;
                if (_keyDic.keyDic[c.ToString()].image.color != _green)
                {
                    _keyDic.keyDic[c.ToString()].image.color = _yellow;
                    _keyDic.keyDic[c.ToString()].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }

                break;
            
            case "grey":

                if (_keyDic.keyDic[c.ToString()].image.color != _green && _keyDic.keyDic[c.ToString()].image.color != _yellow)
                {
                    _keyDic.keyDic[c.ToString()].image.color = _grey;
                    _keyDic.keyDic[c.ToString()].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                }
                
                break;
        }
    }
}
