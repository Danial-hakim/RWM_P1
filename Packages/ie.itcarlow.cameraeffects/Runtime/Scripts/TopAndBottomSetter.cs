using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopAndBottomSetter : MonoBehaviour
{
    private GameObject firstLayer;
    private GameObject secondLayer;
    private GameObject thirdLayer;

    float outlineHeight;
    public void setupOutlinesSize(float width, float height)
    {
        setGameObject();

        outlineHeight = height / 10;
        firstLayer.gameObject.transform.localScale = new Vector3(width , outlineHeight, 1);
        secondLayer.gameObject.transform.localScale = new Vector3(width, outlineHeight, 1);
        thirdLayer.gameObject.transform.localScale = new Vector3(width, outlineHeight, 1);
    }

    public void setupOutlinesColor(Color outlineColor)
    {
        outlineColor.a = 0.9f;
        firstLayer.GetComponent<Renderer>().material.color = outlineColor;

        outlineColor.a = 0.6f;
        secondLayer.GetComponent<Renderer>().material.color = outlineColor;

        outlineColor.a = 0.3f;
        thirdLayer.GetComponent<Renderer>().material.color = outlineColor;
    }

    public void setupOutlinesPosition(int minus) 
    {
        Vector3 parentPos = firstLayer.transform.parent.localPosition;
        float heightGap = outlineHeight / 2f;

        firstLayer.gameObject.transform.localPosition = new Vector3(parentPos.x,parentPos.y , 0);
        secondLayer.gameObject.transform.localPosition = firstLayer.transform.localPosition - new Vector3(0, heightGap * minus, 0);
        thirdLayer.gameObject.transform.localPosition = secondLayer.transform.localPosition - new Vector3(0, heightGap * minus, 0);
    }

    public void setToTransparent()
    {
        Color transparent = new Color(0, 0, 0, 0);

        firstLayer.GetComponent<Renderer>().material.color = transparent;
        secondLayer.GetComponent<Renderer>().material.color = transparent;
        thirdLayer.GetComponent<Renderer>().material.color = transparent;
    }

    void setGameObject()
    {
        firstLayer = transform.Find("FirstLayer").gameObject;
        secondLayer = transform.Find("SecondLayer").gameObject;
        thirdLayer = transform.Find("ThirdLayer").gameObject;
    }
}
