using UnityEngine;
using System.Collections;

public class LevelEntering : MonoBehaviour
{
    // [SerializeField]
    // LevelType levelType;
    [SerializeField]
    LevelType levelType;
    // Use this for initialization
    void Start()
    {
        Events.g.Raise(new LevelEnteringEvent(levelType));
    }

}
