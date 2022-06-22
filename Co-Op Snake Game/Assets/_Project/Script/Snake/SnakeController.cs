using System;
using UnityEngine;

namespace SnakeGame.Snake
{
	public class SnakeController : MonoBehaviour
	{
		public float speed;

		[Serializable]
		public struct InputKeyConfig
		{
			public KeyCode up;
			public KeyCode left;
			public KeyCode right;
			public KeyCode down;
		}

		public InputKeyConfig keyConfig;

		private Vector2 m_CurrentDirection;
		private Vector2 m_NextDirection;
		private float m_MoveTimer;

		public BodyService bodyService;
		private Boundary bounds;

		private void Start()
		{
			InitDirection();
			InitBody();
			transform.position += (Vector3)m_CurrentDirection;
			bounds = BoundController.bounds;
		}

		private void InitBody()
		{
			bodyService.SetHead(this);
			bodyService.ResetBody();
		}

		private void InitDirection()
		{
			m_CurrentDirection = Vector2.right;
			m_NextDirection = Vector2.right;
		}

		// Input
		private void Update()
		{
			GetInput();
		}
		private void GetInput()
		{
			if (Input.GetKeyDown(keyConfig.up))
				SetDirection(Vector2.up);
			else if (Input.GetKeyDown(keyConfig.left))
				SetDirection(Vector2.left);
			else if (Input.GetKeyDown(keyConfig.right))
				SetDirection(Vector2.right);
			else if (Input.GetKeyDown(keyConfig.down))
				SetDirection(Vector2.down);
		}
		private void SetDirection(Vector2 direction) => m_NextDirection = direction;

		// Movement
		private void FixedUpdate()
		{
			Movement();
		}

		private void Movement()
		{
			IncreaseTimer();
			if (m_MoveTimer > (1 / speed))
			{
				ResetTimer();
				MoveSnake();
			}
		}
		private void IncreaseTimer() => m_MoveTimer += Time.fixedDeltaTime;
		private void ResetTimer() => m_MoveTimer = 0;
		private void MoveSnake()
		{
			bodyService.Move(transform.position);

			if (m_CurrentDirection != -m_NextDirection)
				m_CurrentDirection = m_NextDirection;
			transform.position += (Vector3)m_CurrentDirection;

			CheckScreenWarp();
		}

		private void CheckScreenWarp()
		{
			Vector3 newPos = transform.position;

			if (newPos.x > bounds.boundMaxX)
				newPos.x = bounds.boundMinX;
			else if (newPos.x < bounds.boundMinX)
				newPos.x = bounds.boundMaxX;
			else if (newPos.y > bounds.boundMaxY)
				newPos.y = bounds.boundMinY;
			else if (newPos.y < bounds.boundMinY)
				newPos.y = bounds.boundMaxY;

			transform.position = newPos;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent(out BodyController body))
			{
				Death();
			}
		}

		public void Death()
		{
			Time.timeScale = 0;
			Debug.Log("Player Dead");
		}
	}
}
