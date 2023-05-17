using System;
using UnityEngine;


public class Player : CharacterBase, IMovable
{
    // �������� �� �Ŵ��� ������ �� Ŭ����

    private Vector2 _inputVector;
    private Vector2 _directionNormalized;
    private float _speed;
    private UserInput _userInput;
    private int _level;
    private int _currentEXP;
    private int _maxEXP;

    private const int MAX_SKILL_COUNT = 6;

    public void AddExp(int exp)
    {
        _currentEXP += exp;
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        item?.Effect(this);        
    }

    public void Init()
    {
        // �÷��̾� ĳ���� �ʱ�ȭ
        CharacterStat player = new CharacterStat
        {
            SkillSet = new Skill[MAX_SKILL_COUNT]
        };        
        _userInput = GetComponentInParent<UserInput>();
        GameManager.Instance.Player = this;
    }
    private void SetSpeed()
    {        
        Speed = _speed; // CharacterBase���� ��ӹ��� �ʵ�
        // ���� ������ ��� �߰� �� ���� �������� ���ǵ� �ݿ��Ͽ� ���.
        // ���� �� speed�� �ٲ�� ���� ������ ���� �� ���� ��ų�� ����� ��
    }
    override public void Move()
    {
        SetDirection(); // ���⼭ ���� direction���� movement ������Ʈ ����
        OnMove();
    }
    private void SetDirection()
    {
        Direction = _directionNormalized; // CharacterBase ��� �ʵ�
        _inputVector.Set(_userInput.Horizontal, _userInput.Vertical);
        _directionNormalized = _inputVector.normalized;
    }
    public void OnMove()
    {

    }
    override public void TakeDamage(float damageAmount, GameObject attacker = null)
    {
        // health���� �߻��� �޽����� ui�� ����
    }
    public void OnHeal() // �÷��̾�� ĳ���Ϳ����� �ִ� ���, ���� ��ȹ�� ���� ��� ĳ���Ͱ� �������� �� ���� ������?
    {
        // health���� �߻��� �޽����� ui�� ����
    }
    override public void Dead()
    {
        // helath���� �޽����� �޾Ƽ� ���� ���ῡ �޽����� ����Ѵ�.
    }

}
