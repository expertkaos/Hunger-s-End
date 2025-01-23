using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Lumin;

public class Tank_Movement : MonoBehaviour
{

    private float moveSpeed = 0f;
    [SerializeField] float moveSpeedReverse = 0f;
    [SerializeField] float moveAcceleration = 0.1f;
    [SerializeField] float moveDeceleration = 0.20f;
    [SerializeField] float moveSpeedMax = 2.5f;


    private float rotateSpeedRight = 0f;
    private float rotateSpeedLeft = 0f;
    [SerializeField] float rotateAcceleration = 0.5f;
    [SerializeField] float rotateDeceleration = 10f;
    [SerializeField] float rotateSpeedMax = 90f;


    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        if (Input.GetKey(KeyCode.W))
        {
            moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax;
        }
        else
        {
            moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);

        if (Input.GetKey(KeyCode.S))
        {
            moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax;
        }
        else
        {
            moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);
    }
}
