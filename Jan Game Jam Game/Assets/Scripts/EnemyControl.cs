using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackDir
{
    none,
    up,
    down,
    left,
    right,
    upRight,
    downLeft,
    upLeft,
    downRight    
}

public class EnemyControl : MonoBehaviour
{

    // Have a member variable of player or the player has a member variable of enemy
    // to keep track of what attack is happening and so and so?

    //int[] m_attackPattern;    

    //public int m_numberOfAttacks = 8;

    public GameManager gameManager;

    [Header("Attacks In Pattern")]
    public int minAttacks = 3;
    public int maxAttacks = 5;

    [Range(0, 10)]
    public float delayBetweenAttacks = 3;

    Queue<AttackDir> m_attackPattern = new Queue<AttackDir>();

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CreateAttackPattern();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAttackPattern()
    {
        int numberOfAttacks = Random.Range(minAttacks, maxAttacks);

        for (int i = 0; i < numberOfAttacks; i++)// Generate enemy attack pattern???
        {
            int direction = Random.Range(1, 9);
            m_attackPattern.Enqueue((AttackDir)direction);
        }        

        Invoke("PerformAttack", delayBetweenAttacks);
    }

    public void PerformAttack()
    {
        AttackDir direction = m_attackPattern.Dequeue();

        gameManager.EnemyAttack = direction;
        animator.SetInteger("direction", (int)direction);

        if (m_attackPattern.Count > 0)
            Invoke("PerformAttack", delayBetweenAttacks);
        else
            CreateAttackPattern();
    }

    /*
    public void EnemyAttackAlgorithm()
    {
        // Some random shit to pull attacks
        // 8 different attacks

        for (int i = 0; i < m_numberOfAttacks; i++)// Generate enemy attack pattern???
        {

            int direction = Random.Range(1, 9);
            m_attackPattern.Enqueue((AttackDir)direction);

            //m_attackPattern[i] = Random.Range(1, 9);
        }

        for (int i = 0; i < m_numberOfAttacks; i++)
        {
            AttackDir direction = m_attackPattern.Dequeue();

            animator.SetInteger("direction", (int)direction);
            /*
            switch (direction[i])
            {
                case (int)AttackDir.up:
                    // Do animation 1 I guess...
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)AttackDir.down:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)AttackDir.left:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)AttackDir.right:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)AttackDir.upLeft:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)AttackDir.upRight:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)AttackDir.downLeft:
                    EnemyAttack(m_attackPattern[i]);
                    break;
                case (int)AttackDir.downRight:
                    EnemyAttack(m_attackPattern[i]);
                    break;
            }
        }
    }*/

    /*
    void EnemyAttack(AttackDir direction)
    {
        switch (direction)
        {
            case AttackDir.up:
                // Do animtion one??
                
                break;

            case AttackDir.down:

                break;

            case AttackDir.left:

                break;

            case AttackDir.right:

                break;

            case AttackDir.upLeft:

                break;

            case AttackDir.downLeft:
                break;

            case AttackDir.upRight:

                break;

            case AttackDir.downRight:

                break;
        }
    }*/

}
