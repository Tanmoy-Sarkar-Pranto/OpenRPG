using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] Vector2 maxCameraChange;
    [SerializeField] Vector2 minCameraChange;
    [SerializeField] Vector3 playerPositionChange;

    [SerializeField] bool showText;
    [SerializeField] string placeName;
    [SerializeField] GameObject text;
    [SerializeField] Text placeText;
    [SerializeField] float placeNameShowTime;
    CameraMovement cameraMovement;
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Vector2 actualChangeMax = maxCameraChange-cameraMovement.maxCameraPosition;
            Vector2 actualChangeMin = minCameraChange-cameraMovement.minCameraPosition;
            cameraMovement.maxCameraPosition += actualChangeMax;
            cameraMovement.minCameraPosition += actualChangeMin;
            other.transform.position += playerPositionChange;

            if(showText){
                StartCoroutine(ShowPlaceName());
            }
        }   
    }

    IEnumerator ShowPlaceName(){
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(placeNameShowTime);
        text.SetActive(false);
    }
}
