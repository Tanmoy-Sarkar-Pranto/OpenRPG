using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSign : MonoBehaviour
{
    public GameObject clueSign;

    public void Enable(){
        clueSign.SetActive(true);
    }

    public void Disable()
    {
        clueSign.SetActive(false);
    }
}
