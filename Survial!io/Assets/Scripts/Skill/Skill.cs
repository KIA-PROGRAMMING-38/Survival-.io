using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Skill : MonoBehaviour // Acting like BulletSpawner
{
    private protected SkillData _skillData;
    private float _elapsedTime;
    private float _cooldownTime;
    private int _level = -1; // index�� �� level1 = 0�� �Ǳ� ���� �ʱ�ȭ
    private string _currentSkill;
    private int _bulletCount;
    private string _description;
    private Transform _playerTransform;
    private float _totalSkillDamage;

    [SerializeField]
    private Bullet _bullet; // �ν����Ϳ��� bullet prefab ���� �ʿ� 
    private ObjectPool<Bullet> _bulletPool;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool);
        _playerTransform = transform.root.GetChild(0).GetComponent<Transform>();
        InitiateSkill();
    }

    private void Update()
    {
        Shoot();
    }

    private void InitiateSkill()
    {
        _currentSkill = SkillName.KUNAI;
        // �÷��̾ UI�� ���� ������ ��ų ������ �޾ƿ;� ��
        // ��ų ������ �ý��� �ݿ��� ���� ���� �ʿ�

        ++_level; // �÷��̾ ���� ���õ� ������ ��ų ���� ���

        if (_skillData == null)
        {
            GetSkillData(_currentSkill);
        }
        SetCurrentLevelSkill(_level); // �������� �ٲ�� �����͸� ����
    }

    private void Shoot()
    {
        _elapsedTime += Time.deltaTime;
        _cooldownTime = _skillData.CooldownTime;

        if (_elapsedTime >= _cooldownTime)
        {
            _elapsedTime = 0f;
            for (int id = 0; id < _bulletCount; ++id)

            {
                Bullet bullet = GetBulletFromPool();
                SetBullet(bullet, id);
            }
        }
    }

    private void SetBullet(Bullet bullet, int id)
    {
        // �߻�ü���� ������ ���̺��� �ڷḦ ������ ������ �ѱ�� �κ�
        SetCurrentLevelBullet(bullet, _level);
        SetPosition(bullet, id);
        SetMovingPattern(bullet, _skillData);
        SetDamage(bullet);
    }

    private Bullet GetBulletFromPool()
    {
        Debug.Assert(_bulletPool != null);

        Bullet bullet = _bulletPool.Get();

        return bullet;
    }

    // functions for pooling 
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.BulletPool = _bulletPool;
        bullet.Stat.Sprite = _skillData.Sprite;
        return bullet;
    }

    private void OnTakeBulletFromPool(Bullet bullet) => bullet.gameObject.SetActive(true);

    // functions for skill initialization
    private void GetSkillData(string skillName)
    {
        _skillData = Resources.Load<SkillData>($"Data/Skill/{skillName}");
    }

    private void SetCurrentLevelSkill(int level)
    {
        _description = _skillData.SkillDescriptions[level];
        _bulletCount = _skillData.Counts[level];
    }

    // functions for bullets
    private void SetMovingPattern(Bullet bullet, SkillData skillData)
    {
        if (bullet.GetComponent<MoveStraight>() == null)
        bullet.AddComponent<MoveStraight>();
        
    }

    private void SetPosition(Bullet bullet, int id)
    {
        bullet.transform.SetParent(this.transform);
        bullet.transform.localPosition = Vector2.zero;    
    }
    private void SetDamage(Bullet bullet)
    {
        // After implement 'UserStat', multiply 'UserStat.Atk'
        bullet.Stat.CurrentBulletDamage = _skillData.DamagePerBullet[_level];
    }

    private void SetCurrentLevelBullet(Bullet bullet, int level)
    {
        bullet.Stat.BulletSpeed = _skillData.BulletSpeed[level];
        bullet.Stat.Count = _skillData.Counts[level];
    }
}
