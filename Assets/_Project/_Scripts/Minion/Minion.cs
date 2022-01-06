using System;
using UnityEngine;
using UnityEngine.AI;

namespace roman.demidow.game
{

    public class Minion : MonoBehaviour
    {
        [SerializeField] private MinionSettings _minionSettings;
        [SerializeField] private MinionCollision _minionCollision;
        [SerializeField] private MinionAnimationEvent _minionAnimationEvent;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _weaponHolsterGO;
        [SerializeField] private GameObject _weaponInHandHolderGO;

        private MinionAnimations _minionAnimator;
        private StateMachine _stateMachine;
        private Vector3 _targetMovePos;
        private bool _isMove = false;
        private IDamageable _currentAttackTarget = null;

        private void OnValidate()
        {
            if (_minionCollision == null)
                _minionCollision = GetComponent<MinionCollision>();
            if (_navMeshAgent == null)
                _navMeshAgent = GetComponent<NavMeshAgent>();
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody>();
            if (_animator == null)
                _animator = GetComponent<Animator>();
            if (_minionAnimationEvent == null)
                _minionAnimationEvent = GetComponentInChildren<MinionAnimationEvent>();
        }

        public void Init()
        {
            _minionAnimator = new MinionAnimations(_animator, _minionSettings);
            _minionCollision.Init();
            _minionAnimationEvent.Init(_weaponHolsterGO, _weaponInHandHolderGO);
            
            CreateWeapon(_minionSettings.StartWeapon);
            SubscribeEvent();
            InitStateMachine();
        }

        private void InitStateMachine()
        {
            _stateMachine = new StateMachine();

            MinionIdleState idleState = new MinionIdleState();
            MinionAttackState attackState = new MinionAttackState(_minionSettings, this, 
                _minionAnimator, _minionAnimationEvent);
            MinionMovementState movementState = new MinionMovementState
                (_minionAnimator, _navMeshAgent, _minionSettings, transform, _minionCollision);

            _stateMachine.AddTransition(idleState, movementState, IsMoveState());
            _stateMachine.AddTransition(idleState, attackState, IsAttackState());
            _stateMachine.AddTransition(movementState, idleState, IsIdleState());
            _stateMachine.AddTransition(movementState, attackState, IsAttackState());
            _stateMachine.AddTransition(attackState, idleState, FromAttackToIdle());
            _stateMachine.AddTransition(attackState, movementState, IsMoveState());

            _stateMachine.SetState(idleState);

            Func<bool> IsMoveState() => () => _isMove;
            Func<bool> IsIdleState() => () => IsIdle();
            Func<bool> IsAttackState() => () => CanAttack();
            Func<bool> FromAttackToIdle() => () => CanAttack() == false;
        }

        private void SubscribeEvent()
        {
            _minionCollision.onAttacZone += TouchEnemy;
        }
        
        private void UnsubscribeEvent()
        {
            _minionCollision.onAttacZone -= TouchEnemy;
        }

        private void CreateWeapon(GameObject weapon)
        {
            Instantiate(weapon, _weaponHolsterGO.transform);
            Instantiate(weapon, _weaponInHandHolderGO.transform);

            _weaponInHandHolderGO.SetActive(false);
            _weaponInHandHolderGO.SetActive(false);
        }

        private bool IsIdle()
        {
            if ( Vector3.Distance(_rigidbody.position, _targetMovePos) <= 0.1f)
            {
                _isMove = false;
                return true;
            }

            return false;
        }

        private bool CanAttack()
        {
            if(_currentAttackTarget != null)
            {
                return Vector3.Distance(_rigidbody.position, _currentAttackTarget.GetPosition()) <= _minionSettings.AttackDistance;
            }

            return false;
        }

        private void Update()
        {
            if(_stateMachine != null)
                _stateMachine.Tick();
        }
        
        private void TouchEnemy(IDamageable enemy, bool isTouch)
        {
            if (_currentAttackTarget == null && isTouch == true)
            {
                _isMove = false;
                _currentAttackTarget = enemy;
            }
        }

        public void SetMovePosition(Vector3 movePosition)
        {
            _isMove = true;
            _targetMovePos = movePosition;
            _currentAttackTarget = null;
            _navMeshAgent.SetDestination(movePosition);
        }

        public IDamageable GetCurrentEnemy()
        {
            return _currentAttackTarget;
        }
    }
}