using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : PlayerBase
{
    protected override string stateHandlerClass => "PlayerStateHandlerTest";

    protected override object[] stateHandlerArgs => new object[] { anim };

    protected override string movementClass => "MovementTest";

    protected override object[] movementArgs => new object[] { this, GetEnitityComponment<Rigidbody>(), entity, entity, anim };

    protected override string behaviourClass => "BehaviourTest";

    protected override object[] behaviourArgs => new object[] { this };

    protected override string requestHandlerClass => "RequestHandlerTest";

    protected override object[] requestHandlerArgs => new object[] { behaviour };

    protected override string receiverClass => "ReceiverRequestTest";

    protected override object[] receiverArgs => new object[] { requestHandler, behaviour, this };
    protected override string invokerClass => "Exaple.InvokerTest";

    protected override object[] invokerArgs => new object[] { receiver };

    protected override string inputClass => "Exaple.AixsInputTest";

    protected override object[] inputArgs => new object[] { invoker };

    public Vector3 rebornPos { get; private set; }//存档点

    public void UpdateRebornInPos(Vector3 pos)//更新存档点
    {
        rebornPos = pos;
    }

    private void Reborn()//复活
    {
        //Instantiate(this, rebornPos, Quaternion.identity);
    }

    private void OnDestroy()
    {
        Reborn();
    }
}
