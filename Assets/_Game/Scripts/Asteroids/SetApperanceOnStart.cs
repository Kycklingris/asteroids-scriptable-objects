using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class SetApperanceOnStart : MonoBehaviour
{
	[SerializeField] private AsteroidConfig _asteroidConfig;
	void Start()
	{
		GetComponent<SpriteRenderer>().sprite = _asteroidConfig.sprite;
		GetComponent<SpriteRenderer>().color = _asteroidConfig.color;
	}

}
