using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinesScript : MonoBehaviour
{
    private GameObject top;
    private GameObject bottom;

    TopAndBottomSetter topParent;
    TopAndBottomSetter bottomParent;

    [SerializeField] private Camera cam;

    float height;
    float width;

    public float timer = 2.5f;

    float camSize;

    public Color outlinesColor { get; set; } = Color.red;
    // Start is called before the first frame update

    void Start()
    {
        // Set the camera to main unless theres a specific camera you want the outline to appear on
        if(cam == null)
        {
            cam = Camera.main;
        } 

        if(transform.parent != null)
        {
            transform.parent = null;
        }

        top = transform.Find("Top").gameObject;
        bottom = transform.Find("Bottom").gameObject;

        topParent = top.GetComponent<TopAndBottomSetter>();
        bottomParent = bottom.GetComponent<TopAndBottomSetter>();
        setOutlinesParentSize();
        setOutlineParentColor();
        setOutlineParentPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                topParent.setToTransparent();
                bottomParent.setToTransparent();
                Destroy(gameObject);
            }
        }
    }

    public void setOutlinesParentSize()
    {
        camSize = cam.orthographicSize;

        height = camSize * 2f;
        width = height * cam.aspect;

        gameObject.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 2);

        topParent.setupOutlinesSize(width,camSize);
        bottomParent.setupOutlinesSize(width,camSize);
    }

    public void setOutlineParentColor()
    {
        topParent.setupOutlinesColor(outlinesColor);
        bottomParent.setupOutlinesColor(outlinesColor);
    }

    public void setOutlineParentPos()
    {
        float xPos = 0;
        float yPos = camSize / 2f;

        top.gameObject.transform.position = new Vector3(xPos, yPos, 10);
        bottom.gameObject.transform.position = new Vector3(xPos, -yPos, 10);

        topParent.setupOutlinesPosition(1);
        bottomParent.setupOutlinesPosition(-1);
    }

    /// <summary>
    /// If you want to change to a specific camera at run time 
    /// </summary>
    /// <param name="camera"></param>
    public void setCamera(Camera camera)
    {
        cam = camera;
    }
}
