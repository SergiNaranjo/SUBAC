using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparosEnemigos : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDeDisparo; // Punto desde el cual se disparar� la bala
    public float fuerzaDisparo = 10f;
    public float tiempoEntreDisparos = 1f; // Tiempo en segundos entre disparos

    private float tiempoSiguienteDisparo = 0f;

    void Update()
    {
        // Disparo autom�tico
        if (Time.time >= tiempoSiguienteDisparo)
        {
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(puntoDeDisparo.right * fuerzaDisparo, ForceMode2D.Impulse);
    }
}
