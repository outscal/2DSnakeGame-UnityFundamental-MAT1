using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    public class ScoreController : MonoBehaviour
    {
        public int[] Score { get; private set; }

        public void UpdateScore(int value, Team team, bool isDecrease = false)
		{
            int effectiveScore = value * ((isDecrease) ? -1 : 1);
			Score[(int)team] = effectiveScore;
		}
    }
}
