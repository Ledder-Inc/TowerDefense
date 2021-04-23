using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killCounter;
    // Update is called once per frame
    void Update()
    {
        killCounter.text = PlayerStats.KillCounter.ToString();
    }
}
