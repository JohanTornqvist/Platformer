using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    playerMovement playerMove;
    private void Update()
    {
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<playerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMove.health -= 1;
        }
    }
}
