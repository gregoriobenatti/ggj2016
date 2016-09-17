using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
    public int initialPosition;
    public int finalPosition;
    public int enemyVelocity = 3;

    public string[] keyToKillArray = { "UpArrow", "DownArrow", "LeftArrow", "RightArrow" };
    private string keyToKill;


	// Use this for initialization
	void Start () {
        int k = Random.Range(0, keyToKillArray.Length);
        keyToKill = keyToKillArray[k];
	}

	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(finalPosition, 0, 0) * Time.deltaTime * enemyVelocity);

        if (transform.position.x < (-Screen.width-150)){
            Destroy(gameObject);
        }
	}

    void OnGUI() {
        Event e = Event.current;

        if (e.keyCode.ToString() == keyToKill) {
            Destroy(gameObject);
        }
    }
}
