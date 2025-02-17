using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muros : MonoBehaviour
{
    public string bulletTag = "Bala"; // Cambia esto al tag de las balas

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(bulletTag)) // Si la bala toca el objeto
        {
            Debug.Log(other.name + " fue destruido al chocar con la barrera.");
            Destroy(other.gameObject); // Destruir la bala
        }
    }
}
