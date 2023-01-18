using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    SpriteRenderer[] m_inactiveButtons = new SpriteRenderer[8];
    SpriteRenderer[] m_incomingButtons = new SpriteRenderer[8];
    SpriteRenderer[] m_activeButtons = new SpriteRenderer[8];

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject arrowSet1 = transform.GetChild(0).gameObject;
        GameObject arrowSet2 = transform.GetChild(1).gameObject;
        GameObject arrowSet3 = transform.GetChild(2).gameObject;
        for (int i = 0; i < 8; i++)
        {
            m_inactiveButtons[i] = arrowSet1.transform.GetChild(i).GetComponent<SpriteRenderer>();
            Debug.Log("Adding in button " + arrowSet1.transform.GetChild(i).name + "from " + arrowSet1.name);
        }

        for (int i = 0; i < 8; i++)
        {
            m_incomingButtons[i] = arrowSet2.transform.GetChild(i).GetComponent<SpriteRenderer>();
            Debug.Log("Adding in button " + arrowSet2.transform.GetChild(i).name + "from " + arrowSet2.name);
        }
        
        for (int i = 0; i < 8; i++)
        {
            m_activeButtons[i] = arrowSet3.transform.GetChild(i).GetComponent<SpriteRenderer>();
            Debug.Log("Adding in button " + arrowSet3.transform.GetChild(i).name + "from " + arrowSet3.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetSprite(AttackDir dir)
    {
        // DO a thingy
    }
}
