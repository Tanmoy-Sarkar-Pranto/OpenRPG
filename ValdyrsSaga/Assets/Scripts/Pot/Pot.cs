using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{  
    Animator potAnimator;
    void Start()
    {
        potAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void onHit()
    {
        StartCoroutine(Hit());

    }

    IEnumerator Hit()
    {
        potAnimator.SetBool("isHit", true);
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
