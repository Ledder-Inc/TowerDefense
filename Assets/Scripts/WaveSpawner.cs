using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 2f;
    private float countdown = 2f;

    public Text waveCountdownText;

    System.Random rand = new System.Random();

    private int waveIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);

    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incoming!");
        waveIndex++;
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //IEnumerator -> erforderlich um Objects versetzt zu erzeugen.
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //LogEnemyCount();
    }

    private void LogEnemyCount()
    {
        //Anazhl der Enemies loggen
        //Debug.Log("Enemies on the Map: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
        //Debug.Log("random number. " + rand.Next(0,100));
    }
}
