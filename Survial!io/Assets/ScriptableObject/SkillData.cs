using Assets.Scripts.Skill;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Data/SkillData")]
public class SkillData : ScriptableObject
{
    [Header("Main Info")]
    public string SkillName;
    public int SkillId;
    public float CooldownTime;
    public string[] SkillDescriptions;
    public Sprite UISprite;    

    [Header("Bullet Data")]
    // range 추가 필요
    public Sprite Sprite;
    public IBulletMovingPattern BulletMovingPattern;
    public string Target;
    public int[] Counts;
    public float[] DamagePerBullet;
    public float[] BulletSpeed;
    
}
