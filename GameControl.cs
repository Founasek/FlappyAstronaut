using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    [Header("Gameobjects")]
    public GameObject Spaceship;
    public GameObject Explode;
    public GameObject UFO;

   
    [Header("Boolean")]
    public bool StarGame = false;
    public bool gameOver = false;
    public bool reverseGravity;
    
    [Header("Text")]
    public Text scoredeath;
    public Text scoreText;
    public GameObject StartGameText;
    public GameObject GravityChangeText;

    [Header("General")]
    public Rigidbody2D playerRB;
    public float scrollSpeed = -1.5f;
    public ParticleSystem Rockets;
    public AudioClip ExplosionBoom;
    public Ads theAds;
    public GameObject gameOverMenu;

    private int score = 0;
    private AudioSource myAudio;
    private int gravity;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        myAudio = GetComponent<AudioSource>();
        Invoke("MakeGravity", 0.0f);
        InvokeRepeating("Changegravity", 10.0f, 10.0f); 
    }

    void Update()
    {
        if (StarGame == true)
        {
            Time.timeScale = 1;
            StartGameText.SetActive(false);
            UFO.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        if (score == 10)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_achievement_10_points);
        }
        else if (score == 15)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_achievement__15_points);
        }
        else if (score == 20)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_achievement__20_points);
        }
        else if (score == 25)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_achievement__25_points);
        }
        else if (score == 30)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_achievement__30_points);
        }
        else if (score == 50)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_achievement__50_points);
        }
        else if (score == 100)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_achievemet__100_points);
        }
    }

    public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }

    public void ShowAchievements()
    {
        PlayGamesScript.ShowAchievementsUI();
    }

    public void Restart()
    {
        if (gameOver)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RateGame()
    {
        Application.OpenURL("market://details?id=com.JanFoune.FlappyAstronaut");
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        else
        {
            score = score + 1;
            SetScore();
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                   {
                        PlayerPrefs.SetInt("HighScore", score);
                    }
        }
    }

    public void SetScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_leaderboard, score);
        gameOverMenu.SetActive(true);
        gameOver = true;
        Rockets.Stop();
        theAds.AdsShow();
        playerRB.gravityScale = 1;
        StartCoroutine(Explosion());
        scoredeath.text = "Score: " + score.ToString();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void MakeGravity()
    {
        reverseGravity = true;
        playerRB.gravityScale = -1;
    }

    public void Changegravity()
    {
        if (gameOver == false)
        {
            gravity = Random.Range(0, 3);
            if (gravity == 0 && reverseGravity == true)
            {
                StartCoroutine(GravityChange0());
                reverseGravity = false;
                playerRB.gravityScale = 1;

            }
            else if (gravity == 1 && reverseGravity == false)
            {
                StartCoroutine(GravityChange0());
                reverseGravity = true;
                playerRB.gravityScale = -1;
            }
            else
            {
                Debug.Log("No Gravity Change");
            }
        }
    }

    IEnumerator GravityChange0()
    {
        GravityChangeText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        GravityChangeText.SetActive(false);
    }

    IEnumerator Explosion()
    {
        // wait for 2 second
        yield return new WaitForSeconds(2.0f);
        Explode.transform.parent = null;
        Spaceship.SetActive(false);
        Explode.SetActive(true);
        myAudio.PlayOneShot(ExplosionBoom);
    }













}
