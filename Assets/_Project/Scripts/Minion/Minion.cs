using System;
using UnityEngine;
using UnityEngine.AI;

namespace roman.demidow.game
{
    
    public class Minion : MonoBehaviour
    {
        [SerializeField] private MinionSettings _minionSettings;
        [SerializeField] private MinionCollision _minionCollision;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;


        private MinionAnimations _minionAnimator;
        private StateMachine _stateMachine;
        private Vector3 _targetMovePos;
        private bool _isMove = false;

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
        }

        public void Init()
        {
            _stateMachine = new StateMachine();
            _minionAnimator = new MinionAnimations(_animator, _minionSettings);
            //_minionAnimator.Init(_animator, _minionSettings);
            _minionCollision.Init();

            MinionMovementState movementState = new MinionMovementState(
                _minionAnimator, _navMeshAgent, _minionSettings, transform);
            MinionIdleState idleState = new MinionIdleState();

            _stateMachine.AddTransition(idleState, movementState, IsMoveState());
            _stateMachine.AddTransition(movementState, idleState, IsIdleState());

            _stateMachine.SetState(idleState);

            Func<bool> IsMoveState() => () => _isMove;
            Func<bool> IsIdleState() => () => IsIdle();

        }

        private bool IsIdle()
        {
            if ( Vector3.Distance(transform.position, _targetMovePos) <= 0.1f)
            {
                _isMove = false;
                return true;
            }

            return false;
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        public void SetMovePosition(Vector3 movePosition)
        {
            _isMove = true;
            _targetMovePos = movePosition;
            _navMeshAgent.SetDestination(movePosition);
        }
    }
}