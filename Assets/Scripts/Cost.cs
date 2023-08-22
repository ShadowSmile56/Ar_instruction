using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    // Start is called before the first frame update
    public int Sword_count = 0;
    public int Sword_price = 0;

    public int Total_gold = 0;

    void Start()
    {
        Total_gold = Sword_count * Sword_price;
        Debug.Log(Total_gold);
    }


}
