using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteraction : MonoBehaviour
{
    [SerializeField] Waypoints waypoints;

    [SerializeField] GameObject puzzleProgresion;

    [SerializeField] GameObject winText;

    [SerializeField] GameObject player;
    [SerializeField] GameObject puzzleCamera;
    [SerializeField] GameObject[] puzzles;
    public int puzzle=0;
    InteractableObject interactable;
    [SerializeField]PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        interactable = FindObjectOfType<InteractableObject>();
        //controller = FindObjectOfType<PlayerController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //waypoints = FindObjectOfType<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.playerInRange && interactable.pressE && controller.holdingPiece)
        {
            controller.holdingPiece = false;
            ActivatePuzle(puzzle);
        }

        if(puzzle==2)
        {
            winText.SetActive(true);
        }
    }

    public void ActivatePuzle(int puzzleIndex)
    {
        puzzles[puzzleIndex].SetActive(true);

        player.SetActive(false);
        puzzleCamera.SetActive(true);
     
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        waypoints.speed = 0;
    }

    public void DeactivatePuzle(int puzzleIndex)
    {
        puzzles[puzzleIndex].SetActive(false);
        puzzle++;
        puzzleProgresion.SetActive(true);
        player.SetActive(true);
        puzzleCamera.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        waypoints.speed = 5;
    }
}
