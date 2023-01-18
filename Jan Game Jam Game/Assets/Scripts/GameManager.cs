using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // references
    public PlayerControl player;
    public EnemyControl enemy;

    // properties
    public AttackDir PlayerAttack { get; set; } = AttackDir.none;
    public AttackDir EnemyAttack { get; set; } = AttackDir.none;

    public int Score { get; private set; } = 0;

    private bool gameRunning = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameRunning)
            Time.timeScale = 0;
    }

    public void AddPoints(int amount)
    {
        Score += amount;
    }

    // Invoked from animation event
    public void CompareAttacks()
    {
        if(PlayerAttack == AttackDir.none)
        {
            DamagePlayer();
        }
        else
        {
            int enemyDirection = (int)EnemyAttack;
            int playerDirection = (int)PlayerAttack;

            if(enemyDirection%2 == 1) // odd direction
            {
                if(playerDirection == enemyDirection + 1) // opposite direction
                {
                    // successful parry
                    Debug.Log("You successfully parried the attack");
                }
                else
                {
                    DamagePlayer();
                }
            }
            else // even direction
            {
                if (playerDirection == enemyDirection - 1) // opposite direction
                {
                    // successful parry
                    Debug.Log("You successfully parried the attack");
                }
                else
                {
                    DamagePlayer();
                }
            }

        }

    }

    private void DamagePlayer()
    {
        player.m_playerhealth -= enemy.m_damagerPerAttack;

        Debug.Log("Player takes " + enemy.m_damagerPerAttack + " damage. " +
                  "Health Left: " + player.m_playerhealth);

        if(player.m_playerhealth <= 0)
        {
            Debug.Log("Player has died. Game Over");
            gameRunning = false;
        }
    }

}