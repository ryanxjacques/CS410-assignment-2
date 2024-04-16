using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    
    public float turnSpeed = 20f;
    // ---
    // Sprint Feature
    private float walkLerp = 0f;
    public float walkSpeed = 1f;
    // ---
    // back to source code:
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
        
        MoveAction.Enable();
    }

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        // --------------
        // Sprint Feature 
        bool shiftPressed = false;
        
        // Check if shift button is pressed
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            shiftPressed = true;

        // Running only if walking AND shift pressed.
        bool isRunning = isWalking && shiftPressed;

        // Update smooth transition from walking and sprinting.
        walkLerpUpdate(isRunning);

        // --------------
        // Back to source code

        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    public Vector3 retPosition(){
        var pos = MoveAction.ReadValue<Vector3>();
        return pos;
    }
    // function from painting.cs
    /*
    void paintingResponse(Vector3 painting){

        // gets player position 
        var playerPos = PlayerObject.transform.position;
        float hor = playerPos.Normalize.x;
        float ver = playerPos.Normalize.y;

        // checks using dot product if the player is facing the right direction for the teleportation
        if((painting.x*hor)+(painting.y*ver) > 45){

            // teleports player to end of the level
            transform.position = new Vector3(13f,1f,1.5f);
        }
    }*/


    // Gradually increase or decrease walkSpeed if player is running.
    void walkLerpUpdate(bool isRunning)
    {
        float smoothFactor = 0.05f; 
        if (isRunning)
        {
            walkLerp += smoothFactor;
            walkLerp = Mathf.Min(walkLerp, 1.0f);
        } else {
            walkLerp -= smoothFactor;
            walkLerp = Mathf.Max(walkLerp, 0.0f);

        }
        // minSpeed, maxSpeed = 1.0, 5.0 respectively. 
        walkSpeed = Lerp(1.0f, 5.0f, walkLerp);
    }

    // Linear Interpolation Function.
    static float Lerp(float minVal, float maxVal, float lerpFactor)
    {
        // minVal is the lowest value Lerp can return
        // maxVal is the highest value Lerp can return
        // lerpFactor is a number between 0 and 1.
        // A lerpFactor of 0 will return 0% of maxVal and 100% of minVal.
        // A lerpFactor of 1 will return 100% of maxVal and 0% of minVal.
        
        // Clamp t between 0 and 1 to ensure interpolation stays within bounds
        lerpFactor = Mathf.Clamp01(lerpFactor);
        
        // Perform linear interpolation
        return minVal + (maxVal - minVal) * lerpFactor;
    }

    void OnAnimatorMove ()
    {
        // Modification: Added '* walkSpeed' to incorporate the sprint feature.
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * walkSpeed * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}