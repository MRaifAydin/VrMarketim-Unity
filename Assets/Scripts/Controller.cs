using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 3.5f;
    public float fast = 10f;
    public float gravity = 10f;
    Vector3 velocity;
    private CharacterController characterController;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity = direction * fast;
        }
        else { velocity = direction * speed; }

        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        characterController.Move(velocity * Time.deltaTime);

    }
}
