using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Minion Settings", menuName = "Gamepley Settings/Minion Settings")]
public class MinionSettings : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private float _angularSpeed = 500f;
    [SerializeField] private float _acceleration = 100f;
    [SerializeField] private float _timeDefaultJump = 0.3f;
    [SerializeField] private int _priority = 50;
    [SerializeField] private float _attackDistance = 0.5f;
    [SerializeField] private float _attackDamage = 10f;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private GameObject _startWeapon;

    [Header("Animator Parameters")]
    [SerializeField] private string _jumpTrigger;
    [SerializeField] private string _isAttack;
    [SerializeField] private string _moveVelocity;
    [SerializeField] private string _attackVelocity;
    [SerializeField] private string _deathTrigger;
    [SerializeField] private string _hideSwordTrigger;
    [SerializeField] private string _takeSwordTrigger;

    private float _defaultJumpDistans = 2f;

    public event Action<MinionSettings> onUpdateValue;
    
    public float MoveSpeed { get => _moveSpeed; set { _moveSpeed = value; onUpdateValue?.Invoke(this); } }
    public float AngularSpeed { get => _angularSpeed; set { _angularSpeed = value; onUpdateValue?.Invoke(this); } }
    public float Acceleration { get => _acceleration; set { _acceleration = value; onUpdateValue?.Invoke(this); } }
    public int Priority { get => _priority; set { _priority = value; onUpdateValue?.Invoke(this); } }

    public string JumpTrigger { get => _jumpTrigger; private set => _jumpTrigger = value; }
    public string MoveVelocity { get => _moveVelocity; private set => _moveVelocity = value; }
    public string IsAttack { get => _isAttack; private set => _isAttack = value; }
    public string DeathTrigger { get => _deathTrigger; private set => _deathTrigger = value; }
    public AnimationCurve JumpCurve { get => _jumpCurve; private set => _jumpCurve = value; }
    public string HideSwordTrigger { get => _hideSwordTrigger; private set => _hideSwordTrigger = value; }
    public string TakeSwordTrigger { get => _takeSwordTrigger; private set => _takeSwordTrigger = value; }
    public GameObject StartWeapon { get => _startWeapon; private set => _startWeapon = value; }
    public float AttackDistance { get => _attackDistance; private set => _attackDistance = value; }
    public string AttackVelocity { get => _attackVelocity; private set => _attackVelocity = value; }
    public float AttackDamage { get => _attackDamage; private set => _attackDamage = value; }

    public float GetTimeForGump(Vector3 from, Vector3 to)
    {
        float distance = Vector3.Distance(from, to);
        float time = _timeDefaultJump * (distance / _defaultJumpDistans);

        return time;
    }
}
