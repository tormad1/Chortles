using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hints : MonoBehaviour
{

    private static TMP_Text hintText;
    // Start is called before the first frame update
    void Start()
    {
        hintText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void energyHint()
    {
        hintText.text = "Low Energy";
        Debug.Log("Low Energy");
    }
}
