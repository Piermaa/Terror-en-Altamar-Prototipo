using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public int conteinerID;
    [SerializeField] GameObject conteiner;
    BoatMovement _boatMovement;
    EventColliders _eventColliders;
    [SerializeField] GameObject conteinerEvent;

    [SerializeField] GameObject electricPiece;
    [SerializeField] ParticleSystem explosionParticles;

    [SerializeField] Animator enemyAnimator;

    private void Start()
    {
        _boatMovement = FindObjectOfType<BoatMovement>();
        _eventColliders = FindObjectOfType<EventColliders>();

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        enemyAnimator.SetTrigger("Take_Damage_1");

        if(health<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (conteinerID == 1)
        {
            _boatMovement.conteiner1Destroyed = true;
        }
        else
        {
            _boatMovement.conteiner2Destroyed = true;
        }

        //explosionParticles.Play();
        Instantiate(electricPiece, conteinerEvent.transform.position+Vector3.up*2, transform.rotation);

        _eventColliders.DoNotRespawnConteiner();
        conteinerEvent.SetActive(false);
        conteiner.SetActive(false);
        Destroy(this.gameObject);
    }
}
