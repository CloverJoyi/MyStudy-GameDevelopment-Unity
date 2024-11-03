using UnityEngine;

interface IAgent
{

}

public class Agent : MonoBehaviour, IAgent
{
    public Transform entity;
    public T GetEnitityComponment<T>()
    {
        return entity.GetComponent<T>();
    }
}
