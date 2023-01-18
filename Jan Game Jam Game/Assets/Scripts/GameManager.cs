using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState
{
    running,
    win, 
    lose
}

public class GameManager : MonoBehaviour
{
    // references
    public PlayerControlTest player;
    public EnemyControl enemy;

    public TextMeshProUGUI scoreText;

    public int parryPoints = 5;

    // properties
    //public AttackDir PlayerAttack { get; set; } = AttackDir.none;
    //public AttackDir EnemyAttack { get; set; } = AttackDir.none;

    public int Score { get; private set; } = 0;

    private bool gameRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText)
            scoreText.text = Score.ToString();
        else
            Debug.Log("Score " + Score);
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

        if (scoreText)
            scoreText.text = Score.ToString();
        else
            Debug.Log("Score " + Score);
    }

    // Invoked from animation event
    public void CompareAttacks()
    {
        // checks if attacks are opposites
        if(player.AttackDirection == -enemy.AttackDirection)
        {
            // successful parry                    
            Debug.Log("You successfully parried the attack");
            AddPoints(parryPoints);
        }
        else
        {
            DamagePlayer();
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