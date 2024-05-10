using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    CharacterController2D characterController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();   
        character = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();    
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }

}
