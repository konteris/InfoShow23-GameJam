using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    public float speed = 15f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public GameObject Game;
    public bool reversed = false;
    private void Update()
    {
        if(Game.GetComponent<GameLoop>().level>=2)
            reversed= true;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        direction = GameLoop.ChangeMovingPositions(direction, reversed);
        //if kad jei horizatal -> x++; 

        //checkina inputa
        if (direction.magnitude >= 0.1f)
        {
            transform.forward = direction;
            controller.Move(direction * speed * Time.deltaTime);
        }
        if (transform.position.y != 1.70f)
        {
            Vector3 newPosition = transform.position; // get the current position
            newPosition.y = 1.70f; // change the y component to 2.0
            transform.position = newPosition;
        }
    }

}