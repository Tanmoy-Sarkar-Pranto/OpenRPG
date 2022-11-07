using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValdyrMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D valdyrRigidbody;
    Animator valdyrAnimator;
    Vector3 moveChange;
    void Start()
    {
        valdyrRigidbody = GetComponent<Rigidbody2D>();
        valdyrAnimator = GetComponent<Animator>();
        valdyrAnimator.SetBool("isWalking", false);
    }

    void Update()
    {
        moveChange = Vector3.zero;
        moveChange.x = Input.GetAxisRaw("Horizontal");
        moveChange.y = Input.GetAxisRaw("Vertical");
        BlendIdleandWalk();
    }

    void BlendIdleandWalk()
    {
        if(moveChange!=Vector3.zero)
        {
            Movement();
            valdyrAnimator.SetBool("isWalking", true);
            valdyrAnimator.SetFloat("moveX", moveChange.x);
            valdyrAnimator.SetFloat("moveY", moveChange.y);
        }else{
            valdyrAnimator.SetBool("isWalking", false);
        }
    }

    void Movement()
    {
            Vector3 newPosition = transform.position+moveChange.normalized*moveSpeed*Time.deltaTime;
            valdyrRigidbody.MovePosition(newPosition);
            valdyrAnimator.SetBool("isWalking", true);
    }
}
