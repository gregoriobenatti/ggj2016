using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sentais : MonoBehaviour {

    public GameObject sentai1;
    public GameObject sentai2;
    public GameObject sentai3;

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;

    public int life = 7;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (life <= 0) {
            print("Game Over!");
            GameManager.Instance.LoadLevel("GameOver");
        }
        // if (life <= 3) {
        //     Text warning = GameObject.FindObjectOfType<Text>();
        //     warning.text = "WARNING!!!";
        // }

        anim1.SetInteger("CatDefaultState", Random.Range(0, 4));
        anim2.SetInteger("CatDefaultState", Random.Range(0, 4));
        anim3.SetInteger("CatDefaultState", Random.Range(0, 4));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy"){
            // print("oncollisionenter2d - enter");
            sentai1.transform.Translate(new Vector3(-100, 0, 0));
            sentai2.transform.Translate(new Vector3(-80, 0, 0));
            sentai3.transform.Translate(new Vector3(-100, 0, 0));

            // anim1.SetInteger("CatDefaultState", 0);
            // anim2.SetInteger("CatDefaultState", 0);
            // anim3.SetInteger("CatDefaultState", 0);
            // anim1.SetInteger("CatDefaultState", 5);
            // anim2.SetInteger("CatDefaultState", 5);
            // anim3.SetInteger("CatDefaultState", 5);

            life -= 1;
            Text lifeCounter = GameObject.FindObjectOfType<Text>();
            lifeCounter.text = life.ToString();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy"){
            // print("oncollisionenter2d - exit");
            sentai1.transform.Translate(new Vector3(100, 0, 0));
            sentai2.transform.Translate(new Vector3(80, 0, 0));
            sentai3.transform.Translate(new Vector3(100, 0, 0));

            // anim1.SetInteger("CatDefaultState", 0);
            // anim2.SetInteger("CatDefaultState", 0);
            // anim3.SetInteger("CatDefaultState", 0);
            // anim1.SetInteger("CatDefaultState", 1);
            // anim2.SetInteger("CatDefaultState", 2);
            // anim3.SetInteger("CatDefaultState", 3);
        }
    }
}
