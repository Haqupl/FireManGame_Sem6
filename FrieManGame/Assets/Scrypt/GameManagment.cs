using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{

    public Transform[] spawnPoint;
    public GameObject enemy;
    public float timeNextSpawn = 5;
    public byte enemyPerSpown = 3;
    public Text txtScore;
    private GameObject player;
    private int score = 0;
    //private PlayerHealth pHealth;
    // Use this for initialization
    void Start()
    {

        GameObject[] objPlayers = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < objPlayers.Length; i++)
        {
            if (objPlayers[i].name == "Player")
            {
                player = objPlayers[i];
                break;
            }
        }

        //StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (player != null)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                for (int j = 0; j < enemyPerSpown; j++)
                {
                    if (spawnPoint[i] != null)
                    {
                        var rand = new Vector3(Random.Range(-5, 5), 0f, Random.Range(-5, 5));
                        Instantiate(enemy, spawnPoint[i].position + rand, spawnPoint[i].rotation);
                    }
                }
            }
            yield return new WaitForSeconds(timeNextSpawn);
        }

    }

    public void AddScore(int score)
    {
        this.score += score;
        txtScore.text = "Punkty: " + this.score;
    }
}
