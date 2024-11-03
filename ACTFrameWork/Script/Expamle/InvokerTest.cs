using System;
using UnityEngine;

namespace Exaple
{
    public class InvokerTest : InvokerBase
    {
        public InvokerTest(RequestReceiverBase receiver) : base(receiver)
        {
            m_commandList.Add((int)CallID.Move);
            m_commandList.Add((int)CallID.Jump);
        }

        public override void Call(int callID)
        {
            Debug.Log("顺利接受到指令ID:" + callID);
            SendRequest(callID);
        }

        private void SendRequest(int callID)
        {
            if (m_commandList.Contains(callID))
            {
                m_receiver.ReceiverRequest(CommandRequestMapping(callID));
            }
        }

        //Invoker做的事情是接收指令，找出对应的请求ID，发送给Request层
        private int CommandRequestMapping(int callID)
        {
            switch (callID)
            {
                case (int)CallID.Idle:
                    return RequestID.Idle;
                case (int)CallID.Move:
                    return RequestID.Move;
                case (int)CallID.Jump:
                    return RequestID.Jump;
            }
            return RequestID.Idle;
        }
    }

    public enum CallID
    {
        Idle = 1,
        Move = 2,
        Jump = 3,

    }


}

