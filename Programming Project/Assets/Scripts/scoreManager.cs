using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
	
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;
	
	public float scoreAmount;
	public float pointIncreasedPerSecond;
	public float highScore;
	
	public playerCombat player;
	
	public bool pauseScoreIncrease = false;
	
    void Start()
    {
	    scoreAmount = 0f;
	    pointIncreasedPerSecond = 10f;
	    highScore = PlayerPrefs.GetFloat("highscore");
	    highScoreText.text = "High Score: " + highScore.ToString();
    }

    void Update()
	{
		scoreUpdate();
    }
    
	private void scoreUpdate()
	{

		if(pauseScoreIncrease == false)
		{
			scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
		}
		
		scoreText.text = "Score: " + (int)scoreAmount;
		    
		if(!player.alive)
		{
			if(scoreAmount > highScore)
			{
				highScore = scoreAmount;
				highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore).ToString();
				PlayerPrefs.SetFloat("highscore", Mathf.RoundToInt(highScore));
			}
		}
	
	}
	public void changePauseScoreIncrease(bool value)
	{
		pauseScoreIncrease = value;
	}
	
    

}
