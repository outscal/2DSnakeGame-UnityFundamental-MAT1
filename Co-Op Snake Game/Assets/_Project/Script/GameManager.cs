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
		public UIController uiController;

		private void Awake()
		{
			if (instance == null)
				instance = this;
			else
				Destroy(instance);
		}

		public void GameOver(Team team, bool isSuicide)
		{
			Time.timeScale = 0;
			Debug.Log("Player Dead");
			uiController.GameOver(team,isSuicide);
		}

		public void UpdateScore(int value, Team team, bool isDecrease = false)
		{
			scoreController.UpdateScore(value, team, isDecrease);
			uiController.UpdateScore(scoreController.Score);
		}

		public void StartGame()
		{
			Time.timeScale = 1;
			scoreController.ResetScore();
			uiController.UpdateScore(scoreController.Score);
			coOpManager.StartGame();
		}
	}
}
