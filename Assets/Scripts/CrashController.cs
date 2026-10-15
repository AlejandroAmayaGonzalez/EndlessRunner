using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashController : MonoBehaviour{

    [SerializeField] float reloadDelay = 2f;
    [SerializeField] ParticleSystem deadParticles;
    
    PlayerController playerControl;

    void Start(){ playerControl = FindAnyObjectByType<PlayerController>(); }

    // Ground crash
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Ground")){
            playerControl.CanControlPlayer = false;
            deadParticles.Play();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    // Rock crash
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            playerControl.CanControlPlayer = false;
            deadParticles.Play();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene(){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}
