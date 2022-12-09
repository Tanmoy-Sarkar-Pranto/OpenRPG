using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite halfHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] FloatValue heartContainer;
    [SerializeField] FloatValue valdyrCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        ManageHeart();
    }

    public void ManageHeart()
    {
        for(int i=0;i<heartContainer.runtimeValue;i++){
            // Debug.Log("Heart");
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHeart()
    {
        float tempHealth = valdyrCurrentHealth.runtimeValue / 2;
        for(int i =0;i<heartContainer.runtimeValue;i++)
        {
            if(i<=tempHealth-1){
                //full heart
                hearts[i].sprite = fullHeart;
            }else if(i >= tempHealth){
                //empty heart
                hearts[i].sprite = emptyHeart;
            }else{
                //half full heart
                hearts[i].sprite = halfHeart;
            }
        }
    }
}
