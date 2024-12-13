using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColliderControler : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Collider2D platformCollider;
    PlatformControler platformControler;
    private bool privatePlatformControler;
    public void Start()
    {
        GameObject platformControler2 = GameObject.FindWithTag("PlatformControler");
        platformControler = platformControler2.GetComponent<PlatformControler>();
        platformCollider = platform.GetComponent<Collider2D>();
    }

    public void Update()
    {
        if(platformControler == null)
        {
            Debug.Log("is null");
        }
        
        if (platformControler.platformstate == false)
        {
            platformCollider.enabled = false;
        }

        if(platformControler.platformstate == true)
        {
            platformCollider.enabled = true;
        }
    }
}