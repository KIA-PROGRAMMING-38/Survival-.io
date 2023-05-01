using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EXP : Item
{
    private ObjectPool<EXP> _expPool { get; set; }
    private Transform _transform;    

    // ������ ���Ͱ� ������ �� �ִ� ����ġ ������ �����Ͱ� �־�� �ϰ�
    // Item�� Ǯ���� ���� �� � ���Ͱ� �׾����� �˷���
    // �� �����͸� ������� ���� 
        
    public override void Effect(Player player)
    {
        GiveExp(player);
        Release(); // item���� ���, pool�� release
    }

    public void GiveExp(Player player)
    {
        player.AddExp(2);        
    }

}
