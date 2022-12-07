using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvalidTxt : MonoBehaviour
{
    [SerializeField] private float _moveSpeed, _growSpeed, _fadeSpeed;
    private float _fontSize = 0f;
    private float _alpha = 0f;

    private bool hasFaded = false;

    private TextMeshProUGUI _txtAsset;
    
    private void Awake()
    {
        _txtAsset = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Time.deltaTime * _moveSpeed);
        _fontSize += Time.deltaTime * _growSpeed;

        switch (hasFaded)
        {
            case false:

                _alpha += Time.deltaTime * _fadeSpeed;
                if (_alpha >= 255)
                {
                    _alpha = 255;
                    hasFaded = true;
                }
                
                break;
            
            case true:
                
                _alpha -= Time.deltaTime * _fadeSpeed;
                if (_alpha < 0)
                {
                    _alpha = 0;
                }
                
                break;
        }

        _txtAsset.fontSize = _fontSize;
        _txtAsset.color = new Color32(255, 255, 255, (byte)_alpha);
    }
}
