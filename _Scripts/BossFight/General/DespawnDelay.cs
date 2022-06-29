using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnDelay : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }

}
