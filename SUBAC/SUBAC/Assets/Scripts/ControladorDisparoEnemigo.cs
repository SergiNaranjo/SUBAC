using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDisparoEnemigo : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public Transform shootingPoint; // Punto de disparo del enemigo

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - shootingPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            shootingPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180)); // Ajusta la dirección para disparar correctamente
        }
    }
}
