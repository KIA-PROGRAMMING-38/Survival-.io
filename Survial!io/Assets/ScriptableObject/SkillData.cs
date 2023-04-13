using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Data/SkillData")]
public class SkillData : ScriptableObject
{
    [Header("Main Info")]
    public string SkillName;
    public int SkillId;
    public float CooldownTime;
    public string[] SkillDescriptions;
    // skillsprite �߰� �ʿ�

    [Header("Bullet Data")]
    // bullet move pattern �߰��ؾ���
    // range �߰� �ʿ�
    public Sprite Sprite;
    public string Target;
    public int[] Counts;
    public float[] DamagePerBullet;
    public float[] BulletSpeed;
    
}
