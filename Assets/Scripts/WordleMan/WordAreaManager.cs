using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordAreaManager : MonoBehaviour
{
    [SerializeField] private GameObject[] rowObjs;

    private WordInput _inputMan;
    
    private TextMeshProUGUI[] _activeRowTxts;
    private Image[] _activeRowBacks;
    
    public GameObject activeRow;
    public int rowCounter = -1;

    private void Awake()
    {
        _inputMan = GetComponent<WordInput>();
    }

    private void Start()
    {
        NextRowActive();
        _activeRowTxts = GetRowTxts(activeRow);
        _activeRowBacks = GetImageBacks(activeRow);
    }

    private TextMeshProUGUI[] GetRowTxts(GameObject rowObj)
    {
        TextMeshProUGUI[] arrayToReturn = new TextMeshProUGUI[5];
        int arrayCounter = 0;
        
        foreach (Transform child in rowObj.transform)
        {
            foreach (Transform textChild in child)
            {
                arrayToReturn[arrayCounter] = textChild.gameObject.GetComponent<TextMeshProUGUI>();
            }

            arrayCounter++;
        }

        return arrayToReturn;
    }

    private Image[] GetImageBacks(GameObject rowObj)
    {
        Image[] arrayToReturn = new Image[5];
        int arrayCounter = 0;
        
        foreach (Transform child in rowObj.transform)
        {
            arrayToReturn[arrayCounter] = child.gameObject.GetComponent<Image>();

            arrayCounter++;
        }

        return arrayToReturn;
    }

    public TextMeshProUGUI[] CurrentRowTxts()
    {
        return _activeRowTxts;
    }

    public Image[] CurrentRowBacks()
    {
        return _activeRowBacks;
    }

    public void NextRowActive()
    {
        rowCounter++;
        if (rowCounter == rowObjs.Length)
        {
            rowCounter = rowObjs.Length - 1;
        }

        activeRow = rowObjs[rowCounter];
        _activeRowTxts = GetRowTxts(activeRow);
        _activeRowBacks = GetImageBacks(activeRow);
        
        _inputMan.ResetCharCounter();
        _inputMan.enteredString = null;
    }
}
