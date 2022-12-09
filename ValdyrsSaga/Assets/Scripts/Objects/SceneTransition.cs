using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStoredPosition;
    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject fadeOutPanel;
    [SerializeField] float fadeWaitTime;

    private void Awake() {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerStoredPosition.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(FadeCO());
        }
    }

    public IEnumerator FadeCO()
    {
        if(fadeOutPanel != null){
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(fadeWaitTime);
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            while(!asyncOperation.isDone){
                yield return null;
            }
        }
    }
}
