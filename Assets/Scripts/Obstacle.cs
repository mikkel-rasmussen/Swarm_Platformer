using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Action callback;

    public void Dissolve()
    {
        StartCoroutine(StartDissolve());
    }

    private IEnumerator StartDissolve()
    {
        float dissolveDuration = 2f;
        float current = 0f;
        Material mat = GetComponent<Renderer>().material;
        while (current < 1f)
        {
            current += Mathf.Clamp01(Time.deltaTime / dissolveDuration);
            mat.SetFloat("_DissolvePercentage", current);
            yield return null;
        }

        callback?.Invoke();
        Destroy(gameObject);
    }
}
