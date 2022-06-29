using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPickup : MonoBehaviour
{

    bool goesDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime*-30);

        if(transform.position.y<10.5)
        {
            goesDown = false;
        }
        if(transform.position.y >11f)
        {
            goesDown = true;
        }

        if (!goesDown)
        {
            transform.Translate(Vector3.up * Time.deltaTime/1.5f);
        }
        if(goesDown)
        {
            transform.Translate(Vector3.down * Time.deltaTime/1.5f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            if (!playerController.holdingPiece)
            {
                playerController.holdingPiece = true;
                Destroy(this.gameObject);
            }


        }
    }
}
