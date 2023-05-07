using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public bool enableGrayscaleEffect = false;
    public bool enableInvertColorEffect = false;
    public bool enableBlurEffect = false;
    public bool enableVignetteEffect = false;
    public bool enableHightlightColorEffect = false;

    [SerializeField] Material grayscaleMaterial;
    [SerializeField] Material nightVisionMaterial;
    [SerializeField] Material blurMaterial;
    [SerializeField] Material vignetteMaterial;
    [SerializeField] Material highLightMaterial;

    private float blurVal = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.C))
        {
            blurVal += 0.5f;
            Debug.Log(blurVal);
            SetBlurSize(blurVal);
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            blurVal -= 0.5f;
            Debug.Log(blurVal);
            SetBlurSize(blurVal);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            blurVal = 1f;
            SetBlurSize(blurVal);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (enableGrayscaleEffect)
        {
            Graphics.Blit(source, destination, grayscaleMaterial);
        }
        else if(enableInvertColorEffect)
        {
            Graphics.Blit(source, destination, nightVisionMaterial);
        }
        else if(enableBlurEffect)
        {
            Graphics.Blit(source, destination, blurMaterial);
        }
        else if (enableVignetteEffect)
        {
            Graphics.Blit(source, destination, vignetteMaterial);
        }
        else if (enableHightlightColorEffect)
        {
            Graphics.Blit(source, destination, highLightMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void SetBlurSize(float blurSize)
    {
        if (enableBlurEffect)
        {
            blurMaterial.SetFloat("_BlurSize", blurSize);
        }
    }
}
