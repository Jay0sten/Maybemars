using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpectatorController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

    float movementX;
    float movementY;

    private void Start()
    {

    }

    private void Update()
    {
        MoveSpeed = Input.GetKey(KeyCode.LeftShift) ? 20 : 5;

        Vector3 moveMe = new Vector3(movementX, movementY, 0);
        transform.Translate(moveMe * MoveSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVectory = movementValue.Get<Vector2>();
        movementX = movementVectory.x;
        movementY = movementVectory.y;
    }
}
