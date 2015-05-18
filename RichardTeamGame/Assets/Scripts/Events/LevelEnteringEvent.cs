using UnityEngine;
using System.Collections;

public enum LevelType
{
	Starting,
    Normal,
    Separated,
    Combined,
}


public class LevelEnteringEvent : GameEvent
{
    public LevelType levelType;
    public LevelEnteringEvent(LevelType levelType)
    {
        this.levelType = levelType;
    }


}
