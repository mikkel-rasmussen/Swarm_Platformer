using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutUI : MonoBehaviour
{
    float duration = 3f;

    Coroutine routine = null;

    public void FadeOut()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
        routine = StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float current = 0f;

        CanvasGroup cg = GetComponent<CanvasGroup>();

        cg.alpha = 1f;

        while (current < 1f)
        {
            current += Mathf.Clamp01(Time.deltaTime / duration);

            cg.alpha = 1 - current;
            yield return null;
        }
    }
}
