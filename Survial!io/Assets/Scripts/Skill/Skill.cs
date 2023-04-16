using Assets.Scripts.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Skill : MonoBehaviour
{
    private protected SkillData _skillData;
    private float _elapsedTime;
    private float _cooldownTime;
    private int _level = -1; // index�� ����ϱ� ���� level1 = 0�� �Ǳ� ���� �ʱ�ȭ
    private string _currentSkill;
    private int _bulletCount;
    private string _description;

    private float _totalSkillDamage;

    [SerializeField]
    private Bullet _bullet; // �ν����Ϳ��� bullet prefab ���� �ʿ� 
    private ObjectPool<Bullet> _bulletPool;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool);
        InitiateSkill();
    }

    private void Update()
    {
        Shoot();
    }

    private void InitiateSkill()
    {
        _currentSkill = "Guardian";
        // �÷��̾ UI�� ���� ������ ��ų ������ �޾ƿ;� ��, ��ų ������ �ý��� �ݿ��� ���� ���� �ʿ�

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
        transform.Rotate(Vector3.back * _skillData.BulletSpeed[_level]);
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
        SetPosition(bullet);
        SetMovingPattern(bullet, id);
        SetDamage(bullet);
        SetCurrentLevelBullet(bullet, _level);
    }

    private Bullet GetBulletFromPool()
    {
        Debug.Assert(_bulletPool != null);

        Bullet bullet = _bulletPool.Get();

        return bullet;
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.BulletPool = _bulletPool;

        return bullet;
    }

    private void OnTakeBulletFromPool(Bullet bullet) => bullet.gameObject.SetActive(true);

    private void GetSkillData(string skillName)
    {
        _skillData = Resources.Load<SkillData>($"Data/Skill/{skillName}");
    }
    private void SetCurrentLevelSkill(int level)
    {
        _description = _skillData.SkillDescriptions[level];
        _bulletCount = _skillData.Counts[level];
    }

    private void SetMovingPattern(Bullet bullet, int id)
    {
        //bullet.MovingPattern = new Revolution(); 
        // ���� ��� ���� ���ο� ��ų ���� �� ��ų �������� pattern�� �޾ƿ� switch������ ���� �ʿ�

        // �Ʒ��� ��ȣ�� ��ü �ڵ�
        bullet.transform.parent = transform; // bullet�� skill�� �ڽ� ������Ʈ�� ����
        bullet.transform.localPosition = Vector3.zero; // �� �ȿ��� ���� ��ǥ �ʱ�ȭ
        bullet.transform.localRotation = Quaternion.identity;
        
        Vector3 rotateVector = (Vector3.forward * 360 / _bulletCount) * id;
        bullet.transform.Rotate(rotateVector);
        bullet.transform.Translate(bullet.transform.up * 1.5f, Space.World);

    }

    private void SetPosition(Bullet bullet)
    {
        // root ������Ʈ�� player���� child ������Ʈ�� body�� �̵��� ���� position ����
        Transform playerTransform = transform.root.GetChild(0); // 0 : player�� �����̴� ������Ʈ
        bullet.transform.position = playerTransform.position;
        bullet.transform.rotation = playerTransform.rotation;
        bullet.Stat.Sprite = _skillData.Sprite;
    }
    private void SetDamage(Bullet bullet)
    {
        bullet.Stat.CurrentBulletDamage = _skillData.DamagePerBullet[_level];
        // ���⿡ �÷��̾� �������ͽ� ���� �� player�� atk�� ���ϱ� 
    }

    private void SetCurrentLevelBullet(Bullet bullet, int level)
    {
        bullet.Stat.BulletSpeed = _skillData.BulletSpeed[level];
        bullet.Stat.Count = _skillData.Counts[level];
    }
}
