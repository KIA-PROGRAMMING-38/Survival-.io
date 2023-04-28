using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Main Info")]
    public string EnemyName;
    public int EnemyID;
    public int SpawnPhase;
    public float SpawnInterval;
    public Animator Animator;

    [Header("Stat Data")]
    public int Hp;
    public int Speed;
    public int CollisionDamage;
    public int SkillID;
    public int EXP;

}