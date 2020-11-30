using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class InteractableCubes : MonoBehaviour
{

    Material materialInstance;
    float transparentAlpha = 0.25f;
    Color initialColor;


    void OnEnable()
    {

        materialInstance = this.GetComponent<MeshRenderer>().material;
        initialColor = materialInstance.color;
        StartCoroutine(FadeIn());


    }

    public void HighlightCubeInteraction()
    {

        StartCoroutine(FadeOut());
    }

    public void ResetVisualizations()
    {
        StartCoroutine(FadeIn());

    }


    IEnumerator FadeIn()
    {

        Color tempColor = materialInstance.color;
        float additive = transparentAlpha;

        while (tempColor.a < 1)
        {
            additive += Time.deltaTime;

            tempColor = new Color(initialColor.r, initialColor.g, initialColor.b, additive);
            materialInstance.color = tempColor;

            yield return null;
        }

    }


    IEnumerator FadeOut()
    {

        Color tempColor = materialInstance.color;
        float sub = materialInstance.color.a;

        while (tempColor.a > transparentAlpha)
        {
            sub -= Time.deltaTime;
            tempColor = new Color(initialColor.r, initialColor.g, initialColor.b, sub);
            materialInstance.color = tempColor;


            yield return null;
        }

    }
}
