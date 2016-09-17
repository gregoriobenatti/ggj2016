using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave {
    public GameObject enemyPrefab;
    public float spawnInterval = 5;
    public int maxEnemies = 20;
}


public class EnemySpaw : MonoBehaviour {

    public GameObject testEnemyPrefab;

    public Wave[] waves;
    public int timeBetweenWaves = 5;

    private GameManager gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    public int[] arraySpeed = { 5, 6, 7, 8, 9, 10, 20, 21, 22, 23, 24 };
    public int[] yPositionArray = { 120, 120, 130 };

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
        gameManager = GameManager.Instance;
	}

	// Update is called once per frame
	void Update () {
        int currentWave = gameManager.Wave;
        float timeInterval = Time.time - lastSpawnTime;

        float spawnInterval = waves[currentWave].spawnInterval;
        int maxEnemies = waves[currentWave].maxEnemies;

        if ((enemiesSpawned < maxEnemies) && (timeInterval > spawnInterval)) {
            GameObject newEnemy = (GameObject) Instantiate(testEnemyPrefab);

            int yPosition = Random.Range(0, yPositionArray.Length);
            newEnemy.transform.Translate(new Vector3(Screen.width, yPositionArray[yPosition] + 400,0));
            print(" " + yPositionArray[yPosition]);

            lastSpawnTime = Time.time;

            enemiesSpawned++;
        }

        if (enemiesSpawned == maxEnemies) {
            Application.LoadLevelAdditive("GameWin");
            Application.UnloadLevel("Level1");
        }
	}
}
