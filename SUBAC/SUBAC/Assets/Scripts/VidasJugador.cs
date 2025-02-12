using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasJugador : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        // Verificar si el objeto colisionado es la bala del enemigo
        if (col.gameObject.CompareTag("BalaEnemigo"))
        {
            // Destruir el jugador
            Destroy(gameObject);
            // Opcional: Destruir la bala del enemigo también
            Destroy(col.gameObject);
        }
    }
}
