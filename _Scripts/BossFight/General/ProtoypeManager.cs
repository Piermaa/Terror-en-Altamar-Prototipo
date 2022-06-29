using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoypeManager : MonoBehaviour
{

    [SerializeField] GameObject spashInfo;
    [SerializeField] GameObject spashInfo2;
    [SerializeField] GameObject spashInfo3;


    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    [SerializeField] GameObject tutorialCamera;

    bool gameIsStarted;
    int splashIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsStarted) 
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                splashIndex++;
            }


            switch (splashIndex)
            {
                case 0:
                    spashInfo.SetActive(true);
                    break;

                case 1:
                    spashInfo.SetActive(false);
                    spashInfo2.SetActive(true);
                    break;

                case 2:
                    spashInfo2.SetActive(false);
                    spashInfo3.SetActive(true);

                    break;

                case 3:
                    spashInfo3.SetActive(false);
                    tutorialCamera.SetActive(false);
                    player.SetActive(true);
                    enemy.SetActive(true);

                    gameIsStarted = true;
                    break;
            }
        }
    }
}
