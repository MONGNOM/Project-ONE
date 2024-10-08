using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rigid;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();   
    }

    public void Jump()
    {
        //rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        anim.SetTrigger("doTouch");
    }

}
