using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemmyState{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public EnemmyState currentState;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float chaseSpeed;
    public float moveSpeed;
    public FloatValue maxHealth;

    void Awake()
    {
        health = maxHealth.initialValue;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0){
            this.gameObject.SetActive(false);
        }
    }

    public void knock(Rigidbody2D myRigidBody, float knockTime, float damage){
        StartCoroutine(KnockCO(myRigidBody,knockTime));
        TakeDamage(damage);
    }
    IEnumerator KnockCO(Rigidbody2D myRigidBody, float knockTime){
        if(myRigidBody!=null){
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemmyState.idle;
        }
    }  
}
