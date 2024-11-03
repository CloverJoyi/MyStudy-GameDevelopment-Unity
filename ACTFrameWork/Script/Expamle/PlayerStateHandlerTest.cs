using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandlerTest : StateHandlerBase
{
    private PlayerStateTest m_stateTest;

    public PlayerStateHandlerTest(Animator anim) : base(anim)
    {
    }

    protected override void StateConfiguration()
    {
        m_stateTest = new PlayerStateTest();
        m_stateData.Add(m_stateTest);
    }

    protected override void StateConditionConfiguration()
    {
        m_stateCondition.Add(RequestID.Move, () =>
        {
            if ((m_stateTest.state & (PlayerStateTest.PlayerStateID.idle | PlayerStateTest.PlayerStateID.move)) != 0 || m_stateTest.onGround)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Jump, () =>
        {
            if ((m_stateTest.state & (PlayerStateTest.PlayerStateID.idle | PlayerStateTest.PlayerStateID.move)) != 0)
            {
                return true;
            }
            return false;
        });
    }

    protected override void OnInit()
    {
        m_stateTest.state = PlayerStateTest.PlayerStateID.idle;
        m_stateTest.onGround = true;
    }

    protected override void OnFixedUpdate()
    {
        UpdatePlayerState();
    }

    private void UpdatePlayerState()
    {
        if (isInTransition) return;

        if (currentStateHash == Animator.StringToHash("Idle"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.idle;
        }
        else if (currentStateHash == Animator.StringToHash("Move"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.move;
        }
        else if (currentStateHash == Animator.StringToHash("Jump"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.jump;
        }
    }
}
