using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DefaultNamespace;

namespace Asteroids
{
	public class AsteroidSpawner : MonoBehaviour
	{
		[SerializeField] private Asteroid _asteroidPrefab;
		[SerializeField] private AsteroidConfig _asteroidConfig;

		private float _timer;
		private float _nextSpawnTime;
		private Camera _camera;

		private List<SpawnLocation> _spawnLocations;

		private enum SpawnLocation
		{
			Top,
			Bottom,
			Left,
			Right
		}

		private void Start()
		{
			_spawnLocations = new List<SpawnLocation>();

			if (_asteroidConfig.incomingDirectionTop) _spawnLocations.Add(SpawnLocation.Top);
			if (_asteroidConfig.incomingDirectionLeft) _spawnLocations.Add(SpawnLocation.Left);
			if (_asteroidConfig.incomingDirectionRight) _spawnLocations.Add(SpawnLocation.Right);
			if (_asteroidConfig.incomingDirectionBottom) _spawnLocations.Add(SpawnLocation.Bottom);

			_camera = Camera.main;
			Spawn();
			UpdateNextSpawnTime();
		}

		private void Update()
		{
			UpdateTimer();

			if (!ShouldSpawn())
				return;

			Spawn();
			UpdateNextSpawnTime();
			_timer = 0f;
		}

		private void UpdateNextSpawnTime()
		{
			_nextSpawnTime = Random.Range(_asteroidConfig.minSpawnTime, _asteroidConfig.maxSpawnTime);
		}

		private void UpdateTimer()
		{
			_timer += Time.deltaTime;
		}

		private bool ShouldSpawn()
		{
			return _timer >= _nextSpawnTime;
		}

		private void Spawn()
		{
			var amount = Random.Range(_asteroidConfig.minAmount, _asteroidConfig.maxAmount + 1);

			for (var i = 0; i < amount; i++)
			{
				var location = GetSpawnLocation();
				var position = GetStartPosition(location);
				Instantiate(_asteroidPrefab, position, Quaternion.identity);
			}
		}

		private SpawnLocation GetSpawnLocation()
		{
			var roll = Random.Range(0, _spawnLocations.Count);

			return _spawnLocations[roll];
		}

		private Vector3 GetStartPosition(SpawnLocation spawnLocation)
		{
			var pos = new Vector3 { z = Mathf.Abs(_camera.transform.position.z) };

			const float padding = 5f;
			switch (spawnLocation)
			{
				case SpawnLocation.Top:
					pos.x = Random.Range(0f, Screen.width);
					pos.y = Screen.height + padding;
					break;
				case SpawnLocation.Bottom:
					pos.x = Random.Range(0f, Screen.width);
					pos.y = 0f - padding;
					break;
				case SpawnLocation.Left:
					pos.x = 0f - padding;
					pos.y = Random.Range(0f, Screen.height);
					break;
				case SpawnLocation.Right:
					pos.x = Screen.width - padding;
					pos.y = Random.Range(0f, Screen.height);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(spawnLocation), spawnLocation, null);
			}

			return _camera.ScreenToWorldPoint(pos);
		}
	}
}
