using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour{

    public GameObject pauseMenu;
    public MenuManager menuManager;

    void Start(){  
        menuManager = FindAnyObjectByType<MenuManager>();
        // Hide the menu
        pauseMenu.SetActive(false);
    }

    void Update(){
        if (Keyboard.current.escapeKey.wasPressedThisFrame){
            if (Time.timeScale == 1f){
                Pause();
            }else{
                Continue();
            }
        }
    }

    // Show the menu and pause the game
    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Hide the menu and continue the game
    public void Continue(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu(){ 
        menuManager.BackToMainMenu();
        // Unfreeze level in case play again the level
        Time.timeScale = 1f;
    }
}
