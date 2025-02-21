using System.Collections;
using UnityEngine;

public class TutorialMovimiento : MonoBehaviour
{
    public GameObject[] waypoints; // Puntos que el jugador debe alcanzar
    public GameObject tutorialPanel; // Panel del tutorial (Canvas)
    public GameObject barrier; // Barrera que debe desaparecer
    public GameObject effectObject; // Objeto que se activar� y desactivar�
    public GameObject finalText; // Texto final que se activar�
    public Camera mainCamera; // C�mara principal
    private int reachedPoints = 0; // Contador de puntos alcanzados

    private void Start()
    {
        tutorialPanel.SetActive(true); // Asegurar que el tutorial est� visible al inicio
        barrier.SetActive(true); // Asegurar que la barrera est� activa al inicio
        finalText.SetActive(false); // Asegurar que el texto final est� desactivado al inicio
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
        StartCoroutine(EffectAndMoveCamera());
    }

    private IEnumerator EffectAndMoveCamera()
    {
        for (int i = 0; i < 6; i++) // Alternar activaci�n 3 veces
        {
            effectObject.SetActive(!effectObject.activeSelf);
            yield return new WaitForSeconds(0.3f);
        }

        // Congelar el juego
        Time.timeScale = 0f;

        // Mover la c�mara hacia arriba
        float duration = 2f;
        float elapsedTime = 0f;
        Vector3 initialPosition = mainCamera.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(0, 5f, 0); // Mover 3 unidades arriba

        while (elapsedTime < duration)
        {
            mainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        mainCamera.transform.position = targetPosition;

        // Restaurar el tiempo del juego
        Time.timeScale = 1f;

        // Activar el texto final
        finalText.SetActive(true);
    }
}



