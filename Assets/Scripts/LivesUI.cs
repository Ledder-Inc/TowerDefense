using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{

    public Text livesUI;

    // Update is called once per frame
    void Update()
    {
        livesUI.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
