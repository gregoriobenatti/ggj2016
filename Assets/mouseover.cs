using UnityEngine;
using System.Collections;

public class mouseover : MonoBehaviour {

    public AudioClip click;
    public AudioSource audio = new AudioSource();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void play_sound()
    {
        AudioSource audio = GetComponent<AudioSource>();

        //Verifica se o mudo esta ativo ou nao.
        audio.mute = VariaveisGlobais.mudo;

        //Toca o som do click
        audio.clip = click;
        audio.Play();

    }
}
