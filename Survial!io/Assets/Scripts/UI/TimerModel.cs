using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    public static event Action OnElapseTime;
    private static float _elapsedTime = 0f;

    public static float ElapsedTime
    {
        get => _elapsedTime;
        set
        {
            _elapsedTime = value;
            OnElapseTime?.Invoke();
        }
    }

    
}
