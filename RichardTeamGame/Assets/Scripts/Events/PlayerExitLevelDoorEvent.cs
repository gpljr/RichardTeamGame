using UnityEngine;
using System.Collections;

public class PlayerExitLevelDoorEvent : GameEvent
{

		public bool isPlayerOne;
		public PlayerExitLevelDoorEvent (bool isPlayerOne)
		{
				this.isPlayerOne = isPlayerOne;
		}


}
