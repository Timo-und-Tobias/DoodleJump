using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
    public float speed;
    public float jumpHeight;


    private Rigidbody2D rb2D;

    void Start(){
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;

        Debug.Log(isGrounded());
        
        if(isGrounded()) rb2D.velocity = new Vector3(0, Mathf.Sqrt(- 2 * Physics.gravity.y * jumpHeight), 0);
    }

    bool isGrounded(){
        //Debug.DrawRay(transform.position - new Vector3(0, transform.lossyScale.y / 2, 0), Vector3.down, Color.red, 0.5f);
        //RaycastHit2D left = Physics2D.Raycast(transform.position - new Vector3(-transform.lossyScale.x / 2, transform.lossyScale.y / 2, 0), Vector3.down, 0.5f, LayerMask.NameToLayer("Platform"));
        //RaycastHit2D right = Physics2D.Raycast(transform.position - new Vector3(transform.lossyScale.x / 2, transform.lossyScale.y / 2, 0), Vector3.down, 0.5f, LayerMask.NameToLayer("Platform"));
        //Debug.Log(left.collider.gameObject.name);
        //Debug.Log(right.collider.gameObject.name);
        //return left || right;

        //return rb2D.velocity.y == 0;

        //Debug.Log(Physics2D.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider2D>().bounds.extents.y + 0.1f, LayerMask.NameToLayer("Platform")).collider.gameObject.name);
        //Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.red, 1f);
        //return Physics2D.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider2D>().bounds.extents.y + 0.1f, LayerMask.NameToLayer("Platform"));


        RaycastHit2D[] hit2DsLeft = Physics2D.RaycastAll(transform.position + new Vector3(-transform.lossyScale.x / 2, 0, 0), Vector3.down, transform.lossyScale.y / 2 + 0.05f, LayerMask.NameToLayer("Platform"));
        RaycastHit2D[] hit2DsRight = Physics2D.RaycastAll(transform.position + new Vector3(transform.lossyScale.x / 2, 0, 0), Vector3.down, transform.lossyScale.y / 2 + 0.05f, LayerMask.NameToLayer("Platform"));
        
        for(int i = 0; i < hit2DsLeft.Length; i++){
            if(hit2DsLeft[i].collider.gameObject.tag == "Platform") return true;
        }
        for(int i = 0; i < hit2DsRight.Length; i++){
            if(hit2DsRight[i].collider.gameObject.tag == "Platform") return true;
        }
        return false;
    }


}
