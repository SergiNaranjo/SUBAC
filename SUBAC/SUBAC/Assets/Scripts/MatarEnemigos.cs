using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarEnemigos : MonoBehaviour
{
    private int currentKills = 0; // Contador de enemigos eliminados

    public List<GameObject> enemies; // Lista de enemigos asignados públicamente
    public GameObject effectObject; // Objeto que se activará y desactivará
    public GameObject barrier; // Objeto que desaparecerá
    public GameObject extraObject; // Objeto adicional que se desactivará
    public Camera mainCamera; // Cámara principal
    private int requiredKills; // Cantidad de enemigos a eliminar

    private void Start()
    {
        requiredKills = enemies.Count; // Establecer la cantidad de muertes requeridas según la cantidad de enemigos asignados
        barrier.SetActive(true); // Asegurar que la barrera esté activa al inicio
    }

    public void EnemyKilled(GameObject enemy)
    {
        if (enemies.Contains(enemy)) // Verificar si el enemigo está en la lista
        {
            enemies.Remove(enemy); // Eliminar el enemigo de la lista
            currentKills++;
            if (currentKills >= requiredKills)
            {
                StartCoroutine(EffectAndMoveCamera());
            }
        }
    }

    private IEnumerator EffectAndMoveCamera()
    {
        for (int i = 0; i < 6; i++) // Alternar activación 3 veces
        {
            effectObject.SetActive(!effectObject.activeSelf);
            yield return new WaitForSeconds(0.3f);
        }

        // Eliminar la barrera
        barrier.SetActive(false);

        // Desactivar el objeto extra
        if (extraObject != null)
        {
            extraObject.SetActive(false);
        }

        // Congelar el juego
        Time.timeScale = 0f;

        // Mover la cámara hacia arriba
        float duration = 1f;
        float elapsedTime = 0f;
        Vector3 initialPosition = mainCamera.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(0, 3f, 0); // Mover 3 unidades arriba

        while (elapsedTime < duration)
        {
            mainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        mainCamera.transform.position = targetPosition;

        // Restaurar el tiempo del juego
        Time.timeScale = 1f;
    }
}
