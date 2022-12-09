using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValdyrMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D valdyrRigidbody;
    Animator valdyrAnimator;
    public ValdyrState currentState;
    Vector3 moveChange;
    [SerializeField] FloatValue valdyrHealth;
    [SerializeField] SignalSender valdyrHealthSignal;
    public VectorValue startingPosition;

    public enum ValdyrState{
        idle,
        walk,
        interact,
        attack,
        stagger
    }
    void Start()
    {
        currentState = ValdyrState.walk;
        valdyrRigidbody = GetComponent<Rigidbody2D>();
        valdyrAnimator = GetComponent<Animator>();
        valdyrAnimator.SetFloat("moveX", 0);
        valdyrAnimator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        moveChange = Vector3.zero;
        moveChange.x = Input.GetAxisRaw("Horizontal");
        moveChange.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("attack") && currentState!=ValdyrState.attack && currentState!=ValdyrState.stagger && currentState!=ValdyrState.interact){
            StartCoroutine(Attacking());
        }
        else if(currentState==ValdyrState.walk || currentState == ValdyrState.idle){
            BlendIdleandWalk();
        }
    }

    IEnumerator Attacking()
    {
        // valdyrAnimator.SetBool("isAttacking", true);
        // currentState = ValdyrState.attack;
        // yield return null;
        // valdyrAnimator.SetBool("isAttacking", false);
        // yield return new WaitForSeconds(0.4f);
        // currentState = ValdyrState.walk;
        // Debug.Log("Attacking");

        valdyrAnimator.SetTrigger("Attack");
        currentState = ValdyrState.attack;
        yield return new WaitForSeconds(.4f);
        currentState = ValdyrState.walk;
        valdyrAnimator.SetTrigger("Idle");
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

    public void knock(float knockTime, float damage)
    {
        valdyrHealth.runtimeValue -= damage;
        valdyrHealthSignal.Raise();
        if(valdyrHealth.runtimeValue > 0){
            
            StartCoroutine(KnockCO(knockTime));
        }
        else{
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator KnockCO(float knockTime){
        if(valdyrRigidbody!=null){
            yield return new WaitForSeconds(knockTime);
            valdyrRigidbody.velocity = Vector2.zero;
            currentState = ValdyrState.idle;
        }
    } 
}
