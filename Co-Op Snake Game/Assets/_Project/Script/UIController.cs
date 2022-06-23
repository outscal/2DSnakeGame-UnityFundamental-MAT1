using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SnakeGame
{
    public class UIController : MonoBehaviour
    {
        public Text alphaScoreText;
        public Text charlieScoreText;
        public Text WinText;

        public GameObject MainMenuPanel;
        public GameObject GameOverPanel;

		private void Start()
		{
            MainMenuPanel.SetActive(true);
            GameOverPanel.SetActive(false);
        }
		public void UpdateScore(int[] score)
		{
            alphaScoreText.text = $"Alpha : {score[(int)Team.Alpha]}"; 
            charlieScoreText.text = $"Charlie : {score[(int)Team.Charlie]}";
        }

		public void StartGame()
		{
			GameManager.Instance.StartGame();
            MainMenuPanel.SetActive(false);
            GameOverPanel.SetActive(false);
		}

        public void GameOver(Team team, bool isSuicide)
		{
            GameOverPanel.SetActive(true);
                
            int[] scores = GameManager.Instance.scoreController.Score;
            if (isSuicide)
                scores[(int)team] = -100000;

            if(scores[(int)Team.Alpha] == scores[(int)Team.Charlie])
			{
                WinText.text = "DRAW";
                return;
			}

            string winTeam = (scores[(int)Team.Alpha] > scores[(int)Team.Charlie]) ? "APLHA" : "CHARLIE";
            WinText.text = $"{winTeam} WINS";
        }

	}
}
