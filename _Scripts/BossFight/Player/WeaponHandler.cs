using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    bool shoot;
    [SerializeField] ParticleSystem shootParticles;
    [SerializeField] GameObject fpsCam;
    [SerializeField] GameObject bulletParticles;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100;

    [SerializeField] GameObject hitWeakpoint;
    [SerializeField] GameObject hitOther;
    [SerializeField] AudioSource shotSound;
    [SerializeField] Animator _animator;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            print("shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        if (!shootParticles.isPlaying)
        {
            shootParticles.Play();

            _animator.SetTrigger("Shot1");
            shotSound.Play();

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();

               Instantiate(hitOther, hit.transform.position, hit.transform.rotation);

                if (target != null)
                {
                    target.TakeDamage(damage);
                    Instantiate(hitWeakpoint, hit.transform.position, hit.transform.rotation);

                }
            }
        }
        
       

      
    }
}
