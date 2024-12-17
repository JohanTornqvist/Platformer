using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D boss;
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] GameObject point3;
    [SerializeField] float minSpawnTime = 10f;
    [SerializeField] float maxSpawnTime = 20f;
    [SerializeField] float enemySpeed = 2f;
    public float bosshealth = 3000;

    private Vector2 bossPoint; // Target position for the boss to move towards
    private Rigidbody2D rb;

    void Start()
    {
        rb = boss; // Assign the boss Rigidbody2D here
        MoveBoss(); // Start the MoveBoss loop
    }

    void Update()
    {
        // Calculate the direction towards the target point and move the boss
        Vector2 direction = (bossPoint - rb.position).normalized;
        rb.MovePosition(rb.position + direction * enemySpeed * Time.deltaTime);
    }

    void MoveBoss()
    {
        // Select a random position from the three points
        int place = Random.Range(0, 3);
        switch (place)
        {
            case 0:
                bossPoint = point1.transform.position;
                break;
            case 1:
                bossPoint = point2.transform.position;
                break;
            case 2:
                bossPoint = point3.transform.position;
                break;
        }

        // Schedule the next move
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("MoveBoss", spawnTime);
    }
}

