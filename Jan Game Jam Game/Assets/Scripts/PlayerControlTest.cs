using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlTest : MonoBehaviour
{
    public float m_playerhealth;

    float vInput, hInput;    

    public Vector2 AttackDirection { get; private set; } = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        if (vInput > 0) // up pressed
        {
            if (hInput > 0)
            {
                AttackDirection = new Vector2(1, 1); // up right     
            }
            else if (hInput < 0)
            {
                AttackDirection = new Vector2(-1, 1); // up left
            }
            else
            {
                AttackDirection = Vector2.up;
            }
        }
        else if (vInput < 0) // down pressed
        {
            if (hInput > 0)
            {
                AttackDirection = new Vector2(1, -1); // down right
            }
            else if (hInput < 0)
            {
                AttackDirection = new Vector2(-1, -1); // down left
            }
            else
            {
                AttackDirection = Vector2.down;
            }
        }
        else if (hInput < 0) // left pressed
        {
            AttackDirection = Vector2.left;
        }
        else if (hInput > 0) // right pressed
        {
            AttackDirection = Vector2.right;
        }

        if(vInput == 0 && hInput == 0)
        {
            AttackDirection = Vector2.zero;
        }

        if (AttackDirection != Vector2.zero)
            Debug.DrawRay(transform.position, AttackDirection, Color.red);
    }
}
