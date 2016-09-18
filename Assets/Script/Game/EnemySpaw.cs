using UnityEngine;
using System.Collections;


[System.Serializable]
public class Wave {
    public GameObject enemyPrefab;
    public float spawnInterval = 5;
    public int maxEnemies = 20;

	public int[] arraySpeed = { 5, 6, 7, 8, 9, 10, 20, 21, 22, 23, 24 };
}


public class EnemySpaw : MonoBehaviour {

    public GameObject testEnemyPrefab;

    public Wave[] waves;
    public int timeBetweenWaves = 5;
	private int currentWave = 0; //gameManager.Wave;
	private bool start_next_have = false;

    private GameManager gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    public int[] yPositionArray = { 120, 120, 130 };

	IEnumerator StartedQuest()
	{
//		print ("start corrotine");
		yield return new WaitForSeconds(timeBetweenWaves);
//		print ("finish corrotine");

		start_next_have = true;
	}

	public int getRandomEnemySpeed(){
		int[] speed = waves[currentWave].arraySpeed;
		int index = Random.Range (0, speed.Length - 1);

		return speed[index];
	}

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
        gameManager = GameManager.Instance;
	}

	// Update is called once per frame
	void Update () {
		float timeInterval = Time.time - lastSpawnTime;

		float spawnInterval = waves[currentWave].spawnInterval;
        int maxEnemies = waves[currentWave].maxEnemies;

        if ((enemiesSpawned < maxEnemies) && (timeInterval > spawnInterval)) {
            GameObject newEnemy = (GameObject) Instantiate(testEnemyPrefab);

			EnemyMove em = newEnemy.GetComponent<EnemyMove>();
			em.enemyVelocity = getRandomEnemySpeed();

            int yPosition = Random.Range(0, yPositionArray.Length);
            newEnemy.transform.Translate(new Vector3(Screen.width, yPositionArray[yPosition] + 400,0));
//            print(" " + yPositionArray[yPosition]);

            lastSpawnTime = Time.time;

            enemiesSpawned++;
        }

        if (enemiesSpawned >= maxEnemies) {
			StartCoroutine (StartedQuest ());

			if (start_next_have == true) {
				enemiesSpawned = 0;
				currentWave += 1;

				start_next_have = false;
			}

			if ((currentWave > waves.Length)) {
				print ("explodiu a poha toda...");

				Application.LoadLevelAdditive("GameWin");
				Application.UnloadLevel("Level1");
			}
        }
	}
}
