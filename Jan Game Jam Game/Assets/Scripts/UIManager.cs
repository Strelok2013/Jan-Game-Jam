using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    SpriteRenderer[] m_inactiveButtons = new SpriteRenderer[8];
    SpriteRenderer[] m_incomingButtons = new SpriteRenderer[8];
    SpriteRenderer[] m_activeButtons = new SpriteRenderer[8];

    public PlayerControlTest m_playerRef;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject arrowSet1 = transform.GetChild(0).gameObject;
        GameObject arrowSet2 = transform.GetChild(1).gameObject;
        GameObject arrowSet3 = transform.GetChild(2).gameObject;
        for (int i = 0; i < 8; i++)
        {
            m_inactiveButtons[i] = arrowSet1.transform.GetChild(i).GetComponent<SpriteRenderer>();
            //Debug.Log("Adding in button " + arrowSet1.transform.GetChild(i).name + "from " + arrowSet1.name);
        }

        for (int i = 0; i < 8; i++)
        {
            m_incomingButtons[i] = arrowSet2.transform.GetChild(i).GetComponent<SpriteRenderer>();
            //Debug.Log("Adding in button " + arrowSet2.transform.GetChild(i).name + "from " + arrowSet2.name);
        }
        
        for (int i = 0; i < 8; i++)
        {
            m_activeButtons[i] = arrowSet3.transform.GetChild(i).GetComponent<SpriteRenderer>();
            //Debug.Log("Adding in button " + arrowSet3.transform.GetChild(i).name + "from " + arrowSet3.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(m_playerRef.)
    }


    public void CheckForInputs(Vector2 playerAttack, Vector2 enemyAttack)
    {
        //Temp vecs??
        Vector2 upLeft = new Vector2(-1,1);
        Vector2 upRight = new Vector2(1, 1);
        Vector2 downLeft = new Vector2(-1, -1);
        Vector2 downRight = new Vector2(1, -1);


        // Player input
        if(playerAttack == Vector2.up)
        {
            m_activeButtons[1].enabled = true;
        }
        else
        {
            m_activeButtons[1].enabled = false;
        }
        if (playerAttack == upLeft)
        {
            m_activeButtons[0].enabled = true;
        }
        else
        {
            m_activeButtons[0].enabled = false;
        }
        if(playerAttack == upRight)
        {
            m_activeButtons[2].enabled = true;
        }
        else
        {
            m_activeButtons[2].enabled = false;
        }
        if (playerAttack == Vector2.left)
        {
            m_activeButtons[3].enabled = true;
        }
        else
        {
            m_activeButtons[3].enabled = false;
        }
        if (playerAttack == Vector2.down)
        {
            m_activeButtons[6].enabled = true;
        }
        else
        {
            m_activeButtons[6].enabled = false;
        }
        if (playerAttack == downLeft)
        {
            m_activeButtons[5].enabled = true;
        }
        else
        {
            m_activeButtons[5].enabled = false;
        }
        if (playerAttack == downRight)
        {
            m_activeButtons[7].enabled = true;
        }
        else
        {
            m_activeButtons[7].enabled = false;
        }
        if (playerAttack == Vector2.right)
        {
            m_activeButtons[4].enabled = true;
        }
        else
        {
            m_activeButtons[4].enabled = false;
        }

        // Enemy Input
        if (enemyAttack == Vector2.up)
        {
            m_incomingButtons[6].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
        if(enemyAttack == upLeft)
        {
            m_incomingButtons[7].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
        if (enemyAttack == upRight)
        {
            m_incomingButtons[5].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
        if (enemyAttack == Vector2.left)
        {
            m_incomingButtons[4].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
        if (enemyAttack == Vector2.down)
        {
            m_incomingButtons[1].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
        if (enemyAttack == downLeft)
        {
            m_incomingButtons[2].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
        if (enemyAttack == downRight)
        {
            m_incomingButtons[0].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
        if (enemyAttack == Vector2.right)
        {
            m_incomingButtons[3].enabled = true;
        }
        else
        {
            m_incomingButtons[6].enabled = false;
        }
    }

}
