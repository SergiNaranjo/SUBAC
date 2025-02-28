using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidEnemy : MonoBehaviour
{
    public string bulletTag = "Bala"; // El tag de las balas que pueden dañar al enemigo
    private int health;

    void Start()
    {
        // Asigna una cantidad de vida aleatoria entre 6 y 9
        health = Random.Range(6, 10);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bulletTag))
        {
            TakeDamage();
            Destroy(collision.gameObject); // Destruir la bala al impactar
        }
    }

    void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destruye al enemigo
    }
}
