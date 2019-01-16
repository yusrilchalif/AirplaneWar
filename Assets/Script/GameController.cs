using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text scoreText;
    public Text HPtext;
    private int score;
    private int healthPoint;
    public Texture2D textureGame;
    public bool gameOver = false;
    float timer = 0;
    void Start()
    {
        score = 0;
        healthPoint = 3;
        UpdateScore_HP();
    }
    // Update is called once per frame
    
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore_HP();
    }
    public void MinHP(int newHealthPoint)
    {
        healthPoint -= newHealthPoint;
        UpdateScore_HP();
    }
    void UpdateScore_HP()
    {
        scoreText.text = score.ToString();
        HPtext.text = "HP:" + healthPoint.ToString();
        if (healthPoint <= 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
            gameOver = true;
        }
    }

    void OnGUI(){
        if(gameOver == true){
           Application.LoadLevel("GameOver");
        }
    }

    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if (timer > 2)
    //     {
    //         SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    //     }
    // }
}