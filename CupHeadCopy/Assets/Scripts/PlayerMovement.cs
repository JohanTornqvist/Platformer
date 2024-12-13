using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;
    Rigidbody2D playerSaveRb;
    public playerShooting playerShooting;
    public ColliderControler platformToggle;
    [SerializeField] Collider2D playerCollider;
    private bool timerTogggle = false;
    [SerializeField] Transform player;
    [SerializeField] Transform playerSave;
    [SerializeField] Transform ground;

    [Header("Movement Settings:")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float dipPower = 20f;
    [SerializeField] float dipTimer = 10f;

    [Header("Ground Check:")]
    [SerializeField] ContactFilter2D jumpFilter;
    [SerializeField] ContactFilter2D platformFilter;
    [SerializeField] LayerMask groundLayers;

    [Header("Movment Toggles:")]
    public bool canMove = true;
    public bool canJump = false;
    public bool canDip = false;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        jumpFilter.SetLayerMask(groundLayers);

        GameObject platformcontroll = GameObject.FindWithTag("platform");
        platformToggle = platformcontroll.GetComponent<ColliderControler>();
        playerShooting = GetComponent<playerShooting>();
        playerSaveRb = playerSave.GetComponent<Rigidbody2D>();

    }
    void OnMove(InputValue value)
    {
        if (canMove == true)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void OnJump(InputValue value)
    {
        if (canJump == true)
        {
            rb.velocity += new Vector2(0, jumpPower);
        }
    }

    

    void OnDip(InputValue value)
    {
        if (canDip == true)
        {
            playerCollider.enabled = false;
            canDip = false;
            rb.AddForce(rb.transform.up * dipPower, ForceMode2D.Impulse);
            timerTogggle = true;
        }
    }

    private void FixedUpdate()
    {
        canJump = rb.IsTouching(jumpFilter);
        canDip = rb.IsTouching(platformFilter);
    }

    void Update()
    {
        if (moveInput != Vector2.zero)
        {
            rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        }

        if (timerTogggle == true)
        {
            dipTimer -= Time.deltaTime;

            dipTimer = Mathf.Max(dipTimer, 0);

            if(dipTimer <= 0)
            {
                timerTogggle = false;
                dipTimer = 0.03f;
                playerCollider.enabled = true;
            }
        }

        if(rb.position.y <= ground.position.y)
        {
            Vector2 targetPosition = playerSaveRb.position;
            rb.position = new Vector2(rb.position.x, targetPosition.y);
        }
        Vector2 targetPosition2 = rb.position;
        playerSaveRb.position = new Vector2(targetPosition2.x, playerSaveRb.position.y);
    }
}
