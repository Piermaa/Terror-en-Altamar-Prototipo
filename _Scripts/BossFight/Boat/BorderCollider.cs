using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollider : MonoBehaviour
{
    public bool enemyCollisioned;

    public GameObject enemyEvent;
    public GameObject thisConteiner;

    EventColliders _eventColliders;
    

    private void Start()
    {
        _eventColliders = FindObjectOfType<EventColliders>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemyCollisioned = true;
            print("EnemyCollisioned " + this.gameObject.name);
            _eventColliders.EnemyCollision(enemyEvent, thisConteiner);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCollisioned = false;
        }
    }

}
