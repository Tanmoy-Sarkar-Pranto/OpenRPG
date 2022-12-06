using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] float knockBack;
    [SerializeField] float knockTime;
    [SerializeField] float damage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Enemy") ||other.gameObject.CompareTag("Player")){
            Rigidbody2D myRigidBody = other.GetComponent<Rigidbody2D>();
            if(myRigidBody!=null){
                if(other.gameObject.CompareTag("Enemy") && other.isTrigger){
                    myRigidBody.GetComponent<Enemy>().currentState = EnemmyState.stagger;
                    other.GetComponent<Enemy>().knock(myRigidBody, knockTime, damage);
                }
                if(other.gameObject.CompareTag("Player")){
                    myRigidBody.GetComponent<ValdyrMovement>().currentState = ValdyrMovement.ValdyrState.stagger;
                    other.GetComponent<ValdyrMovement>().knock(knockTime);
                }
                Vector2 distance = myRigidBody.transform.position - transform.position;
                distance = distance.normalized * knockBack;
                myRigidBody.AddForce(distance, ForceMode2D.Impulse);
            }
        }    
    }

     
}
