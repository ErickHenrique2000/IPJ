using UnityEngine;

public class Enemy : MonoBehaviour
{
    public  float   vida = 100;

    public  float   velocidade, periodo;
    public  Rigidbody2D rb;
    private float   tempoCorrido = 0, lado = 1;

    /// <Update>
    /// verifica se a vida é menor que 0, caso seja desativa o inimigo
    /// </Update>
    void Update()
    {
        if(vida <= 0) {
            gameObject.SetActive(false);
        }
    }

    /// <FixedUpdate>
    /// verifica se o tempo decorrido desde a ultima troca de lado foi alcançada, caso tenha sido inverte o lado e reseta o tempo
    /// movimenta o inimigo com base a velocidade
    /// </FixedUpdate>
    private void FixedUpdate() {
        if(tempoCorrido > periodo) {
            rb.transform.localScale = new Vector3(rb.transform.localScale.x * -1, 1, 1);
	    tempoCorrido = 0;
            lado *= -1;
        }

        rb.position = new Vector2(rb.position.x + (lado * (velocidade * Time.fixedDeltaTime)), rb.position.y);

        tempoCorrido += Time.fixedDeltaTime;
    }

    /// <OnTriggerEnter2D>
    /// verifica se o objeto trigger possui a mesma tag(cor) que o inimigo, caso tenham destroi o objeto que o atingiu e remove 10 pontos de vida
    /// </OnTriggerEnter2D>
    private void OnTriggerEnter2D(Collider2D collision) {
        if (gameObject.CompareTag(collision.gameObject.tag)) {
            vida -= 10;
            Destroy(collision.gameObject);
        }
    }

    /// <OnCollisionEnter2D>
    /// verifica de o objeto que encostou é da tag player, caso seja remove 10 de vida do player
    /// </OnCollisionEnter2D>
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().vida -= 10;
        }
    }
}
