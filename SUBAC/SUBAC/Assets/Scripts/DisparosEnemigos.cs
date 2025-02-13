using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparosEnemigos : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDeDisparo; // Punto desde el cual se disparará la bala
    public float fuerzaDisparo = 10f;
    public float tiempoEntreDisparos = 1f; // Tiempo en segundos entre disparos
    public Transform objetivo; // Referencia al jugador

    private float tiempoSiguienteDisparo = 0f;

    void Update()
    {
        // Disparo automático
        if (Time.time >= tiempoSiguienteDisparo)
        {
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            Disparar();
        }
    }

    void Disparar()
    {
        // Calcular la dirección hacia el objetivo en el momento del disparo
        Vector2 direccionDisparo = (objetivo.position - puntoDeDisparo.position).normalized;

        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.velocity = direccionDisparo * fuerzaDisparo;
    }
}

