using System;
using UnityEngine;


public class Player : CharacterBase, IMovable
{
    // �������� �� �Ŵ��� ������ �� Ŭ����
    private Vector2 _inputVector;
    private Vector2 _directionNormalized;
    public Vector2 Direction { get => _directionNormalized; set => _directionNormalized = value; }
    public float Speed { get => CharacterStat.DEFAULT_SPEED; set => SetSpeed(); }
    private UserInput _userInput;    
    public event Action<Vector2, float> OnMove;

    private void Awake()
    {
        Init();        
    }

    private void Update()
    {
        Move();        
    }
    public void Init()
    {
        // �÷��̾� ĳ���� �ʱ�ȭ
        // 
        CharacterStat player = new CharacterStat
        {
            SkillSet = new Skill[6],
            Speed = speed
        };
        // skill[0]�� ��� ������ ���� �� �ش� ����� �⺻ ��ų�� ��ġ�ϰ� �ؾ���
        // ���⼭ ������ ������ ������ ��ɵ鿡 �ѷ��� ��
        _userInput = GetComponentInParent<UserInput>();
    }
    private void SetSpeed()
    {
        // ���� ������ ��� �߰� �� ���� �������� ���ǵ� �ݿ��Ͽ� ���.
        // ���� �� speed�� �ٲ�� ���� ������ ���� �� ���� ��ų�� ����� ���� ���� ���� �� ����.
    }
    public override void Move()
    {
        SetDirection();               
    }
    private void SetDirection()
    {
        _inputVector.Set(_userInput.Horizontal, _userInput.Vertical);        
        _directionNormalized = _inputVector.normalized;
    }
    public override void OnTakeDamage()
    {
        // health���� �߻��� �޽����� ui�� ����
    }
    public void OnHeal() // �÷��̾�� ĳ���Ϳ����� �ִ� ���, ���� ��ȹ�� ���� ��� ĳ���Ͱ� �������� �� ���� ������?
    {
        // health���� �߻��� �޽����� ui�� ����
    }
    public override void Died()
    {
        // �̰Ŵ� helath���� �޽����� �޾Ƽ� ���� ���ῡ �޽����� ����Ѵ�.
    }

}
