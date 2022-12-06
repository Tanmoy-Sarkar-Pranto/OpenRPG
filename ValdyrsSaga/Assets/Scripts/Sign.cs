using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] string dialog;
    bool playerInRange;
    ValdyrMovement valdyrMovement;

    // Start is called before the first frame update
    void Start()
    {
        valdyrMovement = FindObjectOfType<ValdyrMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            if(dialogBox.activeInHierarchy){
                dialogBox.SetActive(false);
                valdyrMovement.currentState = ValdyrMovement.ValdyrState.idle;
            }else{
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                valdyrMovement.currentState = ValdyrMovement.ValdyrState.interact;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            // Debug.Log("Player in Range");
            playerInRange = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            // Debug.Log("Player out of range");
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
