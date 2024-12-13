using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrappleBehavor : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] Collider2D triggerCollider;
    playerShooting playerShooting;
    PlatformControler platformControle;
    

    private void Update()
    {
        GameObject player = GameObject.Find("Player");
        GameObject platformControler = GameObject.FindGameObjectWithTag("PlatformControler");
        playerShooting = player.GetComponent<playerShooting>();
        platformControle = platformControler.GetComponent<PlatformControler>();
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("noGrapple"))
        {
            playerShooting.swordOut = false;
            playerShooting.grappleing = false;
            platformControle.platformstate = true;
            Destroy(sword);
        }
    }
}
