using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public bool shouldShake = false;
    public AnimationCurve shakeCurve;
    public float duration = .2f;

    private void Update()
    {
        if (shouldShake)
        {
            shouldShake = false;
            StartCoroutine(ShakeCamera());
        }
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = shakeCurve.Evaluate(elapsedTime / duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;
    }
}
