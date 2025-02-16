using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float velocidadNormal = 5f;
    public float velocidadFreno = 3f;
    public GameObject balaPrefab;
    public Transform puntoDeDisparo;
    public float fuerzaDisparo = 10f;
    public float tiempoEntreDisparos = 0.2f;
    public int vida = 100; // Vida inicial del jugador
    public GameObject[] vidas; // Referencia a los GameObjects que representan las vidas
    public GameObject jugador; // Referencia al GameObject del jugador
    private int vidasRestantes; // N�mero de vidas restantes
    private bool perdiendoVida = false; // Controla si ya se ha ejecutado el proceso de perder vida

    private float tiempoSiguienteDisparo = 0f;
    private Rigidbody2D rb;
    private float velocidadActual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadActual = velocidadNormal;
        vidasRestantes = vidas.Length; // Establecer el n�mero de vidas iniciales
    }

    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(movimientoX, movimientoY) * velocidadActual;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidadActual = velocidadFreno;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadActual = velocidadNormal;
        }

        if (Input.GetButton("Fire1") && Time.time >= tiempoSiguienteDisparo)
        {
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            Disparar();
        }

        // Verificar si la vida llega a 0
        if (vida <= 0 && vidasRestantes > 0 && !perdiendoVida)
        {
            perdiendoVida = true; // Evitar que se ejecute de nuevo durante este ciclo
            PerderVida();
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, Quaternion.identity);
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.velocity = Vector2.up * fuerzaDisparo;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BalaEnemigo")) // Aseg�rate de que las balas enemigas tienen este tag
        {
            RecibirDa�o(10);
            Destroy(other.gameObject); // Destruir la bala enemiga al impactar
        }
    }

    void RecibirDa�o(int cantidad)
    {
        if (vida > 0)
        {
            vida -= cantidad;
            Debug.Log("Vida restante: " + vida);
        }

        if (vida <= 0 && vidasRestantes > 0 && !perdiendoVida)
        {
            perdiendoVida = true;
            PerderVida();
        }
    }

    void PerderVida()
    {
        // Desactivar una vida visual
        if (vidasRestantes > 0)
        {
            vidas[vidasRestantes - 1].SetActive(false);
            vidasRestantes--;
        }

        // Si ya no quedan vidas
        if (vidasRestantes <= 0)
        {
            TerminarJuego();
        }
        else
        {
            // Hacer desaparecer al jugador
            jugador.SetActive(false);

            // Volver a aparecer al jugador despu�s de 5 segundos
            Invoke("ReaparecerJugador", 5f);
        }
    }

    void ReaparecerJugador()
    {
        // Restaurar la vida del jugador
        vida = 100;

        // Hacer reaparecer al jugador
        jugador.SetActive(true);

        // Restablecer el flag de "perdiendo vida"
        perdiendoVida = false;
    }

    void TerminarJuego()
    {
        // Aqu� puedes agregar la l�gica para finalizar el juego, por ejemplo:
        Debug.Log("Juego terminado. Has perdido.");
        // Pausar el juego o mostrar una pantalla de Game Over
        Time.timeScale = 0f; // Esto pausa el juego
    }
}






