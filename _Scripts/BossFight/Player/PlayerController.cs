using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Components
    CharacterController controller;
    [SerializeField] Animator _animator;

    [SerializeField] GameObject item;

    [SerializeField] GameObject pauseScreen;

    bool paused;
    public bool holdingPiece;

    //vectors
    Vector3 move;
    //bools
    bool pressSpace;
    bool pressEnter;
    bool pressShift;
    bool leftClick;
    bool onWall;
    public bool grounded;
    //floats
    float x;
    float z;
    float speed = 10;
    float fallVelocity;
    float jumpForce = 2f;
    float gravity = 4.5f;
    //ints

    //strings

    //sounds

    //anims
    private void Awake()
    {
        //_animator = GetComponentInChildren<Animator>();
        controller = FindObjectOfType<CharacterController>();
    }
    void Update()
    {
        leftClick = Input.GetMouseButtonDown(0);
        if (leftClick)
        {
            //_animator.SetTrigger("Attack");
        }
        pressSpace = Input.GetKeyDown(KeyCode.Space);
        pressEnter = Input.GetKeyDown(KeyCode.Return);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        SetGravity();
        //PlayerSkills();
        pressShift = Input.GetKey(KeyCode.LeftShift);
        pressSpace = Input.GetKeyDown(KeyCode.Space);
        controller.Move(move * Time.deltaTime * speed);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

      
        pauseScreen.SetActive(paused);
        item.SetActive(holdingPiece);

        if (paused)
        {
            Time.timeScale = 0.01f;
        }
        else
        {
            Time.timeScale =1f;
        }

    }
    private void FixedUpdate()
    {
        PlayerSkills();
    }
    public void PlayerSkills()
    {
        if (pressSpace && (controller.isGrounded || grounded || onWall))
        {
            fallVelocity = jumpForce;
            move.y = fallVelocity;
            grounded = false;
        }
    }
    public void SetGravity()
    {
        if (controller.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            move.y = fallVelocity;
            //speed -= 0.5f;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            move.y = fallVelocity;
            //speed += 0.5f;
        }
    }


}

