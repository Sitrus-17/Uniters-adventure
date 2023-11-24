using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ss : MonoBehaviour
{
    // Ray�̒���
    [SerializeField] private float _rayLength = 1f;

    // Ray���ǂꂭ�炢�g�̂ɂ߂荞�܂��邩
    [SerializeField] private float _rayOffset;

    // Ray�̔���ɗp����Layer
    [SerializeField] private LayerMask _layerMask = default;
    [SerializeField] private LayerMask _layerMask2 = default;
    public GameObject RootObject;
    public GameObject RootObject2;
    private bool _isGround;
    private bool _isGround2;

    private void FixedUpdate()
    {
        // �ڒn����
        _isGround = CheckGrounded();
        if (_isGround)
        {
            this.gameObject.transform.parent = RootObject.gameObject.transform;
        }
        if (!_isGround)
        {
            this.gameObject.transform.parent = null;
            _isGround2 = CheckGrounded2();
            if (_isGround2)
            {
                this.gameObject.transform.parent = RootObject2.gameObject.transform;
            }
            if (!_isGround2)
            {
                this.gameObject.transform.parent = null;
            }
        }
    }
    private bool CheckGrounded()
    {
        // �������̏����ʒu�Ǝp��
        // �኱�g�̂ɂ߂荞�܂����ʒu���甭�˂��Ȃ��Ɛ���������ł��Ȃ���������
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Raycast��hit���邩�ǂ����Ŕ���
        // ���C���̎w���Y�ꂸ��

        return Physics.Raycast(ray, _rayLength, _layerMask);

    }
    private bool CheckGrounded2()
    {
        // �������̏����ʒu�Ǝp��
        // �኱�g�̂ɂ߂荞�܂����ʒu���甭�˂��Ȃ��Ɛ���������ł��Ȃ���������
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Raycast��hit���邩�ǂ����Ŕ���
        // ���C���̎w���Y�ꂸ��

        return Physics.Raycast(ray, _rayLength, _layerMask2);

    }


    // Debug�p��Ray����������
    private void OnDrawGizmos()
    {
        // �ڒn���莞�͗΁A�󒆂ɂ���Ƃ��͐Ԃɂ���
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }
}