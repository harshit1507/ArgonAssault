using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;    
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;
    GameObject spawnAtRuntime;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnAtRuntime = GameObject.FindWithTag("SpawnAtRuntime");
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void KillEnemy()
    {
        if(hitPoints < 1)
        {
            scoreBoard.IncreseScore(scorePerHit);
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = spawnAtRuntime.transform;
            Destroy(gameObject);
        }
        
    }

    private void ProcessHit()
    {
        hitPoints--;
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnAtRuntime.transform;
        scoreBoard.IncreseScore(scorePerHit);
    }
}
