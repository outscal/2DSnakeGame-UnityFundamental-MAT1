using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public class ScoreController : MonoBehaviour
    {
        public int[] Score { get; private set; }

		private void Start()
		{
			Score = new int[2];
		}

		public void UpdateScore(int value, Team team, bool isDecrease = false)
		{
            int effectiveScore = value * ((isDecrease) ? -1 : 1);
			Score[(int)team] += effectiveScore;
		}

		internal void ResetScore()
		{
			for (int i = 0; i < Score.Length; i++)
			{
				Score[i] = 0;
			}
		}
	}
}
