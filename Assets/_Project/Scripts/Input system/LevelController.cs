using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private MoveInput _moveInput;
        [SerializeField] private MiniopnHolder _miniopnHolder;

        private void Start()
        {
            _miniopnHolder.Init();

            //SubscribeEvents();
        }

        //private void SubscribeEvents()
        //{
        //    _moveInput.movePoint += OnMove;
        //}

        //private void OnMove(Vector3 movePosition)
        //{
        //    _playerController.SetMovePosition(movePosition);
        //}
    }
}