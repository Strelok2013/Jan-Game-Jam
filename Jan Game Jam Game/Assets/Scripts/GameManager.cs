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

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [Header("Object References")]
    public PlayerControlTest player;
    public EnemyControl enemy;
    public UIManager m_UIManagerRef;

    [Header("UI Objects")]
    public TextMeshProUGUI m_scoreText;
    public TextMeshProUGUI m_healthText;
    public GameObject m_parryDisplay;
    public TextMeshProUGUI m_pointIncreaseText;

    [Header("Scoring")]
    public int m_parryPoints = 5;

    [Header("Timers")]
    [Range(0f, 2f)]
    public float parryTextDisplayTime = 1;
    float m_timer = 0.0f;
    public float m_reactionTime = 1.0f;

    [Header("Sound Effects")]
    public AudioClip m_swingSound;
    public AudioClip m_parrySound;
    public AudioClip m_hitSound;

    public int Score { get; private set; } = 0;

    private bool gameRunning = true;

    private AudioSource m_audio;

    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();

        if (m_scoreText)
            m_scoreText.text = Score.ToString();
        else
            Debug.Log("Score " + Score);

        m_healthText.text = player.m_playerhealth.ToString();

        m_parryDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameRunning)
            Time.timeScale = 0;

        m_UIManagerRef.CheckForInputs(player.AttackDirection, enemy.AttackDirection);
    }

    public void AddPoints(int amount)
    {
        Score += amount;

        if (m_scoreText)
            m_scoreText.text = Score.ToString();
        else
            Debug.Log("Score " + Score);        
    }

    // Invoked from animation event
    public void CompareAttacks()
    {     
        // checks if attacks are opposites
        while(m_timer < m_reactionTime)
        {
            m_timer += Time.deltaTime;
            if(player.AttackDirection == -enemy.AttackDirection)
            {
                Debug.Log("You successfully parried the attack");

                // successful parry
                StartCoroutine(Parry());

                m_timer = 0.0f;
                break;
            }
            else
            {
                DamagePlayer();
                m_timer = 0.0f;
                break;
            }
        }
        if(m_timer > m_reactionTime)
        {
            DamagePlayer();
            m_timer = 0.0f;
        }

    }


    private void DamagePlayer()
    {
        player.m_playerhealth -= enemy.m_damagerPerAttack;

        //Debug.Log("Player takes " + enemy.m_damagerPerAttack + " damage. " +
                  //"Health Left: " + player.m_playerhealth);

        m_healthText.text = player.m_playerhealth.ToString();

        m_audio.PlayOneShot(m_hitSound);

        if(player.m_playerhealth <= 0)
        {
            Debug.Log("Player has died. Game Over");
            gameRunning = false;
        }
    }

    public void PlaySwingSound()
    {
        m_audio.PlayOneShot(m_swingSound);
    }

    private IEnumerator Parry()
    {
        AddPoints(m_parryPoints);
        m_audio.PlayOneShot(m_parrySound);

        m_parryDisplay.SetActive(true);
        m_pointIncreaseText.text = "+ " + m_parryPoints;

        yield return new WaitForSeconds(parryTextDisplayTime);

        m_parryDisplay.SetActive(false);
    }

}