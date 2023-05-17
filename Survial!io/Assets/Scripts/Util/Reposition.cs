using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private const int HALF_OF_MAP_SIZE = 32;
    
    private Collider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (!collision.CompareTag(TagLiteral.AREA))
        {
            return;
        }
        
        Vector3 playerPosition = GameManager.Instance.Player.transform.position;
        Vector3 areaPosition = transform.position;
        float distanceX = Mathf.Abs(areaPosition.x - playerPosition.x);
        float distanceY = Mathf.Abs(areaPosition.y - playerPosition.y);

        Vector3 playerInputDirection = GameManager.Instance.Player.Direction;
        float directionX = playerInputDirection.x < 0 ? Direction.LEFT : Direction.RIGHT;
        float directionY = playerInputDirection.y < 0 ? Direction.DOWN : Direction.UP;

        switch(transform.tag)
        {
            case TagLiteral.MAP:
                if (distanceX > distanceY) // 두 오브젝트 거리 차이에서 x축이 y축보다 크면 수평 이동
                {                    
                    transform.Translate(Vector3.right * directionX * HALF_OF_MAP_SIZE); 
                }
                else if (distanceX < distanceY) // 두 오브젝트 거리 차이에서 y축보다 x축이 크면 수직 이동
                {                 
                    transform.Translate(Vector3.up * directionY * HALF_OF_MAP_SIZE);
                }
                break;
        }

    }
}

class Direction
{
    public const int UP = 1;
    public const int DOWN = -1;
    public const int RIGHT = 1;
    public const int LEFT = -1;
}
