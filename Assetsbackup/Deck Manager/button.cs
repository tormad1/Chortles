using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    private bool isThere;
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
        }
    }
    private void OnMouseDown()
    {
        if (isThere && roundManager.turn == "Player"){
            m_SpriteRenderer.color = Color.blue;
            roundManager.CompareCards();
        }
    } 
}
