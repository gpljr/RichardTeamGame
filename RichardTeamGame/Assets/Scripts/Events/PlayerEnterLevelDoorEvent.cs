using UnityEngine;
using System.Collections;

public class PlayerEnterLevelDoorEvent : GameEvent
{

		public bool isPlayerOne;
		public PlayerEnterLevelDoorEvent (bool isPlayerOne)
		{
				this.isPlayerOne = isPlayerOne;
		}


}
