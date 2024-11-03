using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTest : BehaviourBase
{
    private IPlayerBase m_playerBase;
    public BehaviourTest(PlayerBase playerBase)
    {
        m_playerBase = playerBase;

    }
    public override void Action(int actionID, bool execute = true)
    {
        switch (actionID)
        {
            case RequestID.Move:
                Avtion_Move(execute);
                break;
            case RequestID.Jump:
                Avtion_Jump(execute);
                break;
        }
    }
    public override void ActionWithData(int actionID, params object[] data)
    {

    }

    public void Avtion_Move(bool execute)
    {
        if (execute)
        {
            m_playerBase.movement.ExecuteRequest(RequestID.Move);
        }
        else
        {
            m_playerBase.movement.CancelExecuteRequest(RequestID.Move);
        }
    }

    public void Avtion_Jump(bool execute)
    {
        if (execute)
        {
            m_playerBase.movement.ExecuteRequest(RequestID.Jump);
        }
        else
        {
            m_playerBase.movement.CancelExecuteRequest(RequestID.Jump);
        }
    }

}

