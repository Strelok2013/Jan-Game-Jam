using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // properties
    public AttackDir PlayerAttack { get; set; } = AttackDir.none;
    public AttackDir EnemyAttack { get; set; } = AttackDir.none;

    public int Score { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Invoked from animation event
    public void CompareAttacks()
    {
        if(PlayerAttack == AttackDir.none)
        {
            // damage player          
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
                }
                else
                {
                    // damage player
                }
            }
            else // even direction
            {
                if (playerDirection == enemyDirection - 1) // opposite direction
                {
                    // successful parry
                }
                else
                {
                    // damage player
                }
            }

        }

    }

}