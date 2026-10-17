using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    
    /// <summary>
    /// Main menu options
    /// </summary>
    public void PlayGame(){ SceneManager.LoadScene("LevelSelection"); }
    public void SeeCredits(){ SceneManager.LoadScene("Credits"); }
    public void Controls(){ SceneManager.LoadScene("Controls"); }
    public void QuitPlay(){ Application.Quit(); }

    /// <summary>
    /// Back possibilities
    /// </summary>
    public void BackToLevelSelection(){ SceneManager.LoadScene("LevelSelection"); }
    public void BackToMainMenu(){ SceneManager.LoadScene("MainMenu"); }

    // Select level, character
    public void SelectChar(String levelName) {
        LevelName.levelName = levelName;
        SceneManager.LoadScene("CharSelect"); 
    }

    // Character is selected, stored to show and then play the level
    public void PlayLevel(int charIndex){ 
        PlayerPrefs.SetInt("SelectedCharacter", charIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(LevelName.levelName); 
    }
}
