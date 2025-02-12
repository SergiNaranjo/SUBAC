using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public Vector2 direccion = Vector2.left;

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Cambiar dirección al colisionar con un objeto
        direccion = -direccion;
    }
}
