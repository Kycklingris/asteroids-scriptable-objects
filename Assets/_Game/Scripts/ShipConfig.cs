using UnityEngine;
using Variables;

namespace DefaultNamespace
{
	[CreateAssetMenu(fileName = "Ship Config", menuName = "ScriptableObjects/ShipConfig", order = 0)]
	public class ShipConfig : ScriptableObject
	{
		[SerializeField] private float _throttle;
		public float throttle
		{
			get => _throttle;
			set => _throttle = value;
		}
		[SerializeField] private float _rotation;
		public float rotation
		{
			get => _rotation;
			set => _rotation = value;
		}
	}

}
