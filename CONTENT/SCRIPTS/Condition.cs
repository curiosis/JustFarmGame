using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour, ICondition
{
    public bool Can()
    {
        return true;
    }
}

public interface ICondition
{
    bool Can();
}
