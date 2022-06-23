using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
	public class GameManager : MonoBehaviour
	{
		private static GameManager instance;
		public static GameManager Instance { get { return instance; } }

		public CoOpManager coOpManager;
		public ScoreController scoreController;

		private void Awake()
		{
			if (instance == null)
				instance = this;
			else
				Destroy(instance);
		}

		public void GameOver()
		{
			Time.timeScale = 0;
			Debug.Log("Player Dead");
			// Update UI
		}

		public void UpdateScore(int value, Team team, bool isDecrease = false)
		{
			scoreController.UpdateScore(value, team, isDecrease);
			//Update UI
		}
	}
}
