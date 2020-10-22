using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(ColumnSpawning))]
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText, wave2, wave3, wave4;
    public bool showSkull = false;
    public float waitime = 2f;
    public Text scoreText;
    public Text wave1;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        /*else if( instance != null)
        {
            Destroy(gameObject);
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (ColumnSpawning.instance.afterTime <= 0)
        {
            wave2.SetActive(true);
        }
        if (ColumnSpawning.instance.afterTime2 <= 0)
        {
            wave3.SetActive(true);
        }
        if (ColumnSpawning.instance.afterTime3 <= 0)
        {
            wave4.SetActive(true);
        }
    }
    public void BirdScored()
    {
        if(gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
