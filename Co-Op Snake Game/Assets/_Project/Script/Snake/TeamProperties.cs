using UnityEngine;
using System;

namespace SnakeGame
{
    public enum Team
    {
        Alpha = 0,
        Charlie = 1
    }

    [Serializable]
    public struct TeamProperties
	{
        public Team team;
        public Transform spawnPoint;
        public InputKeyConfig keyConfig;
        public Color color;
    }
}
