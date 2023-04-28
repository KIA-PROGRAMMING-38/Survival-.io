using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EXP : Item
{
    private ObjectPool<EXP> _expPool { get; set; }
    private Transform _transform;    

    // 각각의 몬스터가 생성할 수 있는 경험치 아이템 데이터가 있어야 하고
    // Item이 풀에서 나올 때 어떤 몬스터가 죽었는지 알려줌
    // 그 데이터를 기반으로 생성 
        
    public override void Effect(Player player)
    {
        GiveExp(player);
        Release(); // item에서 상속, pool에 release
    }

    public void GiveExp(Player player)
    {
        player.AddExp(2);        
    }

}
