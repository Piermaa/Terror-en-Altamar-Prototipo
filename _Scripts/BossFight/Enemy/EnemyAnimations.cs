using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAnimations : MonoBehaviour
{

    [SerializeField] Animator _animator;
    public bool attached;
    // Start is called before the first frame update
    void Start()
    {
        //_animator.GetComponentInChildren<Animator>();
        _animator.SetTrigger("Walk_Cycle_1");
        if (attached)
        {
            _animator.SetTrigger("Take_Damage_2");
        }
       
    }
    private void OnEnable()
    {
        _animator.SetTrigger("Walk_Cycle_1");
        if (attached)
        {
            _animator.SetTrigger("Take_Damage_2");
        }
    }

}
