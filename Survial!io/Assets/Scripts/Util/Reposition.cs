using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private const int _halfOFMapSize = 32;
    private Collider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        
        Vector3 playerPosition = GameManager.Instance.Player.transform.position;
        Vector3 areaPosition = transform.position;
        float distanceX = Mathf.Abs(areaPosition.x - playerPosition.x);
        float distanceY = Mathf.Abs(areaPosition.y - playerPosition.y);

        Vector3 playerDirection = GameManager.Instance.Player.Direction;
        float directionX = playerDirection.x < 0 ? -1 : 1;
        float directionY = playerDirection.y < 0 ? -1 : 1;

        switch(transform.tag)
        {
            case "Map":
                if (distanceX > distanceY) // �� ������Ʈ �Ÿ� ���̿��� x���� y�ຸ�� ũ�� ���� �̵�
                {                    
                    transform.Translate(Vector3.right * directionX * _halfOFMapSize); 
                }
                else if (distanceX < distanceY) // �� ������Ʈ �Ÿ� ���̿��� y�ຸ�� x���� ũ�� ���� �̵�
                {                 
                    transform.Translate(Vector3.up * directionY * _halfOFMapSize);
                }
                break;
        }

    }
}
