using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public  float       velocidade, jumpForce;
    public  float       lado;
    public  static  float   Direcao = 0;

    public  LayerMask   layerChao;

    public  GameObject  prefabPoder;

    public  float       vidaMaxima, vida;

    public  Animator    playerAnimator;

    private Rigidbody2D rb;
    private Transform   transformCheck;
    private bool        estaNoChao = false;

    /// <Start>
    /// O start ir�:
    /// Capturar o rigidbody do player
    /// Capturar o Transform do elemento GroundCheck que � filho do player
    /// Atualiar a vida que ser� utilizada em jogo com o valor da vida maxima
    /// </Start>
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        vida = vidaMaxima;
        transformCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
    }

    /// <Update> 
    /// O update ir�:
    /// Verificar se o jump foi precionado e caso tenha sido ira ver se o jogador est� no ch�o, caso esteja realliza o pulo
    /// Verificar a vida, caso seja menor ou igual a 0 deve ser carregado a fase de EndGame
    /// Ver o lado em que o jogador est� desejando ir, -1 para esquerda, 0 quando n�o preciona nada e 1 quando quer ir para a direita
    /// Atualizar a variavel dire��o que ser� usada pelo script do poder para saber para qual lado o poder deve ser lan�ado
    /// verificar se o bot�o R, o que lan�a o poder e verifica quais outros bot�es que controlam a cor do golpe est�o precionado e utiliza essas informa��es para controlar a cor do golpe
    /// </Update>
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            if(Physics2D.OverlapCircle(transformCheck.position, 0.15f, layerChao)) {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }

        if(lado != 0) {
            playerAnimator.SetBool("andando", true);
        } else {
            playerAnimator.SetBool("andando", false);
        }

        rb.transform.localScale = new Vector3(1, 1, 1);
        if(Direcao < 0) {
            rb.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (vida <= 0) {
            SceneManager.LoadScene("EndGame");
        }

        lado = Input.GetAxisRaw("Horizontal");
        if(lado != 0) {
            Direcao = lado;
        }
        
        if (Input.GetKeyDown(KeyCode.R)) {
            GameObject objeto = Instantiate(prefabPoder, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.identity);

            int r, g, b;
            r = g = b = 0;

            if (Input.GetKey(KeyCode.E)) {
                b = 1;
            }
            if (Input.GetKey(KeyCode.W)) {
                g = 1;
            }
            if (Input.GetKey(KeyCode.Q)) {
                r = 1;
            }

            objeto.GetComponent<PowerController>().SetCollor(r, g, b);
        }
    }

    /// <FixedUpdate>
    /// Move o rigidbody conforme o lado que o personagem planeja ir
    /// </FixedUpdate>
    private void FixedUpdate() {
        rb.position = new Vector3(rb.position.x + (velocidade * Time.fixedDeltaTime * lado), rb.position.y, 0);
    }
}
