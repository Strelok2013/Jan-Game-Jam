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

    [Header("Attacks In Pattern")]
    public int minAttacks = 3;
    public int maxAttacks = 5;

    [Header("Time Delays")]
    [Range(0, 10)]
    public float delayBetweenAttacks = 1;
    [Range(0, 10)]
    public float delayBetweenPatterns = 3;

    private Queue<AttackDir> m_attackPattern = new Queue<AttackDir>();

    private Animator animator;

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

        Debug.Log("Generating a pattern of " + numberOfAttacks + " attacks");

        for (int i = 0; i < numberOfAttacks; i++)// Generate enemy attack pattern???
        {
            int direction = Random.Range(1, 9);
            m_attackPattern.Enqueue((AttackDir)direction);

            Debug.Log("Added " + (AttackDir)direction + " attack");
        }

        //Debug.Log("New Attack Pattern:" + m_attackPattern);

        Invoke("PerformAttack", delayBetweenPatterns);
    }

    public void PerformAttack()
    {
        AttackDir direction = m_attackPattern.Dequeue();

        Debug.Log("Enemy attacking in " + direction + " direction");

        gameManager.EnemyAttack = direction;
        animator.SetInteger("direction", (int)direction);

        if (m_attackPattern.Count > 0)
            Invoke("PerformAttack", delayBetweenAttacks);
        else
            CreateAttackPattern();
    }

}
