using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    /// <StartGame>
    /// carrega a fase inicial
    /// </StartGame>
    public void StartGame() {
        SceneManager.LoadScene("Phase");
    }

    /// <Exit>
    /// Fecha o jogo
    /// </Exit>
    public void ExitGame() {
        Debug.Log("sai");
        Application.Quit();
    }

    /// <MainMenu>
    /// carrega a cena MainMenu
    /// </MainMenu>
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
