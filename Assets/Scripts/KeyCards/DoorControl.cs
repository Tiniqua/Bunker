using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorControl : MonoBehaviour
{

    public bool blueKeyCard;
    public bool greenKeyCard;
    public bool redKeyCard;

    // Start is called before the first frame update
    void Start()
    {
        blueKeyCard = false;
        redKeyCard = false;
        greenKeyCard = false;
    }

}
