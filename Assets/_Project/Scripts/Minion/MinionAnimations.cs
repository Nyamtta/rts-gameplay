using UnityEngine;

namespace roman.demidow.game
{
    public class MinionAnimations
    {
        private Animator _animator;
        private MinionSettings _settings;

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
            Debug.Log(takeWeapon);

            if(takeWeapon == true)
            {
                _animator.SetTrigger(_settings.TakeSwordTrigger);
            }
            else
            {
                _animator.SetTrigger(_settings.HideSwordTrigger);
            }
        }

        public void SetMoveVelocity(float moveVelocity)
        {
            _animator.SetFloat(_settings.MoveVevocity, moveVelocity);
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