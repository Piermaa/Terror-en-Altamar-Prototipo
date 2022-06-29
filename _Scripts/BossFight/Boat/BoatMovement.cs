using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody))]
public class BoatMovement : MonoBehaviour
{
    //[SerializeField] Rigidbody conteiner1;
    //[SerializeField] Rigidbody conteiner2;

    [SerializeField] GameObject conteiner1;
    [SerializeField] GameObject conteiner2;

    [SerializeField] GameObject conteinterCollider1Left;
    [SerializeField] GameObject conteinterCollider1Rigth;

    [SerializeField] GameObject conteinterCollider2Left;
    [SerializeField] GameObject conteinterCollider2Right;

    [SerializeField] Transform enemy;

    public bool conteiner1Destroyed;
    public bool conteiner2Destroyed;

    float conteinerWeight=0.1f; 

    int zValue=8;

    [SerializeField] float timer = 0.2f; //ponerlo en el start si quiero q sea ese valor primero
    int mode=0;

    private Rigidbody _rb;
    Vector3 rotateDir;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();


        conteinterCollider1Left.SetActive(false);
        conteinterCollider1Rigth.SetActive(false);


        conteinterCollider2Left.SetActive(false);
        conteinterCollider2Right.SetActive(false);

    }
    private void Update()
    {

        rotateDir = new Vector3(0, 0, zValue);

        ApplyPhisicsOnConteiners(zValue);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 2;
            ChangeMode();

        }

        switch (mode)
        {
            case 0:
                RotateRight();
                break;

            case 1:
                RotateLeft();
                break;
        }

    }

    void ChangeMode()
    {
        zValue = (-1) * zValue;


        if (mode<1)
        {
            mode++;
        }
        else
        {
            mode = 0;
        }
        
    }
    void ApplyPhisicsOnConteiners(int xAxisMovement)
    {
        Vector3 moveDir = new Vector3(-xAxisMovement, 0, 0);
        if (!conteiner1Destroyed)
        {
            //conteiner1.AddForce(moveDir * conteinerWeight, ForceMode.Force);

            conteiner1.transform.Translate(moveDir*(conteinerWeight+(2-timer))*Time.deltaTime);
        }
        if (!conteiner2Destroyed)
        {
            //conteiner2.AddForce(moveDir * conteinerWeight, ForceMode.Force);
            conteiner2.transform.Translate(moveDir * (conteinerWeight + (2 - timer)) * Time.deltaTime);
        }

      
    }
    void RotateRight()
    {
        transform.Rotate(rotateDir * Time.deltaTime);
        enemy.Rotate(rotateDir * Time.deltaTime);

        conteinterCollider1Left.SetActive(false);
        conteinterCollider1Rigth.SetActive(true);


        conteinterCollider2Left.SetActive(false);
        conteinterCollider2Right.SetActive(true);

    }
    void RotateLeft()
    {
        enemy.Rotate(rotateDir * Time.deltaTime);
        transform.Rotate(rotateDir * Time.deltaTime);


        conteinterCollider1Left.SetActive(true);
        conteinterCollider1Rigth.SetActive(false);


        conteinterCollider2Left.SetActive(true);
        conteinterCollider2Right.SetActive(false);


    }
    void Stabilize()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime);
        enemy.Rotate(rotateDir * Time.deltaTime);
    }
    
}
