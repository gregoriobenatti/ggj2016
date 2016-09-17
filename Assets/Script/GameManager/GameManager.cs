using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Pause))]
[AddComponentMenu("Component/Script/GameManager")]
public class GameManager : GameStateMachine<GameManager>
{

    public enum States
    {
        Logo
      , Menu
      , Intro
      , Pause
      , Playing
      , GameOver
      , Win
    }

    public GameObject[] nextWaveLabels;

    public bool gameOver = false;

    private int wave;
    public int Wave {
        get { return wave; }
        set {
            wave = value;
            if (!gameOver) {
                for (int i = 0; i < nextWaveLabels.Length; i++) {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
            }
            // waveLabel.text = "WAVE: " + (wave + 1);
        }
    }

    public bool isPausePressed = false;
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameManager>();

            if(_instance == null)
            {
                GameObject singleton = new GameObject("GameManager");
                _instance = singleton.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(_instance);
            return _instance;
        }
    }

    private void Awake()
    {
        Initialize<States>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || isPausePressed){ //&& GetCurrentState().Equals(States.Playing)){
            // switch between play and pause...
            ChangeState(GetCurrentState().Equals(States.Pause) ? States.Playing : States.Pause);

            if(GetCurrentState().Equals(States.Pause)){
                Application.LoadLevelAdditive("ScreenPause");
                isPausePressed = false;
            } else if(GetCurrentState().Equals(States.Playing)) {
                Application.UnloadLevel("ScreenPause");
            }
        }
    }

    public void LoadLevel(String Scene)
    {
        Application.LoadLevel(Scene);
    }

    public static bool IsPlaying()
    {
        return true;
    }
}
