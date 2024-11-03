using System;
using UnityEngine;

public class MovementBase
{
    public bool movementEnable { get; set; }//是否锁定移动

    #region 可配置属性
    protected float m_maxSpeed = 10f;//最大速度
    protected float m_accelerate = 20f;//加速度
    [SerializeField, Range(0, 90)] protected float m_slopeLimit = 25f;//坡度限制
    protected Transform m_playerInputSpace;//玩家输入空间(通常为摄像机)
    protected Transform m_player;
    #endregion

    //protected PlayInput m_input;

    #region 移动基础

    protected PlayerInputBase m_input;
    private bool m_hasInit = false;//初始化
    //基于物理的角色控制
    protected Rigidbody m_rb;
    protected MonoBehaviour m_mono;//要将功能反映到unity中，必须要传入MonoBehaviour
    protected Animator m_anim;
    #endregion

    public MovementBase(MonoBehaviour mono, Rigidbody rb, Transform inputSpace, Transform player, Animator anim)
    {
        movementEnable = true;
        m_rb = rb;
        m_mono = mono;
        m_anim = anim;
        m_player = player;
        m_playerInputSpace = inputSpace;
        Init();
    }

    public virtual void SetInput(PlayerInputBase input)
    {
        m_input = input;
    }


    public virtual void ExecuteRequest(int request) { }
    public virtual void CancelExecuteRequest(int request) { }

    //模板方法
    protected virtual void OnInit() { }
    protected virtual void OnFixedUpdate() { }
    protected virtual void OnFixedUpdateStart() { }
    protected virtual void OnFixedUpdateOver()
    {
        OnClearState();
    }
    protected virtual void OnUpdate() { }
    protected virtual void OnUpdateStart() { }
    protected virtual void OnUpdateOver() { }
    protected virtual void OnClearState() { }//清除状态

    protected void Init()
    {
        if (m_hasInit) return;
        m_hasInit = true;
        OnInit();
    }

    public void Update()
    {
        OnUpdateStart();
        OnUpdate();
        OnUpdateOver();
    }

    public void FixedUpdate()
    {
        if (!movementEnable) return;
        OnFixedUpdateStart();
        OnFixedUpdate();
        OnFixedUpdateOver();
    }

}
