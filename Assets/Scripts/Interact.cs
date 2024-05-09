// 5/9/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private Animator animator;
    private InputAction interactAction;

    private void Awake()
    {
        // Reference to the Animator component
        animator = GetComponent<Animator>();

        // Setup the Interact input action
        interactAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/e");
        interactAction.performed += ctx => Interaction();
        interactAction.Enable();
    }

    private void Interaction()
    {
        // Trigger your animation here
        animator.SetTrigger("Interact");
    }

    private void OnDisable()
    {
        interactAction.Disable();
    }
}