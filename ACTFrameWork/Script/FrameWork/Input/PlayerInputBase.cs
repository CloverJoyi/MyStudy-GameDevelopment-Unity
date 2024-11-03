
public class InputData
{

}

public class PlayerInputBase
{
    protected InvokerBase m_invoker;
    protected InputData m_inputData;

    public PlayerInputBase(InvokerBase invoker)
    {
        m_invoker = invoker;
    }

    public void Update()
    {
        GetInputAxis();
        CallCommand();
        EndOfUpdate();
    }
    public void FixedUpdate()
    {
        FixedCallCommand();
    }

    protected virtual void GetInputAxis() { }
    protected virtual void EndOfUpdate() { }
    protected virtual void FixedCallCommand() { }
    protected virtual void CallCommand() { }

    public T GetInputData<T>() where T : InputData, new()
    {
        if (m_inputData == null)
            m_inputData = new T();
        return (T)m_inputData;
    }

}
