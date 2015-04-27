using UnityEngine;
using System.Collections;

public class MusicPlayed : GameEvent
{
	
		public int musicNum;
		public MusicPlayed (int musicNum)
		{
				this.musicNum = musicNum;
		}
	
	
}
