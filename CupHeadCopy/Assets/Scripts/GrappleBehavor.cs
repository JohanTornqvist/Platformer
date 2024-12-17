using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GrappleBehavor : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] GameObject boss;
    [SerializeField] Collider2D triggerCollider;
    [SerializeField] float disctanceTriger  = 3f; 
    public float distance;
    Rigidbody2D swordRb;
    playerShooting playerShooting;
    PlatformControler platformControle;
    playerMovement playerMove;
    BossMovement bossMove;
    public bool keepWorldPosition = true;


    private void Update()
    {
        GameObject player = GameObject.Find("Player");
        GameObject boss = GameObject.FindWithTag("Boss");
        GameObject platformControler = GameObject.FindGameObjectWithTag("PlatformControler");
        bossMove = boss.GetComponent<BossMovement>();
        playerShooting = player.GetComponent<playerShooting>();
        playerMove = player.GetComponent<playerMovement>();

        platformControle = platformControler.GetComponent<PlatformControler>();
        swordRb = sword.GetComponent<Rigidbody2D>();

        distance = Vector2.Distance(sword.transform.position, player.transform.position);

        if(playerShooting.grappleing == true)
        {
            if (distance <= disctanceTriger)
            {
                playerShooting.swordOut = false;
                playerShooting.grappleing = false;
                playerShooting.canGrapple = false;
                platformControle.platformstate = true;
                playerShooting.grappleSpeedMultiplier = 1;
                playerShooting.grappleSpeed = 168.6f;
                Destroy(sword);
            }
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("noGrapple"))
        {
            playerShooting.swordOut = false;
            playerShooting.grappleing = false;
            playerShooting.canGrapple = false;
            platformControle.platformstate = true;
            playerShooting.grappleSpeedMultiplier = 1;
            playerShooting.grappleSpeed = 168.6f;
            Destroy(sword);
        }

        if (!other.CompareTag("noGrapple"))
        {
            swordRb.velocity = swordRb.velocity * 0; 
        }

        if (!other.CompareTag("Player"))
        {
            swordRb.velocity = swordRb.velocity * 0;
        }

        if (other.CompareTag("Boss"))
        {
            swordRb.velocity = swordRb.velocity * 0;
            bossMove.bosshealth -= (playerMove.rb.velocity.y + playerMove.rb.velocity.x) * 0.8f;
        }
    }
}
