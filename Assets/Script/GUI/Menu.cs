using System;
using UnityEngine;
using System.Linq;
using System.Collections;


public static class VariaveisGlobais
{
    public static bool mudo = false;

}

public class Menu : GameStateMachine<Menu>
{

    public enum States{
        None
      , SelectLevel
      , Options
      , Cast
    }

    //public AudioClip click;
    public AudioClip bgmusic;
    public AudioSource audio = new AudioSource();

    private GameObject[] Buttons;

    private void Awake()
    {
        Initialize<States>();
        Buttons = GameObject.FindGameObjectsWithTag("UIButton");        
        Play_Sound();       
    }

    private void Play_Sound()
    {
        AudioSource audio = GetComponent<AudioSource>();

        //Verifica se o mudo esta ativo ou nao.
        audio.mute = VariaveisGlobais.mudo;

        //Toca a musica de fundo.
        AudioSource audiobg = GetComponent<AudioSource>();
        audiobg.clip = bgmusic;
        audiobg.loop = true;
        audiobg.Play();
        
    }

    private void Update()
    {
    }

    public void Play()
    {
        GameManager.Instance.LoadLevel("Level1");
        GameManager.Instance.ChangeState(GameManager.States.Playing);
    }

    public void Pause()
    {
        print("pause from Menu.cs");
        GameManager.Instance.isPausePressed = true;
        GameManager.Instance.ChangeState(GameManager.States.Pause);
    }

    public void Unpause()
    {
        Application.UnloadLevel("ScreenPause");
        GameManager.Instance.isPausePressed = false;
        GameManager.Instance.ChangeState(GameManager.States.Playing);
    }

    public void SelectLevel()
    {
        ChangeState(States.SelectLevel);
    }

    public void Options()
    {
        ChangeState(States.Options);
    }

    public void Cast()
    {
        // ChangeState(States.Cast);
        GameManager.Instance.LoadLevel("Credits");
    }

    public void LoadHome()
    {
        GameManager.Instance.LoadLevel("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleButtons(bool Show)
    {
        Buttons.ToList().ForEach(g => g.gameObject.SetActive(Show));
    }
}
