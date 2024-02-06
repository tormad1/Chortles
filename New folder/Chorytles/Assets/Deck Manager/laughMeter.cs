using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;
using Unity.VisualScripting;

public class laughMeter : MonoBehaviour
{
    private static TMP_Text Laughtext;
    public static int laughValue;
    private static int oldVal;


    // Start is called before the first frame update
    void Start()
    {

        laughValue = 50;
        oldVal = laughValue;
        Laughtext = GetComponent<TMP_Text>();
        Laughtext.text = laughValue.ToString();

    }

    public static void laughChange()
    {
        Laughtext.text = laughValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
