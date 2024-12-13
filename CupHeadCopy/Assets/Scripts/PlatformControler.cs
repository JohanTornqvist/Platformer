using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : MonoBehaviour
{
    public bool platformstate = true;
    playerMovement playerMove;
    playerShooting playerShoot;
    PlayerGun playerGun;
    GrappleBehavor grappleBehavor;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMove = player.GetComponent<playerMovement>();
        playerShoot = player.GetComponent<playerShooting>();
        playerGun = player.GetComponent<PlayerGun>();
       
    }

    void Update()
    {
        GameObject grappleTip = GameObject.FindWithTag("GrappleHitBox");
        if (grappleTip != null)
        {
            grappleBehavor = grappleTip.GetComponent<GrappleBehavor>();
        }

        if (playerShoot != null && playerShoot.grappleing == true)
        {
            platformstate = false;
        }
    }
}
