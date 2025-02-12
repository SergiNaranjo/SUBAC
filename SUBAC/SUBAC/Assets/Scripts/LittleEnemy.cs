using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        // Verificar si el objeto colisionado es la bala
        if (col.gameObject.CompareTag("Bala"))
        {
            // Destruir este GameObject
            Destroy(gameObject);
            // Opcional: Destruir la bala también
            Destroy(col.gameObject);
        }
    }
}
