using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public GameManager gameManager;

    public void HitPlayer()
    {
        gameManager.CompareAttacks();
    }
}
