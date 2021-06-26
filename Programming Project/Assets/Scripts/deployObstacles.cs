using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class deployObstacles : MonoBehaviour
{
	[ShowInInspector]
	public GameObject[] allObstacles; // an array which holds gameObjects called allObstacles
	public Transform[] allObstaclesSpawnpoints; // an array which holds transforms called allObstaclesSpawnpoints
	public GameObject[] allEnemies; // an array which holds gameObjects called allEnemies
	public Transform[] allEnemySpawnpoints; // an array which holds transforms called allEnemySpawnpoints
	public float respawnTime; // a float variable named respawnTime
	private Vector2 screenBounds; // a private vector called screenBounds
	public Vector2 spawnHeight;
	[SerializeField]
	private int obstacleOrEnemy;
	
    // Start is called before the first frame update
    void Start()
    {
	    screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); // takes the boundaries of the game view
	    StartCoroutine(obstacleWaves()); // starts the coroutine obstacleWaves
    }


	private void spawnRandomObjects()
	{
		obstacleOrEnemy = Random.Range(0, 2); // will hold either 0 or 1
		if (obstacleOrEnemy == 0) // this runs
		{
			int index = Random.Range(0, allObstacles.Length); // will hold a value between 0 and the amount of objects in the array allObstacles
			GameObject obstacleToSpawn = allObstacles[index]; // obstacleToSpawn now equals to a gameObject in allObstacles specified by the index variable
			Transform obstacleSpawnPoint = allObstaclesSpawnpoints[Random.Range(0, allObstaclesSpawnpoints.Length)]; // the obstacleSpawnPoint now equals to a transform specified by a random number between 0 and the length of the array allObstacleSpawnpoints
			Instantiate(obstacleToSpawn, obstacleSpawnPoint.position, Quaternion.identity); // actually spawns in the object
		}
		else if(obstacleOrEnemy == 1) 
		{
			int index = Random.Range(0, allEnemies.Length);
			GameObject enemyToSpawn = allEnemies[index];
			Transform enemySpawnPoint = allEnemySpawnpoints[Random.Range(0, allEnemySpawnpoints.Length)];
			Instantiate(enemyToSpawn, enemySpawnPoint.position, Quaternion.identity);
			
		}
		Debug.Log("Spawned Random Object");
	}
	
	IEnumerator obstacleWaves()
	{
		respawnTime = Random.Range(3, 5);
		yield return new WaitForSeconds(respawnTime);
		spawnRandomObjects();
		
		if(this.enabled == true)
		{
			StartCoroutine(obstacleWaves());
		}
	}
}

