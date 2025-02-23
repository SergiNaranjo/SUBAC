using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnemy : MonoBehaviour
{
    private MatarEnemigos killTracker;
    private MatarEnemigosUltimoTutorial killTracker2;
    private EnemyWave killTracker3;

    private void Start()
    {
        // Buscar autom�ticamente el EnemyKillTracker en la escena
        killTracker = FindObjectOfType<MatarEnemigos>();
        killTracker2 = FindObjectOfType<MatarEnemigosUltimoTutorial>();
        killTracker3 = FindObjectOfType<EnemyWave>();
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

            if (killTracker2 != null)
            {
                killTracker2.EnemyKilled(gameObject);
            }

            if (killTracker3 != null)
            {
                killTracker3.EnemyKilled(gameObject);
            }

            // Destruir este GameObject (el enemigo)
            Destroy(gameObject);

            // Destruir la bala tambi�n
            Destroy(col.gameObject);
        }
    }
}


