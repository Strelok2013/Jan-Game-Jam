using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //SpriteRenderer[] m_inactiveButtons = new SpriteRenderer[8];
    //SpriteRenderer[] m_incomingButtons = new SpriteRenderer[8];
    //SpriteRenderer[] m_activeButtons = new SpriteRenderer[8];

    public Sprite[] m_inactiveButtons = new Sprite[8];
    public Sprite[] m_incomingButtons = new Sprite[8];
    public Sprite[] m_activeButtons = new Sprite[8];

    Image[] m_displayImages = new Image[8];


    void Start()
    {
        RectTransform buttons = transform.GetChild(0).GetComponent<RectTransform>();

        for (int i = 0; i < 8; i++)
        {
            m_displayImages[i] = buttons.GetChild(i).GetComponent<Image>();
        }
        //Debug.Log("Successfully pulled all images into the array");
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }

    public void CheckForInputs(Vector2 playerAttack, Vector2 enemyAttack)
    {
        Vector2 upLeft = new Vector2(-1, 1);
        Vector2 upRight = new Vector2(1, 1);
        Vector2 bottomLeft = new Vector2(-1, -1);
        Vector2 bottomRight = new Vector2(1, -1);

        // Enemy attacks
        //if(enemyAttack != Vector2.zero)
        //{
        //}
        //else
        //{
        //      m_displayImages[0].sprite = m_inactiveButtons[0];
        //}

        // Player attacks

        if (playerAttack == bottomRight) //1
        {
             m_displayImages[7].sprite = m_activeButtons[7];
        }
        else if (enemyAttack == upLeft)
        {
              m_displayImages[7].sprite = m_incomingButtons[7];
        }

        if(playerAttack == Vector2.down) //2
        {
            m_displayImages[6].sprite = m_activeButtons[6];
        }
        else if(enemyAttack == Vector2.up)
        {
            m_displayImages[6].sprite = m_incomingButtons[6];
        }

        if(playerAttack == bottomLeft)
        {
            m_displayImages[5].sprite = m_activeButtons[5];
        }
        else if(enemyAttack == upRight)
        {
            m_displayImages[5].sprite = m_incomingButtons[5];
        }

        if(playerAttack == Vector2.right)
        {
            m_displayImages[4].sprite = m_activeButtons[4];
        }
        else if (enemyAttack == Vector2.left)
        {
            m_displayImages[4].sprite = m_incomingButtons[4];
        }

        if(playerAttack == Vector2.left)
        {
            m_displayImages[3].sprite = m_activeButtons[3];
        }
        else if(enemyAttack == Vector2.right)
        {
            m_displayImages[3].sprite = m_incomingButtons[3];
        }

        if(playerAttack == upRight)
        {
            m_displayImages[2].sprite = m_activeButtons[2];
        }
        else if(enemyAttack == bottomLeft)
        {
            m_displayImages[2].sprite = m_incomingButtons[2];
        }

        if(playerAttack == Vector2.up)
        {
            m_displayImages[1].sprite = m_activeButtons[1];
        }
        else if (enemyAttack == Vector2.down)
        {
            m_displayImages[1].sprite = m_incomingButtons[1];
        }

        if(playerAttack == upLeft)
        {
            m_displayImages[0].sprite = m_activeButtons[0];
        }
        else if(enemyAttack == bottomRight)
        {
            m_displayImages[0].sprite = m_incomingButtons[0];
        }

        // Turn off for all the arrows
        if (playerAttack != upLeft && enemyAttack != bottomRight)
        {

            m_displayImages[0].sprite = m_inactiveButtons[0];
        }

        if (playerAttack != Vector2.up && enemyAttack != Vector2.down)
        {

            m_displayImages[1].sprite = m_inactiveButtons[1];
        }
        if (playerAttack != upRight && enemyAttack != bottomLeft)
        {

            m_displayImages[2].sprite = m_inactiveButtons[2];
        }
        if (playerAttack != Vector2.left && enemyAttack != Vector2.right)
        {

            m_displayImages[3].sprite = m_inactiveButtons[3];
        }
        if (playerAttack != Vector2.right && enemyAttack != Vector2.left)
        {

            m_displayImages[4].sprite = m_inactiveButtons[4];
        }
        if (playerAttack != bottomLeft && enemyAttack != upRight)
        {

            m_displayImages[5].sprite = m_inactiveButtons[5];
        }
        if (playerAttack != Vector2.down && enemyAttack != Vector2.up)
        {

            m_displayImages[6].sprite = m_inactiveButtons[6];
        }
        if (playerAttack != bottomRight && enemyAttack != upLeft)
        {

            m_displayImages[7].sprite = m_inactiveButtons[7];
        }
        //if(playerAttack == Vector2.up) //2
        //{
        //      m_displayImages[1].sprite = m_activeButtons[1];
        //}
        //else if(enemyAttack == Vector2.up)
        //{
        //      m_displayImages[6].sprite = m_inactiveButtons[6];
        //}
        //else
        //{
        //    m_displayImages[1].sprite = m_inactiveButtons[1];
        //    m_displayImages[6].sprite = m_inactiveButtons[6];
        //}
        //
        //if (playerAttack == upRight) //3
        //{
        //    m_displayImages[2].sprite = m_activeButtons[2];
        //}
        //else if (enemyAttack == upRight)
        //{
        //    m_displayImages[5].sprite = m_inactiveButtons[5];
        //}
        //else
        //{
        //    m_displayImages[2].sprite = m_inactiveButtons[2];
        //    m_displayImages[5].sprite = m_inactiveButtons[5];
        //}
        //
        //if (playerAttack == Vector2.left)
        //{
        //    m_displayImages[3].sprite = m_activeButtons[3];
        //}
        //else if (enemyAttack == Vector2.left)
        //{
        //    m_displayImages[4].sprite = m_inactiveButtons[4];
        //}
        //else
        //{
        //    m_displayImages[3].sprite = m_inactiveButtons[3];
        //    m_displayImages[4].sprite = m_inactiveButtons[4];
        //}
        //
        //if (playerAttack == Vector2.right)
        //{
        //    m_displayImages[4].sprite = m_activeButtons[4];
        //}
        //else if (enemyAttack == Vector2.right)
        //{
        //    m_displayImages[3].sprite = m_inactiveButtons[3];
        //}
        //else
        //{
        //    m_displayImages[4].sprite = m_inactiveButtons[4];
        //    m_displayImages[3].sprite = m_inactiveButtons[3];
        //}
        //
        //if (playerAttack == bottomLeft)
        //{
        //    m_displayImages[5].sprite = m_activeButtons[5];
        //}
        //else if (enemyAttack == bottomLeft)
        //{
        //    m_displayImages[2].sprite = m_inactiveButtons[2];
        //}
        //else
        //{
        //    m_displayImages[5].sprite = m_inactiveButtons[5];
        //    m_displayImages[2].sprite = m_inactiveButtons[2];
        //}
        //
        //if (playerAttack == Vector2.down)
        //{
        //    m_displayImages[6].sprite = m_activeButtons[6];
        //}
        //else if (enemyAttack == Vector2.down)
        //{
        //    m_displayImages[1].sprite = m_inactiveButtons[1];
        //}
        //else
        //{
        //    m_displayImages[6].sprite = m_inactiveButtons[6];
        //    m_displayImages[1].sprite = m_inactiveButtons[1];
        //}
        //
        //if (playerAttack == bottomRight)
        //{
        //    m_displayImages[7].sprite = m_activeButtons[7];
        //}
        //else if (enemyAttack == bottomRight)
        //{
        //    m_displayImages[0].sprite = m_inactiveButtons[0];
        //}
        //else
        //{
        //    m_displayImages[7].sprite = m_inactiveButtons[7];
        //    m_displayImages[0].sprite = m_inactiveButtons[0];
        //}



    }

}



