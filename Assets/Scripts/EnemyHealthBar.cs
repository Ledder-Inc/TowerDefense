using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealthBar : MonoBehaviour
{
    private Enemy enemy;
    private float healthBarYScale;
    private float healthBarXScale;
    private float healthBarZScale;
    public Transform healthNow;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log("Health: " + enemy.health);
        //Debug.Log("enemy.healthPct: " + ((enemy.healthMax / enemy.healthMax) * enemy.health / 100));
        //Debug.Log("Zielwert: " + (((enemy.healthMax / enemy.healthMax) * enemy.health / 100) * 0.51f));
        healthBarYScale = (((enemy.healthMax / enemy.healthMax) * enemy.health / 100) * 0.51f);
        healthBarXScale = 0.31f;
        healthBarZScale = 0.31f;
        if (healthBarYScale <= 0)
            healthBarYScale = 0;

        healthNow.localScale = new Vector3(healthBarXScale, healthBarYScale, healthBarZScale);
    }
}
