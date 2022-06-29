using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolution : MonoBehaviour
{

    public RotatePanel[] buttons;

    public bool puzzle1Solved;

    InteractableObject interactable;
    PuzzleInteraction _puzzleInteraction;
    // Start is called before the first frame update
    void Start()
    {
        interactable = FindObjectOfType<InteractableObject>();
        _puzzleInteraction = FindObjectOfType<PuzzleInteraction>();
    }

    private void Update()
    {
        if(SolutionDetector())
        {
            print("Solved!!!!!!!!1");

            _puzzleInteraction.DeactivatePuzle(_puzzleInteraction.puzzle);
        }
    }

    bool SolutionDetector()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (!buttons[i].solved)
            {
                return false;
            }
        }


        return true;
    }
}
