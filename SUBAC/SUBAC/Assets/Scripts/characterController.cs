using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float velocidad = 5f;
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDeDisparo; // Punto desde el cual se disparará la bala
    public float fuerzaDisparo = 10f;
    public float tiempoEntreDisparos = 0.2f; // Tiempo en segundos entre disparos

    private float tiempoSiguienteDisparo = 0f;

    void Update()
    {
        // Movimiento del personaje
        float movimientoX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float movimientoY = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        transform.Translate(movimientoX, movimientoY, 0);

        // Disparo con el clic izquierdo del ratón
        if (Input.GetButton("Fire1") && Time.time >= tiempoSiguienteDisparo)
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



