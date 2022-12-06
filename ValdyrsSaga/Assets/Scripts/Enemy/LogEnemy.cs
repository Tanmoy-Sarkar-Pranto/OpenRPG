using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEnemy : Enemy
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRadius;
    [SerializeField] float attackRadius;
    [SerializeField] Vector3 homePosition;
    Rigidbody2D logRigidBody;
    
    
    bool shouldChase=false;
    Animator logAnimator;
    void Start()
    {
        currentState = EnemmyState.idle;
        logRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        logAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance() {
        if (Vector3.Distance(target.position, transform.position)<=chaseRadius){
            if((currentState == EnemmyState.idle || currentState == EnemmyState.walk) && currentState != EnemmyState.stagger){
                logAnimator.SetBool("isInterrupted", true);
                logAnimator.SetBool("seenPlayer", true);
                shouldChase = true;
                ChangeState(EnemmyState.walk);
            }
        }else{
            shouldChase = false;
        }
        Chase();
    }

    void Chase()
    {
        if(shouldChase==true){
            if(transform.position != target.position && Vector3.Distance(target.position, transform.position)> attackRadius){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, maxDistanceDelta: chaseSpeed*Time.deltaTime);
                changeAnim(temp - transform.position);
                logRigidBody.MovePosition(temp);
            }
        }
        else{
            // StartCoroutine(WaitCO());
            transform.position = Vector3.MoveTowards(transform.position, homePosition, maxDistanceDelta: moveSpeed*Time.deltaTime);
            if(transform.position==homePosition){
                logAnimator.SetBool("isInterrupted", false);
                logAnimator.SetBool("seenPlayer", false);
            }
        }
    }

    void ChangeState(EnemmyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }

    void SetAnimFloat(Vector2 setVector){
        logAnimator.SetFloat("moveX",setVector.x);
        logAnimator.SetFloat("moveY",setVector.y);
    }

    void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x)>Mathf.Abs(direction.y)){
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0){
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x)<Mathf.Abs(direction.y)){
            if(direction.y > 0){
                SetAnimFloat(Vector2.up);
            }else if(direction.y < 0){
                SetAnimFloat(Vector2.down);
            }
        }
    }

    // IEnumerator WaitCO()
    // {
    //     yield return new WaitForSeconds(2f);
        
    // }
}
