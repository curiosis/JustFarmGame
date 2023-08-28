using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InteractionManager interactionManager;
    public InventoryManager InventoryManager;

    public InteractionManager InteractionManager
    {
        get => interactionManager;
    }

    public static Player Instance
    {
        get => FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            TimeManager.Instance.ChangeVisUITimeAndCalendar();
        if (Input.GetKeyDown(KeyCode.E))
        {
            var tempInteractable = InteractionManager.CurrentInteractable;
            if (tempInteractable != null)
            {
                if (tempInteractable is UseInteractableObject)
                    (tempInteractable as UseInteractableObject).Use();
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
            MainPlayerPanel.Instance.ShowMainPlayerPanel(1);
        else if (Input.GetKeyDown(KeyCode.C))
            MainPlayerPanel.Instance.ShowMainPlayerPanel(0);
    }
}
