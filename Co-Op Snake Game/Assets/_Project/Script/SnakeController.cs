using System;
using System.Collections;
using System.Collections.Generic;
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

		private void Start()
		{
			m_CurrentDirection = Vector2.right;
			m_NextDirection = Vector2.right;
			bodyService.SetHead(this);
			bodyService.ResetBody();
			transform.position += (Vector3)m_CurrentDirection;
		}

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

		private void SetDirection(Vector2 direction)
		{
			m_NextDirection = direction;
		}

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
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent(out BodyController body))
			{
				Time.timeScale = 0;
				Debug.Log("Player Dead");
			}
		}
	}
}
