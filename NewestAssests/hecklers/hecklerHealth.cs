using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hecklerHealth : MonoBehaviour
{
    private static TMP_Text HealthText;
    public static int healthValue;
    private static int oldVal;


    // Start is called before the first frame update
    void Start()
    {

        healthValue = 10;
        oldVal = healthValue;
        HealthText = GetComponent<TMP_Text>();
        HealthText.text = healthValue.ToString();

    }

    public static void healthChange()
    {
        HealthText.text = healthValue.ToString();
        HealthText.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
