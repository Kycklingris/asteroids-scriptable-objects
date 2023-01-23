using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
	[CreateAssetMenu(fileName = "AsteroidConfig", menuName = "ScriptableObjects/AsteroidConfig", order = 0)]
	public class AsteroidConfig : ScriptableObject
	{
		[SerializeField] private float _minSpawnTime;
		public float minSpawnTime
		{
			get => _minSpawnTime;
			set => _minSpawnTime = value;
		}

		[SerializeField] private float _maxSpawnTime;
		public float maxSpawnTime
		{
			get => _maxSpawnTime;
			set => _maxSpawnTime = value;
		}

		[SerializeField] private int _minAmount;
		public int minAmount
		{
			get => _minAmount;
			set => _minAmount = value;
		}

		[SerializeField] private int _maxAmount;
		public int maxAmount
		{
			get => _maxAmount;
			set => _maxAmount = value;
		}

		[SerializeField] private float _minRotationSpeed;
		public float minRotationSpeed
		{
			get => _minRotationSpeed;
			set => _minRotationSpeed = value;
		}

		[SerializeField] private float _maxRotationSpeed;
		public float maxRotationSpeed
		{
			get => _maxRotationSpeed;
			set => _maxRotationSpeed = value;
		}

		[SerializeField] private int _damage;
		public int damage
		{
			get => _damage;
			set => _damage = value;
		}

		[SerializeField] private bool _incomingDirectionTop;
		public bool incomingDirectionTop
		{
			get => _incomingDirectionTop;
			set => _incomingDirectionTop = value;
		}

		[SerializeField] private bool _incomingDirectionLeft;
		public bool incomingDirectionLeft
		{
			get => _incomingDirectionLeft;
			set => _incomingDirectionLeft = value;
		}

		[SerializeField] private bool _incomingDirectionRight;
		public bool incomingDirectionRight
		{
			get => _incomingDirectionRight;
			set => _incomingDirectionRight = value;
		}

		[SerializeField] private bool _incomingDirectionBottom;
		public bool incomingDirectionBottom
		{
			get => _incomingDirectionBottom;
			set => _incomingDirectionBottom = value;
		}

		[SerializeField] private Sprite _sprite;
		public Sprite sprite
		{
			get => _sprite;
			set => _sprite = value;
		}

		[SerializeField] private Color _color;
		public Color color
		{
			get => _color;
			set => _color = value;
		}
	}
}