using UnityEngine;

namespace roman.demidow.game
{
    public class MinionAnimations
    {
        private Animator _animator;
        private MinionSettings _settings;

        private const float RUN_WHIT_WEAPON = 1f;
        private const float RUN_WHITOUT_WEAPON = 0f;

        public MinionAnimations(Animator animation, MinionSettings minionSettings)
        {
            _animator = animation;
            _settings = minionSettings;
        }

        public void Init(Animator animation, MinionSettings minionSettings)
        {
            _animator = animation;
            _settings = minionSettings;
        }

        public void SetWeaponState(bool takeWeapon)
        {
            if(takeWeapon == true)
            {
                _animator.SetTrigger(_settings.TakeSwordTrigger);
                _animator.SetFloat(_settings.AttackVelocity, RUN_WHIT_WEAPON);
            }
            else
            {
                _animator.SetTrigger(_settings.HideSwordTrigger);
                _animator.SetFloat(_settings.AttackVelocity, RUN_WHITOUT_WEAPON);
            }
        }

        public void SetMoveVelocity(float moveVelocity)
        {
            _animator.SetFloat(_settings.MoveVelocity, moveVelocity);
        }

        public void SetJump()
        {
            _animator.SetTrigger(_settings.JumpTrigger);
        }

        public void SetAttack(bool isAttack)
        {
            _animator.SetBool(_settings.IsAttack, isAttack);
        }

        public void SetDeath()
        {
            _animator.SetTrigger(_settings.DeathTrigger);
        }

    }
}