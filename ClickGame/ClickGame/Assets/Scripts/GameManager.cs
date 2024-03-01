using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI gameOverText;

    public GameObject titles;
    public GameObject resgame;
    public GameObject panel;

    private int score;
    private int lives;
    
    // private bool gameover;
    private bool paused;
    public bool isGameActive;

    private float spawnRate = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }

    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {

        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0,targets.Count);
        Instantiate(targets[index]);
      
        }
    }

    public void StartGame(float difficulty)
    {
       
        isGameActive = true;
        score = 0;
        spawnRate = spawnRate / difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
        titles.gameObject.SetActive(false);
    }

    void ChangePaused()
    {
        if (paused)
        {
            paused = false;
            panel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            paused = true;
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }   


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoretext.text = "Score: " + score;
    }

    public void UpdateLives(int livestochange)
    {
        
        lives = lives + livestochange;
        LivesText.text = "Lives: " +lives;
        if (lives <= 0)
        {
            GameOver(); 
        }
            
        
    }


    public void GameOver(){

        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        resgame.gameObject.SetActive(true);
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
