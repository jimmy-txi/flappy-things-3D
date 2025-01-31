using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainscreen_manager : MonoBehaviour
{
    // Méthode appelée quand le bouton "Play" est cliqué
    public void PlayGame()
    {
        // Remplace "GameScene" par le nom de ta scène principale
        SceneManager.LoadScene("Game");
    }

    public void CreditsGame()
    {

        SceneManager.LoadScene("Credits");
    }

    // Méthode appelée quand le bouton "Quit" est cliqué
    public void QuitGame()
    {
        // Quitte le jeu (fonctionne uniquement dans un build, pas dans l'éditeur)
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
