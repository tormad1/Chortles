using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static TMP_Text ScoreText;
    public static int scoreValue;
    private static int oldVal;


    // Start is called before the first frame update
    void Start()
    {

        scoreValue = 0;
        oldVal = scoreValue;
        ScoreText = GetComponent<TMP_Text>();
        ScoreText.text = scoreValue.ToString();

    }

    public static void ScoreChange()
    {
        ScoreText.text = scoreValue.ToString();
        ScoreText.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
