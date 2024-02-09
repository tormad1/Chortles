using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    private bool isThere;
    private bool isStall;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (roundManager.turn == "Player")
        {
            Collider2D detectedCollider = Physics2D.OverlapPoint(new Vector2(-4.5f, -1f));
            if (detectedCollider != null)
            {
                isThere=true;
                m_SpriteRenderer.color = Color.green;
            }
            else
            {
                isThere=false;
                m_SpriteRenderer.color = Color.red;
            }

            Collider2D detectedStall = Physics2D.OverlapPoint(new Vector2(1.5f, -3.5f));
            if (detectedStall != null)
            {
                
                isStall=false;
            }
            else
            {
                isStall = true;
            }
        }
    }
    private void OnMouseDown()
    {
        if (isThere && roundManager.turn == "Player"){
            if (isStall == true)
            {
                DeckData.attackVal=0;
                DeckData.typeVal=0;
            }
            m_SpriteRenderer.color = Color.blue;
            roundManager.CompareCards();
        }
    } 
}
