using System;
using UnityEngine;

public interface IPlayerBase
{
    public StateHandlerBase stateHandler { get; }
    public BehaviourBase behaviour { get; }
    public MovementBase movement { get; }
    public RequestHandlerBase requestHandler { get; }
    public RequestReceiverBase receiver { get; }
    public InvokerBase invoker { get; }
    public PlayerInputBase input { get; }
}

public abstract class PlayerBase : Agent, IPlayerBase
{
    public StateHandlerBase stateHandler { get; private set; }
    public BehaviourBase behaviour { get; private set; }
    public MovementBase movement { get; private set; }
    public RequestHandlerBase requestHandler { get; private set; }
    public RequestReceiverBase receiver { get; private set; }
    public InvokerBase invoker { get; private set; }
    public PlayerInputBase input { get; private set; }

    #region FramWorkClassData
    protected abstract string stateHandlerClass { get; }
    protected abstract object[] stateHandlerArgs { get; }

    protected abstract string movementClass { get; }
    protected abstract object[] movementArgs { get; }
    protected abstract string behaviourClass { get; }
    protected abstract object[] behaviourArgs { get; }
    protected abstract string requestHandlerClass { get; }
    protected abstract object[] requestHandlerArgs { get; }
    protected abstract string receiverClass { get; }
    protected abstract object[] receiverArgs { get; }
    protected abstract string invokerClass { get; }
    protected abstract object[] invokerArgs { get; }
    protected abstract string inputClass { get; }
    protected abstract object[] inputArgs { get; }
    public Animator anim { get; protected set; }

    #endregion



    private void AgentDataInit() { }
    private void FrameWorkInit()
    {
        Debug.Log("Try FramWorkInit");
        //此处实例化所有的系统对象类(反射方法)
        stateHandler = ActivatorUtil.CreateInstance<StateHandlerBase>(ActivatorUtil.GetFrameWoekType(stateHandlerClass), stateHandlerArgs);
        movement = ActivatorUtil.CreateInstance<MovementBase>(ActivatorUtil.GetFrameWoekType(movementClass), movementArgs);
        behaviour = ActivatorUtil.CreateInstance<BehaviourBase>(ActivatorUtil.GetFrameWoekType(behaviourClass), behaviourArgs);
        requestHandler = ActivatorUtil.CreateInstance<RequestHandlerBase>(ActivatorUtil.GetFrameWoekType(requestHandlerClass), requestHandlerArgs);
        receiver = ActivatorUtil.CreateInstance<RequestReceiverBase>(ActivatorUtil.GetFrameWoekType(receiverClass), receiverArgs);
        invoker = ActivatorUtil.CreateInstance<InvokerBase>(ActivatorUtil.GetFrameWoekType(invokerClass), invokerArgs);
        input = ActivatorUtil.CreateInstance<PlayerInputBase>(ActivatorUtil.GetFrameWoekType(inputClass), inputArgs);


        Debug.Log("FramWorkInit Succeed");

    }
    private void EndOfInit()
    {
        movement.SetInput(input);
    }
    protected void OnInit()
    {
        //data,framework,EndOfInit
        AgentDataInit();
        FrameWorkInit();
        EndOfInit();
    }
    protected void OnUpdate()
    {
        input.Update();
        invoker.Update();
        requestHandler.Update();
        movement.Update();
    }

    protected void OnFixedUpdate()
    {
        input.FixedUpdate();
        invoker.FixedUpdate();
        requestHandler.FixedUpdate();
        movement.FixedUpdate();
    }

    protected void Awake()
    {
        OnInit();
    }

    private void Update()
    {
        OnUpdate();
    }
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
