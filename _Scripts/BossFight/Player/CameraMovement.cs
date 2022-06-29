using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Components

    //Objects
    [SerializeField]GameObject playerBody;

    //vectors
 
    //bools

    //floats
    float x;
    float y;
    float mouseSensitivity=100;
    float xRotation = 0;
    //ints

    //strings

    //sounds

    //anims

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Mouse X") * mouseSensitivity*0.75f * Time.deltaTime; ;
        y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; ;
 
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);


        //if (_gameManager.onPause || _gameManager.gameOver)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
       
        {
            //Cursor.lockState = CursorLockMode.Locked;
            playerBody.transform.Rotate(Vector3.up * x);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}
