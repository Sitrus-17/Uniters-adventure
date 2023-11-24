using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController controller;

    public float speed = 5f;
    public float dashspeed = 15f;
    public float gravity = -19f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    // Ray�̒���
    [SerializeField] private float _rayLength = 1f;

    // Ray���ǂꂭ�炢�g�̂ɂ߂荞�܂��邩
    [SerializeField] private float _rayOffset;

    // Ray�̔���ɗp����Layer
    [SerializeField] private LayerMask _layerMask = default;
    public GameObject RootObject;
    private bool _isGround;

    private void FixedUpdate()
    {
        // �ڒn����
        _isGround = CheckGrounded();
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

    // Debug�p��Ray����������
    private void OnDrawGizmos()
    {
        // �ڒn���莞�͗΁A�󒆂ɂ���Ƃ��͐Ԃɂ���
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }


    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * dashspeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        controller.Move(move * speed * Time.deltaTime);

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (_isGround)
        {
            jumpHeight = 15f;
        }
        if (!_isGround)
        {
            jumpHeight = 3f;
        }
    }
}
