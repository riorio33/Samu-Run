using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
	
	public deployObstacles obstacleManager;
	public playerController playerController;
	public Animator animator;
	public string name;
	
	public void ToggleObstacleManager()
	
	{
		obstacleManager.enabled = !obstacleManager.enabled;
	}
	
	public void TogglePlayerControls()
	
	{
		playerController.enabled = !playerController.enabled;
		playerController.gameObject.GetComponent<playerCombat>().enabled = !playerController.gameObject.GetComponent<playerCombat>().enabled;
	}
	
	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
	
	public void animatorSetBool(bool value)
	
	{
		animator.SetBool(name, value);
	}
	
	public void restartLevel()
	
	{
		SceneManager.LoadScene(0);
	}
	
}