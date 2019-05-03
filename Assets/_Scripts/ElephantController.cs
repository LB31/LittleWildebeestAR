using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public float speed = 3.0F;
    public float rotateSpeed = 1.5F;

    private int input;
    private int rotator;

    public Transform[] StuffToCollect;

    private int collectionCounter;
    public GameObject speechBubble;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        // Rotate around y - axis
        transform.Rotate(0, rotator * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * input;
        characterController.SimpleMove(forward * curSpeed);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        foreach (Transform item in StuffToCollect) {
            if(hit.transform.Equals(item)) {
                Destroy(hit.transform.gameObject);
                collectionCounter++;
            }
        }
        if(collectionCounter == StuffToCollect.Length) {
            speechBubble.SetActive(true);
        }
    }

    public void GetInput(int input) {
        this.input = input;
        if (input == 0) animator.SetBool("walk", false);
        else animator.SetBool("walk", true);
    }

    public void GetRotation(int rotation) {
        rotator = rotation;
    }
}
