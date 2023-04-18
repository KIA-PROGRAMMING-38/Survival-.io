using UnityEngine;
public interface IMovable
{
    Vector2 Direction { get; set; }
    float Speed { get; set; }
    void Move();
}
