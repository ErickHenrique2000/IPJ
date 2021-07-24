using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    /// <OnCollisionEnter2D>
    /// verifica de o objeto que encostou é da tag player, caso seja mata o player
    /// </OnCollisionEnter2D>
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().vida = 0;
        }
    }
}
