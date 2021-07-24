using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public  static  bool    GameIsPaused;
    private GameObject      painel;

    /// <Start>
    /// seta o gameispause como false
    /// pega o painel do menu de pause e desativa ele
    /// </Start>
    void Start()
    {
        GameIsPaused = false;
        painel = GameObject.Find("Panel");
        painel.SetActive(false);
    }

    /// <Update>
    /// verifica se o ESC foi usado, caso tenha sido pausa ou continua o jogo a partir da variavel gameispaused
    /// </Update>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Continue();
            } else {
                Pause();
            }
        }
    }

    /// <Continue>
    /// atribui o gameispaused como false
    /// coloca a velocidade do jogo como 1 
    /// desativa o painel de pause
    /// </Continue>
    public void Continue() {
        GameIsPaused = false;
        Time.timeScale = 1;
        painel.SetActive(false);
    }

    /// <Pause>
    /// atribui o gameispaused como true
    /// coloca a velocidade do jogo como 0 
    /// ativa o painel de pause
    /// </Pause>
    public void Pause() {
        GameIsPaused = true;
        Time.timeScale = 0;
        painel.SetActive(true);
    }

    /// <MainMenu>
    /// chama o continue para voltar a velocidade de jogo ao normal
    /// carrega a cena MainMenu
    /// </MainMenu>
    public void MainMenu() {
        Continue();
        SceneManager.LoadScene("MainMenu");
    }

    /// <Exit>
    /// Fecha o jogo
    /// </Exit>
    public void Exit() {
        Continue();
        Debug.Log("sai");
        Application.Quit();
    }
}
