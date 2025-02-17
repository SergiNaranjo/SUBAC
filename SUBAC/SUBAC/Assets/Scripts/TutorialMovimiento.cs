using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovimiento : MonoBehaviour
{
    public GameObject[] waypoints; // Puntos que el jugador debe alcanzar
    public GameObject tutorialPanel; // Panel del tutorial (Canvas)
    public GameObject barrier; // Barrera que debe desaparecer
    private int reachedPoints = 0; // Contador de puntos alcanzados

    private void Start()
    {
        tutorialPanel.SetActive(true); // Asegurar que el tutorial esté visible al inicio
        barrier.SetActive(true); // Asegurar que la barrera esté activa al inicio
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (other.gameObject == waypoints[i]) // Si el jugador toca un waypoint
            {
                waypoints[i].SetActive(false); // Desactivar el waypoint alcanzado
                reachedPoints++;

                if (reachedPoints >= waypoints.Length) // Si ha llegado a todos
                {
                    CompleteTutorial();
                }
                break;
            }
        }
    }

    private void CompleteTutorial()
    {
        tutorialPanel.SetActive(false); // Ocultar el mensaje del tutorial
        barrier.SetActive(false); // Eliminar la barrera
        Debug.Log("Tutorial completado.");
    }
}
