using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] bool enableGrayscaleEffect = false;
    [SerializeField] bool enableNightVisionEffect = false;
    [SerializeField] bool enableBlurEffect = false;

    [SerializeField] Material grayscaleMaterial;
    [SerializeField] Material nightVisionMaterial;
    [SerializeField] Material blurMaterial;

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
        else if(enableNightVisionEffect)
        {
            Graphics.Blit(source, destination, nightVisionMaterial);
        }
        else if(enableBlurEffect)
        {
            Graphics.Blit(source, destination, blurMaterial);
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
