using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float lerpTime;

    [SerializeField] private Color[] allColors;
    private Light _thisLight;
    
    private int _colorIndex = 0;
    private float _t = 0f;
    private int _len;

    private void Start()
    {
        _thisLight = GetComponent<Light>();
        _len = allColors.Length;
    }

    private void Update()
    {
        _thisLight.color = Color.Lerp(_thisLight.color, allColors[_colorIndex], lerpTime * Time.deltaTime);

        _t = Mathf.Lerp(_t, 1f, lerpTime * Time.deltaTime);
        if (_t > .9f)
        {
            _t = 0f;
            _colorIndex++;
            _colorIndex = (_colorIndex >= _len) ? 0 : _colorIndex;
        }
    }
}
