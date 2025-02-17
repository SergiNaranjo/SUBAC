using UnityEngine;
using TMPro;  // Aseg�rate de incluir el espacio de nombres para TextMeshPro
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public Image imagenVida; // Referencia a la imagen de vida
    public TextMeshProUGUI textoVida;   // Referencia al componente TextMeshProUGUI
    public characterController personaje; // Referencia al personaje

    void Update()
    {
        // Actualiza la barra de vida seg�n la vida del jugador
        float vidaPorcentaje = Mathf.Clamp01((float)personaje.vida / 100f);
        imagenVida.fillAmount = vidaPorcentaje;
        ActualizarColor(vidaPorcentaje);

        // Actualiza el texto con el n�mero de vida restante seguido del s�mbolo '%'
        textoVida.text = personaje.vida.ToString() + "%";
    }

    void ActualizarColor(float porcentaje)
    {
        if (porcentaje > 0.5f)
        {
            imagenVida.color = Color.green;
        }
        else if (porcentaje > 0.2f)
        {
            imagenVida.color = Color.yellow;
        }
        else
        {
            imagenVida.color = Color.red;
        }
    }
}



