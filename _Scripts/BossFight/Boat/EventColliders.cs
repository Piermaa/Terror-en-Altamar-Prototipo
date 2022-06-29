using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliders : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPos;

    public bool mustRespawnEnemy=true;
    public bool mustRespawnConteiner;
    public int destroyedConteiners;
    public void DoNotRespawnEnemy()
    {
        mustRespawnEnemy = false;
    }

    public void DoNotRespawnConteiner()
    {
        mustRespawnConteiner = false;
        destroyedConteiners++;
    }

    public void EnemyCollision(GameObject enemyEvent, GameObject conteiner)
    {
        StartCoroutine(EnemyCollisioning(enemyEvent, conteiner));
    }

    void EnemyRespawn()
    {
        enemy.transform.position = spawnPos.position;
        enemy.SetActive(true);
    }

    public IEnumerator EnemyCollisioning(GameObject enemyEvent, GameObject conteiner)
    {
        mustRespawnConteiner = true;
        enemy.SetActive(false);
        conteiner.SetActive(false);
        enemyEvent.SetActive(true);

        yield return new WaitForSeconds(6);
        print("EnemigoRespawn");
        if(mustRespawnConteiner)
        {
            conteiner.SetActive(true);
            enemyEvent.SetActive(false);
        }

        if (!(destroyedConteiners>1))
        {
            EnemyRespawn();
        }
     
    }
}
