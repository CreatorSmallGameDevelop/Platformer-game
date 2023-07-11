using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public float maxSpeed = 5;
    public float jumpPower;
    Rigidbody2D rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        if(Input.GetButtonDown("Jump")){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if(Input.GetButtonUp("Horizontal")){
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f, rigid.velocity.y);
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if(rigid.velocity.x > maxSpeed){
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed*(-1)){
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);             
        }
    }
}
