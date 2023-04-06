using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement Player;
    public PoolManager Pool;

    private void Awake()
    {
        Instance = this;
    }
}
