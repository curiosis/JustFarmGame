using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour, IBehaviour
{
    public virtual void Do()
    {
        return;
    }
}

public interface IBehaviour
{
    void Do();
}
