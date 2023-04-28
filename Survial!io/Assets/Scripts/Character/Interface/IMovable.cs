using UnityEngine;
public interface IMovable // It needs 'Movement' and 'Rigidbody2D' Component
{
    Vector2 Direction { get; set; }
    float Speed { get; set; }
    void Move();
}
