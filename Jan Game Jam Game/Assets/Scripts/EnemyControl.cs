using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public enum Attacks
    {
        none,
        up,
        right,
        down,
        left,
        upRight,
        upLeft,
        downRight,
        downLeft
    }

    // Have a member variable of player or the player has a member variable of enemy
    // to keep track of what attack is happening and so and so?

    int[] m_attackPattern;


    public int m_numberOfAttacks = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyAttackAlgorithm()
    {
        // Some random shit to pull attacks
        // 8 different attacks

        for (int i = 0; i < m_numberOfAttacks; i++)// Generate enemy attack pattern???
        {
            m_attackPattern[i] = Random.Range(1, 9);
        }

        for (int i = 0; i < m_numberOfAttacks; i++)
        {
            switch (m_attackPattern[i])
            {
                case (int)Attacks.up:
                    // Do animation 1 I guess...
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)Attacks.down:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)Attacks.left:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)Attacks.right:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)Attacks.upLeft:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)Attacks.upRight:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)Attacks.downLeft:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)Attacks.downRight:
                    EnemyAttack(m_attackPattern[i]);
                    break;
            }
        }
    }

    void EnemyAttack(int direction)
    {
        switch (direction)
        {
            case 1:
                // Do animtion one??
                
                break;
        }
    }

}
