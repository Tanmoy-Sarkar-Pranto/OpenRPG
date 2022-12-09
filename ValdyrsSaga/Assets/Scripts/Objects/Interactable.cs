using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public SignalSender clueSignOn;
    public SignalSender clueSignOff;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            // Debug.Log("Player in Range");
            playerInRange = true;
            clueSignOn.Raise();
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            // Debug.Log("Player out of range");
            playerInRange = false;
            clueSignOff.Raise();
        }
    }
}
