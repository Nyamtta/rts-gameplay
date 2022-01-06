using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _testObject_1 = null;
    [SerializeField] private GameObject _testObject_2 = null;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _animationClip;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(_animator.GetCurrentAnimatorStateInfo(0));
        }
    }

}
