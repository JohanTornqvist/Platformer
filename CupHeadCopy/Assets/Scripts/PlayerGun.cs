using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Camera cam;
    Vector2 aimPos;
    Rigidbody2D rb;
    GameObject sword;
    [SerializeField] Rigidbody2D player;
    public playerShooting pS;
    [SerializeField]Rigidbody2D swordRB;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerShoot = GameObject.Find("Player");
        pS = playerShoot.GetComponent<playerShooting>();

    }
    private void Update()
    {
        rb.position = player.position;
        sword = GameObject.FindWithTag("sword");
        if (sword != null)
        {
            swordRB = sword.GetComponent<Rigidbody2D>();
        }

        if (pS.grappleing == false)
        {
            aimPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            aimPos = swordRB.position;
        }

    } 
    private void FixedUpdate()
    {
        Vector2 lookDir = aimPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}