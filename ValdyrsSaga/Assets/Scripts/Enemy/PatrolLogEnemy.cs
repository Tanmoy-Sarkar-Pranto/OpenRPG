// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PatrolLogEnemy : LogEnemy
// {

//     public Transform[] path;
//     public int currentPoint;
//     public Transform currentGoal;
//     public float roundingDistance;

//     public override void CheckDistance() {
//         if (Vector3.Distance(target.position, transform.position)<=chaseRadius){
//             if((currentState == EnemmyState.idle || currentState == EnemmyState.walk) && currentState != EnemmyState.stagger){
//                 //logAnimator.SetBool("isInterrupted", true);
//                 logAnimator.SetBool("seenPlayer", true);
//                 shouldChase = true;
//                 //ChangeState(EnemmyState.walk);
//             }
//         }else{
//             shouldChase = false;
//             if(Vector3.Distance(transform.position,path[currentPoint].position)>roundingDistance){
//                 Vector3 temp = Vector3.MoveTowards(transform.position, target.position, maxDistanceDelta: chaseSpeed*Time.deltaTime);
//                 //changeAnim(temp - transform.position);
//                 logRigidBody.MovePosition(temp);
//             }
//             else{
//                 changeGoal();
//             }
//         }
//         Chase();
//     }

//     public override void Chase()
//     {
//         if(shouldChase==true){
//             if(transform.position != target.position && Vector3.Distance(target.position, transform.position)> attackRadius){
//                 Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, maxDistanceDelta: chaseSpeed*Time.deltaTime);
//                 //changeAnim(temp - transform.position);
//                 logRigidBody.MovePosition(temp);
//             }
//         }
        
//     }

//     private void changeGoal(){
//         if(currentPoint == path.Length - 1){
//             currentPoint = 0;
//             currentGoal = path[0];
//         }else{
//             currentPoint++;
//             currentGoal = path[currentPoint];
//         }
//     }
// }






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLogEnemy : LogEnemy
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;


	// overrride CheckDistance()
	public override void CheckDistance()
	{
		if (Vector3.Distance(target.position,
							 transform.position) <= chaseRadius
			&& Vector3.Distance(target.position,
								transform.position) > attackRadius)

		{

			if (currentState == EnemmyState.idle || currentState == EnemmyState.walk
				&& currentState != EnemmyState.stagger)
			{
				Vector3 temp = Vector3.MoveTowards(transform.position,
												   target.position,
												   moveSpeed * Time.deltaTime);

				changeAnim(temp - transform.position);
				logRigidBody.MovePosition(temp);

				// ChangeState(EnemyState.walk);
				logAnimator.SetBool("seenPlayer", true);
			}
		}
		else if (Vector3.Distance(target.position,
							 transform.position) > chaseRadius)
		{
            if (Vector3.Distance(transform.position,
                path[currentPoint].position) > roundingDistance)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                   path[currentPoint].position,
                                                   moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                logRigidBody.MovePosition(temp);
            } else
            {
                ChangeGoal();
            }

		}
	}


    private void ChangeGoal()
	{
        if(currentPoint == path.Length -1)
		{
            // reset everything
            currentPoint = 0;
            currentGoal = path[0];
		} else
		{
            currentPoint++;
            currentGoal = path[currentPoint];
		}
	}

}