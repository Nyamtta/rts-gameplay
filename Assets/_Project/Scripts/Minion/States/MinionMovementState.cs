using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace roman.demidow.game
{
    public class MinionMovementState : IState
    {
        private MinionAnimations _animator;
        private NavMeshAgent _navMeshAgent;
        private MinionSettings _minionSettings;
        private Transform _minionTransform;
        Vector3 _minionLastPos;
        private bool _isJump;

        public MinionMovementState(MinionAnimations minionAnimator, NavMeshAgent navMeshAgent, MinionSettings minionSettings, Transform minionTransform)
        {
            _navMeshAgent = navMeshAgent;
            _animator = minionAnimator;
            _minionSettings = minionSettings;
            _minionTransform = minionTransform;
            _navMeshAgent.isStopped = true;
            _navMeshAgent.autoTraverseOffMeshLink = false;
            _isJump = false;

            SetNavMeshSettings(_minionSettings);
        }

        private void SubscribeEvent()
        {
            _minionSettings.onUpdateValue += SetNavMeshSettings;
        }

        private void UnsubscribeEvent()
        {
            _minionSettings.onUpdateValue -= SetNavMeshSettings;
        }

        private void SetNavMeshSettings(MinionSettings minionSettings)
        {
            _navMeshAgent.speed = minionSettings.MoveSpeed;
            _navMeshAgent.acceleration = minionSettings.Acceleration;
            _navMeshAgent.angularSpeed = minionSettings.AngularSpeed;
            _navMeshAgent.avoidancePriority = minionSettings.Priority;
        }

        public void Tick()
        {
            Debug.Log("MoveState");

            _animator.SetMoveVelocity(GetNormalizeMoveSpeed());

            if(_navMeshAgent.isOnOffMeshLink && _isJump == false)
            {
                JumpCurveAsynk(_navMeshAgent);
            }
        }

        private float GetNormalizeMoveSpeed()
        {
            Vector3 currentMove = _minionTransform.position - _minionLastPos;
            _minionLastPos = _minionTransform.position;
            
            float currentSpeed = currentMove.magnitude / Time.deltaTime;
            
            float totalMoveSpeed = Mathf.Clamp01(currentSpeed / _minionSettings.MoveSpeed);

            return totalMoveSpeed;
        }

        private async void JumpCurveAsynk(NavMeshAgent agent)
        {
            _isJump = true;
            _animator.SetJump();

            OffMeshLinkData data = agent.currentOffMeshLinkData;
            Vector3 startPos = agent.transform.position;
            Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
            float normalizedTime = 0.0f;
            float duration = _minionSettings.GetTimeForGump(data.startPos, data.endPos);

            while (normalizedTime < 1.0f)
            {
                float yOffset = _minionSettings.JumpCurve.Evaluate(normalizedTime);
                agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
                normalizedTime += Time.deltaTime / duration;
               await Task.Yield();
            }

            agent.CompleteOffMeshLink();
            _isJump = false;
        }

        public void OnEnter()
        {
            _minionLastPos = _minionTransform.position;
            _navMeshAgent.isStopped = false;
            SubscribeEvent();
        }

        public void OnExit()
        {
            UnsubscribeEvent();
            _navMeshAgent.isStopped = true;
            _animator.SetMoveVelocity(0f);
        }
    }
}