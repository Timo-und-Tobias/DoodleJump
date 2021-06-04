using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour{
    public Rigidbody2D playerRb2D;

    private BoxCollider2D boxCollider2D;
    
    void Start(){
        playerRb2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update(){
        boxCollider2D.enabled = playerRb2D.velocity.y <= 0;

    }
}
