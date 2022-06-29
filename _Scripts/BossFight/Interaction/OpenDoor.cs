using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private InteractableObject iO;
    private StealthEnemy sE;

    [SerializeField] AudioSource alarmSound;
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closedDoor;

    private void Start()
    {
        iO = FindObjectOfType<InteractableObject>();
        sE = FindObjectOfType<StealthEnemy>();
    }
    private void Update()
    {
        if (iO.pressE && iO.playerInRange)
        {
            PullLever();
        }
    }

    public void PullLever()
    {
        sE.InvestigateAlarm();
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
        alarmSound.Play();
     
    }
}
