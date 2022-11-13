using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardDictionary : MonoBehaviour
{
    [SerializeField] private Button Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G, H, J, K, L, Z, X, C, V, B, N, M;

    public Dictionary<string, Button> keyDic = new Dictionary<string, Button>();

    private void Start()
    {
        keyDic.Add("Q", Q);
        keyDic.Add("W", W);
        keyDic.Add("E", E);
        keyDic.Add("R", R);
        keyDic.Add("T", T);
        keyDic.Add("Y", Y);
        keyDic.Add("U", U);
        keyDic.Add("I", I);
        keyDic.Add("O", O);
        keyDic.Add("P", P);
        keyDic.Add("A", A);
        keyDic.Add("S", S);
        keyDic.Add("D", D);
        keyDic.Add("F", F);
        keyDic.Add("G", G);
        keyDic.Add("H", H);
        keyDic.Add("J", J);
        keyDic.Add("K", K);
        keyDic.Add("L", L);
        keyDic.Add("Z", Z);
        keyDic.Add("X", X);
        keyDic.Add("C", C);
        keyDic.Add("V", V);
        keyDic.Add("B", B);
        keyDic.Add("N", N);
        keyDic.Add("M", M);
    }
}
