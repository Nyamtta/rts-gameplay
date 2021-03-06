using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _pointerArrowPrefab;

    public event Action<Vector3> movePoint;
    private GameObject _pointerArrowGO;
    private MinionControll _minionControll;

    private const float MAX_RAY_DISTANCE = 500f;

    private void Start()
    {
        _minionControll = new MinionControll();
    }

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            GetWorldPoint();
        }
    }

    public void GetWorldPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
        if(Physics.Raycast(ray, out RaycastHit hit, MAX_RAY_DISTANCE, _groundLayer) == true)
        {
            Vector3 groundPos = hit.point;
            SetPointerPosition(groundPos);
            movePoint?.Invoke(groundPos);
        }
    }

    private void SetPointerPosition(Vector3 clickPos)
    {
        if(_pointerArrowGO == null)
        {
            _pointerArrowGO = Instantiate(_pointerArrowPrefab);
        }

        _pointerArrowGO.SetActive(false);
        _pointerArrowGO.SetActive(true);
        _pointerArrowGO.transform.position = clickPos;
    }

}
