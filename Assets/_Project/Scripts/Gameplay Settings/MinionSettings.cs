using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Minion Settings", menuName = "Gamepley Settings/Minion Settings")]
public class MinionSettings : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _angularSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _timeDefaultJump;
    [SerializeField] private int _priority;
    [SerializeField] private AnimationCurve _jumpCurve;

    [Header("Animator Parameters")]
    [SerializeField] private string _jumpTrigger;
    [SerializeField] private string _isAttack;
    [SerializeField] private string _moveVevocity;
    [SerializeField] private string _deathTrigger;

    private float _defaultJumpDistans = 2f;

    public float MoveSpeed { get => _moveSpeed; set { _moveSpeed = value; onUpdateValue?.Invoke(this); } }
    public float AngularSpeed { get => _angularSpeed; set { _angularSpeed = value; onUpdateValue?.Invoke(this); } }
    public float Acceleration { get => _acceleration; set { _acceleration = value; onUpdateValue?.Invoke(this); } }
    public int Priority { get => _priority; set { _priority = value; onUpdateValue?.Invoke(this); } }

    public string JumpTrigger { get => _jumpTrigger; private set => _jumpTrigger = value; }
    public string MoveVevocity { get => _moveVevocity; private set => _moveVevocity = value; }
    public string IsAttack { get => _isAttack; private set => _isAttack = value; }
    public string DeathTrigger { get => _deathTrigger; private set => _deathTrigger = value; }
    public AnimationCurve JumpCurve { get => _jumpCurve; private set => _jumpCurve = value; }

    public event Action<MinionSettings> onUpdateValue;

    public float GetTimeForGump(Vector3 from, Vector3 to)
    {
        float distance = Vector3.Distance(from, to);
        float time = _timeDefaultJump * (distance / _defaultJumpDistans);

        return time;
    }
}
