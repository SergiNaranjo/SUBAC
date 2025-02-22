using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnemy : MonoBehaviour
{
    private MatarEnemigos killTracker;

    private void Start()
    {
        // Buscar automáticamente el EnemyKillTracker en la escena
        killTracker = FindObjectOfType<MatarEnemigos>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Verificar si el objeto colisionado es la bala
        if (col.gameObject.CompareTag("Bala"))
        {
            // Notificar al EnemyKillTracker antes de destruirse
            if (killTracker != null)
            {
                killTracker.EnemyKilled(gameObject);
            }

            // Destruir este GameObject (el enemigo)
            Destroy(gameObject);

            // Destruir la bala también
            Destroy(col.gameObject);
        }
    }
}

