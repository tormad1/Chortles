using UnityEngine;

public class energyCounter : MonoBehaviour
{
    public static int energyValue;
    public static int energyMax;
    public static int tempVal;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    private SpriteRenderer spriteBar;



    // Start is called before the first frame update
    void Start()
    {

        energyMax = 5;
        energyValue = 5;
        tempVal = energyValue;
        spriteBar = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        Debug.Log("value - " + tempVal);
        switch (tempVal)
        {
            case 1:
                spriteBar.sprite = sprite1;
                break;
            case 2:
                spriteBar.sprite = sprite2;
                break;
            case 3:
                spriteBar.sprite = sprite3;
                break;
            case 4:
                spriteBar.sprite = sprite4;
                break;
            case 5:
                spriteBar.sprite = sprite5;
                break;
        }
    }


    public static void energyChange()
    {
        energyValue = tempVal;
    }

    public static void energySet()
    {
        tempVal = energyValue;
    }
}
