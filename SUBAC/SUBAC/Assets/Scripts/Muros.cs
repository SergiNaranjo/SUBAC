using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muros : MonoBehaviour
{
    public List<string> tagsPermitidos = new List<string> { "Bala", "BalaEnemigo" }; // Agrega aquí los tags permitidos

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tagsPermitidos.Contains(other.tag)) // Verifica si el tag del objeto está en la lista
        {
            Debug.Log(other.name + " fue destruido al chocar con la barrera.");
            Destroy(other.gameObject); // Destruir el objeto
        }
    }
}
