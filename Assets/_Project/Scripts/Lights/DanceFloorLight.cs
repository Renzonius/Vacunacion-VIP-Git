using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DanceFloorLight : MonoBehaviour
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Light2D danceLight;
    [SerializeField] private Color lightColor;

    [Header("SETTINGS")]
    [SerializeField] private float waitTime = 0.05f;
    private int step = 5;
    private byte red = 255;
    private byte green = 0;
    private byte blue = 0;


    void Start()
    {
        danceLight.color = lightColor;
        StartCoroutine(LightColorSequenceCoroutine());
    }


    private IEnumerator LightColorSequenceCoroutine()
    {
        while (isActive)
        {
            //  Rojo -> Amarillo (sube verde)
            while (green < 255)
            {
                green = (byte)Mathf.Clamp(green + step, 0, 255);
                danceLight.color = new Color32(red, green, blue, 255);
                yield return new WaitForSeconds(waitTime);
            }

            //  Amarillo -> Verde (baja rojo)
            while (red > 0)
            {
                red = (byte)Mathf.Clamp(red - step, 0, 255);
                danceLight.color = new Color32(red, green, blue, 255);
                yield return new WaitForSeconds(waitTime);
            }

            //  Verde -> Cian (sube azul)
            while (blue < 255)
            {
                blue = (byte)Mathf.Clamp(blue + step, 0, 255);
                danceLight.color = new Color32(red, green, blue, 255);
                yield return new WaitForSeconds(waitTime);
            }

            //  Cian -> Azul (baja verde)
            while (green > 0)
            {
                green = (byte)Mathf.Clamp(green - step, 0, 255);
                danceLight.color = new Color32(red, green, blue, 255);
                yield return new WaitForSeconds(waitTime);
            }

            //  Azul -> Magenta (sube rojo)
            while (red < 255)
            {
                red = (byte)Mathf.Clamp(red + step, 0, 255);
                danceLight.color = new Color32(red, green, blue, 255);
                yield return new WaitForSeconds(waitTime);
            }

            //  Magenta -> Rojo (baja azul)
            while (blue > 0)
            {
                blue = (byte)Mathf.Clamp(blue - step, 0, 255);
                danceLight.color = new Color32(red, green, blue, 255);
                yield return new WaitForSeconds(waitTime);
            }
        }

    }
}
