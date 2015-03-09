using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour
{
		[SerializeField]
		int
				_xSize = 20;
		[SerializeField]
		int
				_ySize = 20;
		[SerializeField]
		float
				_tileSize = 1f;

		public IntVector2D WorldSize {
				get { return new IntVector2D (_xSize, _ySize); }
		}
		public IntVector2D[] entityTileLoc = new IntVector2D[999];
		public enum EntityType
		{
				floor,
				block,
				door,
				pusher,
				trigger
		}
		;
		public EntityType entityType { get; private set; }



		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
