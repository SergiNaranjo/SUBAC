using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject panel1; // Primer panel del tutorial
    public GameObject panel2; // Segundo panel del tutorial

    private void Start()
    {
        Time.timeScale = 0f; // Pausar el juego mientras el tutorial está activo
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void NextPage()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    public void StartGame()
    {
        panel2.SetActive(false);
        Time.timeScale = 1f; // Reanudar el juego
    }
}
