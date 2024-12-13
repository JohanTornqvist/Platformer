using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class playerShooting : MonoBehaviour
{
    [Header("Random Stuff:")]
    public playerMovement pM;
    [SerializeField] ContactFilter2D grappleFilter;

    [Header("Sword Settings:")]
    [SerializeField] float swordSpeed = 10f;
    [SerializeField] GameObject playerSword;


    [Header("Grapple Settings:")]
    public LineRenderer Line;
    [SerializeField] Transform playerGun;
    [SerializeField] Transform player;
    [SerializeField] Rigidbody2D grappleHitBox;
    [SerializeField] Transform grappleGunConnect;
    GameObject grapplePoint;

    [Header("Grapple Toggels:")]
    public bool canShoot = true;
    public bool grappleing = false;
    public bool swordOut = false;
    public bool canGrapple = true;
    public bool grappleCanStick = false;


    void Start()
    {
        Line.positionCount = 1;
        pM = GetComponent<playerMovement>();
    }

    public void OnFire()
    {
        if (swordOut == false) //fires the sword if we press left click
        {
            GameObject sword = Instantiate(playerSword, playerGun.transform.position, playerGun.transform.rotation);
            Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
            rb.AddForce(playerGun.transform.up * swordSpeed, ForceMode2D.Impulse);
            swordOut = true;
            grapplePoint = GameObject.FindWithTag("gp");

        }
        if (pM.canJump == false)
        {
            if (swordOut == true) //adds all the line points and sets the first one to the player and sets grappleing to true becuase we have started grappleing 
            {
                Line.positionCount = 2;
                Line.SetPosition(1, grapplePoint.transform.position);
                grappleing = true;
            }
        }
    }

    void Update()
    {
        Line.SetPosition(0, grappleGunConnect.position); //Sets the line second point to the sword if grappleing is true
        if (grappleing == true)
        {
            Line.SetPosition(1, grapplePoint.transform.position);
        }
        else
        {
            Line.positionCount = 1;
        }

    }


}
