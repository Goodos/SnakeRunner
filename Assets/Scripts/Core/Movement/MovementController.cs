using UnityEngine;
using System;

namespace Core.Movement {
	public class MovementController : MonoBehaviour {
		[Header("Configuration")] 
		[SerializeField] private float forwardSpeed = 1f;
		[SerializeField] private float horizontalSpeed = 1f;
		
		[Header("Input configuration")]
		[SerializeField] private bool hasLockInput;

		[SerializeField] Vector2 moveLimits;
		
		private Rigidbody _rigidbody;
		private float inputValueWhenLocked = 0f;

		private float x = 0;

		public float ForwardSpeed {
			get => forwardSpeed;
			set => forwardSpeed = value;
		}

		public bool HasLockInput {
			get => hasLockInput;
			set => hasLockInput = value;
		}

		private void Awake() {
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void FixedUpdate() {
			if (UnityEngine.Input.GetMouseButton(0))
				Move();
		}

		private void Move() {
			
			if (UnityEngine.Input.GetMouseButton(0))
			{
				x = UnityEngine.Input.GetAxis ("Mouse X");
			}
			var direction = transform.forward * forwardSpeed;
			var horizontalInput = !hasLockInput ? x : inputValueWhenLocked;
			var rotationInput = Math.Clamp(horizontalInput, moveLimits.x, moveLimits.y) * horizontalSpeed;
			direction.x = rotationInput;
			MoveToDirection(direction);
		}

		private void MoveToDirection(Vector3 direction) {
			_rigidbody.velocity = direction;
		}
	}
}