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

        public void UpdateScore(int[] score)
		{
            alphaScoreText.text = $"Alpha : {score[(int)Team.Alpha]}"; 
            charlieScoreText.text = $"Charlie : {score[(int)Team.Charlie]}";
        }
    }
}
