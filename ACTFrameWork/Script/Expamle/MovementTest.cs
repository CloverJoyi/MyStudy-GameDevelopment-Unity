using System.Collections;
using System.Collections.Generic;
using Exaple;
using UnityEngine;

public class MovementTest : MovementBase
{
    #region Configurable Properties

    [SerializeField, Range(0f, 10f)] private float m_jumpHeight = 2f;
    [SerializeField, Range(0f, 30f)] private float m_maxRunSpeed = 5f;

    #endregion

    #region 请求

    private bool m_movementRequest;
    private bool m_jumpRequest;

    #endregion

    private Vector3 m_inputDir = Vector3.zero;

    public MovementTest(MonoBehaviour mono, Rigidbody rb, Transform inputSpace, Transform player, Animator anim) : base(mono, rb, inputSpace, player, anim)
    {

    }

    protected void OnReadConfiguration(string path) { }

    public override void ExecuteRequest(int request)
    {
        switch (request)
        {
            case RequestID.Move:
                m_movementRequest = true;
                break;
            case RequestID.Jump:
                m_jumpRequest = true;
                break;
        }
    }
    public override void CancelExecuteRequest(int request)
    {
        switch (request)
        {
            case RequestID.Move:
                m_movementRequest = false;
                break;
            case RequestID.Jump:
                m_jumpRequest = false;
                break;
        }
    }

    protected override void OnUpdate()
    {
        if (m_movementRequest)
        {
            m_movementRequest = false;
            Debug.Log("执行了移动的业务逻辑");
            m_inputDir.x = m_input.GetInputData<InputDataTest>().playerInput.x;
            m_inputDir.z = m_input.GetInputData<InputDataTest>().playerInput.y;
            m_inputDir = m_inputDir.normalized;
            m_rb.velocity = m_inputDir * m_maxRunSpeed;
        }
        else
        {
            m_inputDir = Vector3.zero;
        }
    }

    protected override void OnFixedUpdate()
    {
        if (m_jumpRequest == true)
        {
            m_jumpRequest = false;
            Jump();
        }
    }

    private void Jump()
    {
        Vector3 jumpDir = JumpDateHandle();
        ExeJump(jumpDir);
        Debug.Log("执行了跳跃的业务逻辑");
    }

    private Vector3 JumpDateHandle()
    {
        Vector3 jumpDirection = Vector3.up;
        //如果有跳跃数量限制
        //int jumpCount+=1;
        return jumpDirection;
    }

    private void ExeJump(Vector3 jumpDir)
    {
        const float g = 10;
        float jumpSpeed = Mathf.Sqrt(2f * g * m_jumpHeight);
        jumpDir = jumpDir.normalized;

        m_rb.velocity += jumpDir * jumpSpeed;
    }
}
