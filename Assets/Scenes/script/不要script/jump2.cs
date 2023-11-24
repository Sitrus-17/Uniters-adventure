using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyJump : MonoBehaviour
{
    CharacterController controller;

    // ��ɐi�ޑ��x
    float moveVelocityY;

    // �W�����v����Ƃ��̑��x�i�d�͂ł̑��x���傫������Ə�ɃW�����v�ł���
    float jumpPower = 5;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Jump�{�^����������Ă��Ȃ����A�d�͕��̑��x�������܂�
        // Physics.gravity.y�́A�f�t�H���g�� -9.8f�Ȃ̂�+=�ł����A�������ƂɂȂ�܂�
        moveVelocityY += Physics.gravity.y * Time.deltaTime;

        Debug.Log(controller.isGrounded);

        // �L�����N�^���n��̏ꍇ
        if (controller.isGrounded)
        {
            // moveVelocityY = 0�ł����̂ł����A�ڒn���肪�s����ɂȂ錻�ۂ�����܂�
            // �ڒn������m���ɒm�邽��-0.5f�������܂�
            // ���Ȃ݂�0��������ƁADebug.Log�ŕ\������Ă���̂�true�Afalse�ƃo�^���̂��킩��܂�
            moveVelocityY = -0.5f;

            // �W�����v�{�^���������ꂽ��i�W���̓X�y�[�X�L�[�j
            if (Input.GetButtonDown("Jump"))
            {
                // Y���̑��x����
                moveVelocityY = jumpPower;
            }
        }

        // �L�����N�^�̈ړ��i����Y�������Ńe�X�g�j
        controller.Move(new Vector3(0, moveVelocityY, 0) * Time.deltaTime);
    }
}