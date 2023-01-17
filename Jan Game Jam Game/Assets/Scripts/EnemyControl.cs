using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameManager gameManager;

    public int m_maxHealth = 50;
    public int m_damagerPerAttack = 10;
    public int m_pointsWhenDestroyed = 1;

    [Header("Attacks In Pattern")]
    public int m_minAttacks = 3;
    public int m_maxAttacks = 5;

    [Header("Time Delays")]
    [Range(0, 10)]
    public float m_delayBetweenAttacks = 1;
    [Range(0, 10)]
    public float m_delayBetweenPatterns = 3;

    private Queue<AttackDir> m_attackPattern = new Queue<AttackDir>();

    private Animator animator;
    private int health;

    public bool OutOfAttacks { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        health = m_maxHealth;

        animator = GetComponent<Animator>();
        CreateAttackPattern();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAttackPattern()
    {
        int numberOfAttacks = Random.Range(m_minAttacks, m_maxAttacks);

        Debug.Log("Generating a pattern of " + numberOfAttacks + " attacks");

        for (int i = 0; i < numberOfAttacks; i++)// Generate enemy attack pattern???
        {
            int direction = Random.Range(1, 9);
            m_attackPattern.Enqueue((AttackDir)direction);

            Debug.Log("Added " + (AttackDir)direction + " attack");
        }

        //Debug.Log("New Attack Pattern:" + m_attackPattern);

        Invoke("PerformAttack", m_delayBetweenPatterns);
    }

    public void PerformAttack()
    {
        OutOfAttacks = false;

        AttackDir direction = m_attackPattern.Dequeue();

        Debug.Log("Enemy attacking in " + direction + " direction");

        gameManager.EnemyAttack = direction;
        animator.SetInteger("direction", (int)direction);

        if (m_attackPattern.Count > 0)
            Invoke("PerformAttack", m_delayBetweenAttacks);
        else
        {
            OutOfAttacks = true;
            CreateAttackPattern();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            // increase score
            gameManager.AddPoints(m_pointsWhenDestroyed);

            GameObject.Destroy(this);
        }
    }

}