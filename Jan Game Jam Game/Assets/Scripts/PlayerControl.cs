using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    public float m_reactionTime = 1.0f;
    public int m_playerhealth = 3; 

    bool m_upDirection;
    bool m_downDirection;
    bool m_leftDirection;
    bool m_rightDirection;

    float m_timer = 0.0f;
    

    void Awake()
    {
        m_upDirection = false;
        m_downDirection = false;
        m_leftDirection = false;
        m_rightDirection = false;

      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKey(KeyCode.W))
        {
            m_upDirection = true;
        }
        else
        {
            m_upDirection = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_downDirection = true;
        }
        else
        {
            m_downDirection = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_leftDirection = true;
        }
        else
        {
            m_leftDirection = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rightDirection = true;
        }
        else
        {
            m_rightDirection = false;
        }

        if(m_upDirection && !m_leftDirection && !m_rightDirection && !m_downDirection)
        {
            // some nonsense
            Debug.DrawRay(transform.position, transform.up, Color.red);
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up, Color.white);
        }

        if (m_downDirection && !m_leftDirection && !m_rightDirection && !m_upDirection)
        {
            Debug.DrawRay(transform.position, -transform.up, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.white);
        }

        if (m_leftDirection && !m_upDirection && !m_downDirection && !m_rightDirection)
        {
            Debug.DrawRay(transform.position, -transform.right, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.right, Color.white);
        }

        if (m_rightDirection && !m_downDirection && !m_upDirection && !m_leftDirection)
        {
            Debug.DrawRay(transform.position, transform.right, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right, Color.white);
        }

        // Combined keys

        if (m_upDirection && m_leftDirection)
        {
            Vector3 combVec = -transform.right + transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.red);
        }
        else
        {
            Vector3 combVec = -transform.right + transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.white);
        }

        if (m_upDirection && m_rightDirection)
        {
            Vector3 combVec = transform.right + transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.red);
        }
        else
        {
            Vector3 combVec = transform.right + transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.white);
        }

        if (m_downDirection && m_leftDirection)
        {
            Vector3 combVec = -transform.right - transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.red);
        }
        else
        {
            Vector3 combVec = -transform.right - transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.white);
        }

        if (m_downDirection && m_rightDirection)
        {
            Vector3 combVec = transform.right - transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.red);
        }
        else
        {
            Vector3 combVec = transform.right - transform.up;
            Debug.DrawRay(transform.position, combVec.normalized, Color.white);
        }
    }

    


    void CheckPlayerReaction(bool correct)
    {
        while(m_timer < m_reactionTime)
        {
            m_timer += Time.deltaTime;
            if(correct)
            {
                m_timer = 0.0f; 
                // Block damage
                // Add score???
                break;
            }
            else
            {
                m_timer = 0.0f;
                // Take damage
                m_playerhealth -= 1;
                break;  
            }
        }
        // Take damage anyway...
        if(m_timer > m_reactionTime)
        {
            m_playerhealth -= 1;
            m_timer = 0.0f; 
        }
    }
}
