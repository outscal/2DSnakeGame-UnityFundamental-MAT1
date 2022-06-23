using System;
using UnityEngine;
using SnakeGame.Item.PowerUp;

namespace SnakeGame.Snake
{
	public class SnakeController : MonoBehaviour
	{
		public Team team;
		public float Speed { get; set; }
		public Color Color { get; private set; }
		public SpriteRenderer sprite;

		private InputKeyConfig keyConfig;

		private Vector2 m_CurrentDirection;
		private Vector2 m_NextDirection;
		private float m_MoveTimer;

		public BodyService bodyService;
		private Boundary bounds;
		[HideInInspector]
		public PowerUp activePower;
		[HideInInspector]
		public bool isShieldActive;

		private void Start()
		{
			bounds = BoundController.bounds;
			isShieldActive = true;
			Invoke(nameof(SafeStart), 0.5f);
		}

		public void SafeStart() => isShieldActive = false;

		public void InitializeSnake(Team team, Color color, InputKeyConfig keyConfig, float speed, int initialBodyCount, Vector2 initalDirection, Transform bodyCollection)
		{
			this.team = team;
			Color = color;
			Speed = speed;
			this.keyConfig = keyConfig;
			m_CurrentDirection = initalDirection;
			bodyService.StartCount = initialBodyCount;
			bodyService.BodyCollection = bodyCollection;

			InitSnake();
			InitDirection(initalDirection);
			InitBody();
		}

		private void InitSnake()
		{
			transform.position += (Vector3)m_CurrentDirection;
			m_NextDirection = m_CurrentDirection;
			sprite.color = Color;
		}
		private void InitDirection(Vector2 direction)
		{
			m_CurrentDirection = direction;
			m_NextDirection = direction;
		}
		private void InitBody()
		{
			bodyService.SetHead(this);
			bodyService.ResetBody();
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
			if (m_MoveTimer > (1 / Speed))
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
			if (collision.TryGetComponent(out BodyController body) && !isShieldActive)
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
