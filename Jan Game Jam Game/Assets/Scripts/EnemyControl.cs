using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;

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
    [Range(0, 2)]
    public float m_AttackSpeed = 0.5f;
    [Range(0, 10)]
    public float m_delayBetweenAttacks = 1;
    [Range(0, 10)]
    public float m_delayBetweenPatterns = 3;

    private Vector2[] m_directions = {Vector2.up, Vector2.down, Vector2.left, Vector2.right,
                                    new Vector2(-1, 1), new Vector2(1, 1), new Vector2(-1, -1), new Vector2(1, -1)};

    private Queue<Vector2> m_attackPattern = new Queue<Vector2>();    

    private Animator animator;
    private int health;

    public bool OutOfAttacks { get; private set; } = false;
    public Vector2 AttackDirection { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        health = m_maxHealth;

        animator = GetComponentInChildren<Animator>();
        animator.speed = m_AttackSpeed;

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
            int direction = Random.Range(0, 7);
            m_attackPattern.Enqueue(m_directions[direction]);

            Debug.Log("Added " + DirectionString(m_directions[direction]) + " attack");
        }

        Invoke("PerformAttack", m_delayBetweenPatterns);
    }

    public void PerformAttack()
    {
        OutOfAttacks = false;

        AttackDirection = m_attackPattern.Dequeue();

        Debug.Log("Enemy attacking in " + DirectionString(AttackDirection) + " direction");
        
        animator.SetInteger("Horizontal", (int)AttackDirection.x);
        animator.SetInteger("Vertical", (int)AttackDirection.y);
    }

    public void HitPlayer()
    {
        gameManager.CompareAttacks();        
    }

    public void FinishAttack()
    {
        animator.SetInteger("Horizontal", 0);
        animator.SetInteger("Vertical", 0);

        if (m_attackPattern.Count > 0)
            Invoke("PerformAttack", m_delayBetweenAttacks);
        else
        {
            OutOfAttacks = true;
            CreateAttackPattern();
        }

        AttackDirection = Vector2.zero;
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

    private string DirectionString(Vector2 direction)
    {
        if (direction.y > 0) // up pressed
        {
            if (direction.x > 0)
                return "Up Right";
            else if (direction.x < 0)
                return "Up Left";
            else
                return "Up";               
            
        }
        else if (direction.y < 0) 
        {
            if (direction.x > 0)
                return "Down Right";
            else if (direction.x < 0)
                return "Down Left";
            else
                return "Down";
        }
        else if (direction.x < 0)
            return "Left";
        else if (direction.x > 0)
            return "Right";
        else
            return "Null";
    }

}