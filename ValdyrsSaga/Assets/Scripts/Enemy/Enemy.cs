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
    public int health;
    public string enemyName;
    public int baseAttack;
    public float chaseSpeed;
    public float moveSpeed;
    
    public void knock(Rigidbody2D myRigidBody, float knockTime){
        StartCoroutine(KnockCO(myRigidBody,knockTime));
    }
    IEnumerator KnockCO(Rigidbody2D myRigidBody, float knockTime){
        if(myRigidBody!=null){
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemmyState.idle;
        }
    }  
}
