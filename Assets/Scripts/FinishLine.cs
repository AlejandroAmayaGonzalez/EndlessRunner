using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

    [SerializeField] float reloadDelay = 1f;

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene(){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}
