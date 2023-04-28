using UnityEngine;

public class BulletStat
{
    public string Target; // 고정 - 타겟, 논타겟
    public Vector2 Direction;
    public string Range; // string은 임시, 스킬 레벨 + 패시브에 따라 변화
    public float BulletSpeed; // 스킬 레벨 + 패시브에 따라 변화
    public float CurrentBulletDamage; // 현재 플레이어 공격력 * 발사체 당 데미지로 계산이 완료된 데미지 값
    public float ActivateTime; // 총알이 충돌 여부와 관계 없이 비활성화 되는 시간
    public int Count;
    public Sprite Sprite;
}