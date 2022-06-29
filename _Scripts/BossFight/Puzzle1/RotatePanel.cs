using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePanel : MonoBehaviour
{
    public float correctRotation;
    [SerializeField] bool solves;
    public bool solved;
    RectTransform rectTransform;

    public bool rect;

    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();


    }

    // Update is called once per frame
    void Update()
    {
        
        if (solves)
        {
            if(rect)
            {
                if (transform.rotation.z == correctRotation || transform.rotation.z == correctRotation+180)
                {
                    solved = true;
                }
            }

            if (transform.rotation.z == correctRotation)
            {
                solved = true;
            }
   
        }
        else
        {
            solved = false;
        }
    }

    public void RotateButton()
    {
        transform.Rotate(new Vector3(0,0,90));

    }
}
