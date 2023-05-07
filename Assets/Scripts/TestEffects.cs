using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffects : MonoBehaviour
{
    [SerializeField] private GameObject outlines;
    [SerializeField] private CameraEffects effects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SpawnOutlines();
        }
    }

    void SpawnOutlines()
    {
        GameObject tempOutline = Instantiate(outlines, gameObject.transform);
    }

    void enableBlur()
    {
        effects.enableBlurEffect = true;
    }
}
