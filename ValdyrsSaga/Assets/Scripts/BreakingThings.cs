using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingThings : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="breakable")
        {
            other.GetComponent<Pot>().onHit();
        }
    }
}
