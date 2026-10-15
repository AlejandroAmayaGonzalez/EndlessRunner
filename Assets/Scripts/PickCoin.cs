using UnityEngine;

public class PickCoin : MonoBehaviour {

    private GameManager gameManager;

    void Start(){ gameManager = FindAnyObjectByType<GameManager>(); }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){ 
            // Disable the coin completely
            gameObject.SetActive(false);

            // Call game method to update score
            gameManager.UpdateScore();
        }
    }
}
