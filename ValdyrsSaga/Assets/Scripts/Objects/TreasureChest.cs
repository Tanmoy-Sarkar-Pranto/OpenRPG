using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item content;
    public Inventory inventory;
    public SignalSender receiveItem;
    public GameObject dialogWindow;
    public Text dialogText;
    public bool isOpen;
    Animator tcAnimator;
    // Start is called before the first frame update
    void Start()
    {
        tcAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            if(!isOpen){
                OpenChest();
            }else{
                ChestAlreadyOpen();
            }
        }
    }

    void OpenChest()
    {
        dialogWindow.SetActive(true);
        dialogText.text = content.itemDescription;
        inventory.AddItem(content);
        inventory.currentItem = content;
        receiveItem.Raise();
        clueSignOff.Raise();
        isOpen = true;
        tcAnimator.SetBool("isOpen", true);
    }

    void ChestAlreadyOpen()
    {
        dialogWindow.SetActive(false);
        inventory.currentItem = null;
        isOpen = true;
        receiveItem.Raise();
        playerInRange = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !isOpen){
            // Debug.Log("Player in Range");
            playerInRange = true;
            clueSignOn.Raise();
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !isOpen){
            // Debug.Log("Player out of range");
            playerInRange = false;
            clueSignOff.Raise();
        }
    }
}
