using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;                        //The player's score.
    public Text scoreText;


    // Awake is called when it's initialized
    // So it can happen before start
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void RaccoonScored()
    {
        //The bird can't score if the game is over.
        if (gameOver)    
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
    }

    public void RaccoonDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
