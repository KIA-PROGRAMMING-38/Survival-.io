using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{    
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    private void Update()
    {
        MoveInput();
    }

    public void MoveInput()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");        
    }
    public void SelectSkill()
    {

    }
}
