using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionTime = 2f;
    private Vector2 moveDirection;
    private float timer;

    void Start()
    {
        ChooseNewDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChooseNewDirection();
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void ChooseNewDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;
        timer = changeDirectionTime;
    }
}
