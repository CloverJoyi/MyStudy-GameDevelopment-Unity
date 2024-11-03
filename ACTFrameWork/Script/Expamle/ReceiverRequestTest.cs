

public class ReceiverRequestTest : RequestReceiverBase
{
    private IPlayerBase m_player;

    public ReceiverRequestTest(RequestHandlerBase requestHandler, BehaviourBase behaviour, IPlayerBase player) : base(requestHandler, behaviour)
    {
        m_player = player;
        //初始化dic
        RequestConditionInit();
    }

    private void RequestConditionInit()
    {
        StateHandlerBase playerStateHandler = m_player.stateHandler;

        //m_requestDic.Add(RequestID.Idle, new RequestNode(m_behaviour, RequestID.Idle, 1, playerStateHandler.GetStateCondition(RequestID.Idle)));
        m_requestDic.Add(RequestID.Move, new RequestNode(m_behaviour, RequestID.Move, 1, playerStateHandler.GetStateCondition(RequestID.Move)));
        m_requestDic.Add(RequestID.Jump, new RequestNode(m_behaviour, RequestID.Jump, 1, playerStateHandler.GetStateCondition(RequestID.Jump)));//请求通过的条件写在此处,依靠状态机判定
    }

    public override void ReceiverRequest(int requestID)
    {
        if (m_requestDic.TryGetValue(requestID, out var value))
        {
            m_requestHandler.ReceiveRequest(value);
        }


    }
    public override void ReceiverRequestWithData(int requestID, params object[] data)
    {
        if (m_requestDic.TryGetValue(requestID, out var value))
        {
            m_requestDic[requestID].ExternalInit(value);
            m_requestHandler.ReceiveRequest(value);
        }
    }
}

public class RequestID
{
    public const int Idle = 1;
    public const int Move = 2;
    public const int Jump = 3;
}



