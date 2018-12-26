using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float acceleration;
    public float maxSpeed;
    
    // NOTE: references the rigid body component attached in unity
    private Rigidbody rigidBody;
    private KeyCode[] inputKeys;
    private Vector3[] directionsForKeys;
    
    void Start() {
        // NOTE: set "arrow keys"
        // TODO: switch to arrow keys
        inputKeys = new KeyCode[] { 
            KeyCode.W, 
            KeyCode.A, 
            KeyCode.S, 
            KeyCode.D 
        };

        // NOTE: attach directions for movement keys
        directionsForKeys = new Vector3[] { 
            Vector3.forward, 
            Vector3.left, 
            Vector3.back, 
            Vector3.right 
        };

        // NOTE: call rigid body component added in unity
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // TODO: refactor
        for (int i = 0; i < inputKeys.Length; i++){
            var key = inputKeys[i];

            if(Input.GetKey(key)) {
                // NOTE: Time.deltaTime represents the amount of time since last frame
                // Movement is dependent on frame rate so game isn't too fast/slow.
                Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
                movePlayer(movement);
            }
        }
    }

    // NOTE: applies force to rigid body
    void movePlayer(Vector3 movement) {
        // NOTE: if player is moving too fast, slow it down
        if(rigidBody.velocity.magnitude * acceleration > maxSpeed) {
            rigidBody.AddForce(movement * -1);
        } else {
            rigidBody.AddForce(movement);
        }
    }
}
