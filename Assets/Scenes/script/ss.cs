using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ss : MonoBehaviour
{
    // Rayの長さ
    [SerializeField] private float _rayLength = 1f;

    // Rayをどれくらい身体にめり込ませるか
    [SerializeField] private float _rayOffset;

    // Rayの判定に用いるLayer
    [SerializeField] private LayerMask _layerMask = default;
    [SerializeField] private LayerMask _layerMask2 = default;
    public GameObject RootObject;
    public GameObject RootObject2;
    private bool _isGround;
    private bool _isGround2;

    private void FixedUpdate()
    {
        // 接地判定
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
        // 放つ光線の初期位置と姿勢
        // 若干身体にめり込ませた位置から発射しないと正しく判定できない時がある
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Raycastがhitするかどうかで判定
        // レイヤの指定を忘れずに

        return Physics.Raycast(ray, _rayLength, _layerMask);

    }
    private bool CheckGrounded2()
    {
        // 放つ光線の初期位置と姿勢
        // 若干身体にめり込ませた位置から発射しないと正しく判定できない時がある
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Raycastがhitするかどうかで判定
        // レイヤの指定を忘れずに

        return Physics.Raycast(ray, _rayLength, _layerMask2);

    }


    // Debug用にRayを可視化する
    private void OnDrawGizmos()
    {
        // 接地判定時は緑、空中にいるときは赤にする
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }
}