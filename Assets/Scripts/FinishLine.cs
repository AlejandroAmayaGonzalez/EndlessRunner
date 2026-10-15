using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

    [SerializeField] float reloadDelay = 1.5f;
    [SerializeField] ParticleSystem winParticleL;
    [SerializeField] ParticleSystem winParticleR;

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            winParticleL.Play();
            winParticleR.Play();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene(){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}
