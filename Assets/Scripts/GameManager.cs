using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	bool gameHasEnded = false;
	public float restartDelay = 1f;
	public GameObject completeLevelUI;
	public void EndGame()
	{
		if (!gameHasEnded)
		{
			gameHasEnded = true;
			Invoke("Restart", restartDelay);
		}
	}

	public void CompleteLevel()
	{
		Debug.Log("Level 1");
		completeLevelUI.SetActive(true);
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
