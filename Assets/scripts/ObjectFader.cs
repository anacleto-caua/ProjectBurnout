using UnityEngine;

/*
Add in the object that you wanto to be transparent when it is between the
player and the camera.

OBS:
Doesn't work on all the material. The material it was tested with is the Universal Render
Pipeline/Lit
*/
public class ObjectFader : MonoBehaviour
{
    private float fadeSpeed = 10f;
    private float fadeAmount = 0.5f;
    public bool doFade = false;
    private float originalOpacity;
    private Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalOpacity = material.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(doFade) {
            fadeNow();
        } else {
            resetFade();
        }
    }

    void fadeNow() {
        Color currentColor = material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        material.color = smoothColor;
    }

    void resetFade() {
        Color currentColor = material.color;
        Color originalColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        material.color = originalColor;
    }
}