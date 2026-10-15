using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashController : MonoBehaviour{

    [SerializeField] float reloadDelay = 2f;
    [SerializeField] ParticleSystem deadParticles;
    
    PlayerController playerControl;

    void Start(){ playerControl = FindAnyObjectByType<PlayerController>(); }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Ground")){
            playerControl.CanControlPlayer = false;
            deadParticles.Play();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene(){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}
