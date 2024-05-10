// 5/10/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class Interact : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //TriggerSmallPixelPop();
    }


    void Update()
    {
        // Check for the "E" key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerSmallPixelPop();

        }
    }


    void TriggerSmallPixelPop()
    {
        // Set a trigger parameter to start the animation
        animator.SetTrigger("smallPixelPop");
    }
}