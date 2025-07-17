using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMessageUI : MonoBehaviour {
    public TextMeshProUGUI text;
    public CanvasGroup canvasGroup;

    void Start(){
        StartCoroutine(ShowSequence());
    }

    IEnumerator ShowSequence(){
        // Show "GET READY"
        text.text = "GET READY";
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(1.5f);

        // Fade out
        yield return StartCoroutine(FadeOut(0.5f));

        // Change to "GO!"
        text.text = "GO!";
        canvasGroup.alpha = 0f;
        yield return StartCoroutine(FadeIn(0.2f));

        yield return new WaitForSeconds(0.5f);

        // Hide
        yield return StartCoroutine(FadeOut(0.4f));
    }

    IEnumerator FadeIn(float duration){
        float t = 0f;
        while (t < duration){
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t / duration);
            yield return null;
        }
    }

    IEnumerator FadeOut(float duration){
        float t = 0f;
        while (t < duration){
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / duration);
            yield return null;
        }
    }
}
