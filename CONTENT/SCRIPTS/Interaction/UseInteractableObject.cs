using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInteractableObject : InteractableObject
{
    [SerializeField]
    private List<Condition> conditions;
    [SerializeField]
    private List<Behaviour> behaviours;

    public override void Interact()
    {
        base.Interact();
    }

    public void Use()
    {
        bool tempCan = true;
        foreach (Condition condition in conditions)
        {
            if (condition.Can() == false)
                tempCan = false;
        }

        if (tempCan)
            foreach (Behaviour behaviour in behaviours)
                behaviour.Do();
    }
}
