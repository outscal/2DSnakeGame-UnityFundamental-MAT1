using UnityEngine;
using System;

namespace SnakeGame
{
	[Serializable]
    public struct InputKeyConfig
    {
        public KeyCode up;
        public KeyCode left;
        public KeyCode right;
        public KeyCode down;
    }
}
