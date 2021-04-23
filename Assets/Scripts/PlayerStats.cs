using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney;

    public static int KillCounter;

    public static int Lives;
    public int startLives= 20;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        KillCounter = 0;
        Rounds = 0;
    }


}
