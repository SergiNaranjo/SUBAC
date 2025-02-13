using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float velocidadNormal = 5f; // Guardamos la velocidad original
    public float velocidadFreno = 3f;
    public GameObject balaPrefab;
    public Transform puntoDeDisparo;
    public float fuerzaDisparo = 10f;
    public float tiempoEntreDisparos = 0.2f;

    private float tiempoSiguienteDisparo = 0f;
    private Rigidbody2D rb;
    private float velocidadActual; // Variable para manejar la velocidad dinámica

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadActual = velocidadNormal; // Iniciar con la velocidad normal
    }

    void Update()
    {
        // Movimiento con Rigidbody2D
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(movimientoX, movimientoY) * velocidadActual;

        // Reducir la velocidad cuando se presiona Shift
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidadActual = velocidadFreno;
        }
        // Restaurar la velocidad normal cuando se suelta Shift
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadActual = velocidadNormal;
        }

        if (Input.GetButton("Fire1") && Time.time >= tiempoSiguienteDisparo)
        {
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.AddForce(puntoDeDisparo.right * fuerzaDisparo, ForceMode2D.Impulse);
    }
}




