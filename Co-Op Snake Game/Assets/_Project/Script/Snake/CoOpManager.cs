using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame
{
	public class CoOpManager : MonoBehaviour
    {
        [Header("SnakePrefab")]
        public SnakeController snakePrefab;
        public Transform headCollection;
        public Transform bodyCollection;

        [Header("Team Properties")]
        public TeamProperties[] teams;

        [Header("Snake Properties")]
        public float speed;
		public int initialBodyCount;

        private SnakeController[] snakes;

		private void Start()
		{
            snakes = new SnakeController[teams.Length];
			for (int teamIndex = 0; teamIndex < teams.Length; teamIndex++)
			{
                snakes[teamIndex] = CreateSnake(teams[teamIndex]) ;
			}
		}

		private SnakeController CreateSnake(TeamProperties team)
		{
            SnakeController newSnake = Instantiate(snakePrefab, team.spawnPoint.position,Quaternion.identity);
            Vector2 initalDirection = (team.spawnPoint.position.x > 0) ? Vector2.left : Vector2.right;
			newSnake.InitializeSnake(team.team, team.color, team.keyConfig,speed, initialBodyCount, initalDirection, bodyCollection);
            newSnake.transform.parent = headCollection;
            return newSnake;
		}
	}
}
