using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D _collider;
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
        
        Vector3 playerPosition = GameManager._instance._player.transform.position;
        Vector3 areaPosition = transform.position;
        float distanceX = Mathf.Abs(areaPosition.x - playerPosition.x);
        float distanceY = Mathf.Abs(areaPosition.y - playerPosition.y);

        Vector3 playerDirection = GameManager._instance._player._inputVec;
        float directionX = playerDirection.x < 0 ? -1 : 1;
        float directionY = playerDirection.y < 0 ? -1 : 1;

        switch(transform.tag)
        {
            case "Map":
                if (distanceX > distanceY) // �� ������Ʈ �Ÿ� ���̿��� x���� y�ຸ�� ũ�� ���� �̵�
                {                    
                    transform.Translate(Vector3.right * directionX * 64); // 32�� �� ũ��
                }
                else if (distanceX < distanceY) // �� ������Ʈ �Ÿ� ���̿��� y�ຸ�� x���� ũ�� ���� �̵�
                {                 
                    transform.Translate(Vector3.up * directionY * 64);
                }
                break;
        }

    }
}
