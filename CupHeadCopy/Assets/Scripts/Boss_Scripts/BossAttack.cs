using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float minAttackTime = 0.1f;     // Minimum delay between attacks
    [SerializeField] float maxAttackTime = 2f;     // Maximum delay between attacks
    [SerializeField] GameObject boss;             // Boss GameObject reference
    [SerializeField] GameObject bossBigLazer;     // Boss' laser prefab
    public float lazerTimer = 5f;                 // Timer for laser attacks

    private float attackTimer;                    // Timer to trigger attacks

    private void Start()
    {
        ScheduleNextAttack(); // Start the attack cycle
    }

    private void Update()
    {
        // Handle laser timer for continuous attacks
        if (lazerTimer > 0)
        {
            lazerTimer -= Time.deltaTime;
        }
    }

    void ScheduleNextAttack()
    {
        // Randomize the next attack time
        attackTimer = Random.Range(minAttackTime, maxAttackTime);
        Invoke(nameof(bossAttack), attackTimer);
    }

    void bossAttack()
    {
        // Randomly decide which attack to perform
        int attackRnd = Random.Range(0, 2);
        switch (attackRnd)
        {
            case 0:
                Attack1();
                break;
            case 1:
                Attack2();
                break;
        }

        // Schedule the next attack
        ScheduleNextAttack();
    }

    void Attack1()
    {
        if (lazerTimer <= 0)
        {
            lazerTimer = 5f;

            float fixedAngle = Random.value > 0.5f ? 0f : 180f;

            Quaternion fixedRotation = Quaternion.Euler(0f, 0f, fixedAngle);

            GameObject bigLazer = Instantiate(bossBigLazer, boss.transform.position, fixedRotation);
            Rigidbody2D bigLazerRb = bigLazer.GetComponent<Rigidbody2D>();

                bigLazerRb.AddForce(bigLazer.transform.right * -10, ForceMode2D.Impulse);
        }
    }

    void Attack2()
    {
        // Placeholder for another attack logic
        Debug.Log("Boss performs Attack 2!");
    }
}
