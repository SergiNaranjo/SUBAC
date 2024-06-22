using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float cursorSpeed = 5f; // Velocidad del cursor
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posici�n actual del mouse en pantalla
        Vector3 targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z; // Mantener la misma posici�n Z del cursor

        // Obtener la posici�n actual del objeto (cursor)
        Vector3 currentPosition = transform.position;

        // Mover el objeto (cursor) suavemente hacia la posici�n del mouse
        transform.position = Vector3.Lerp(currentPosition, targetPosition, cursorSpeed * Time.deltaTime);
    }
}


