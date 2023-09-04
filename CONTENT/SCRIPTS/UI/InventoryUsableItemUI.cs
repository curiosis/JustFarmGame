using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUsableItemUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selectorFrame;
    [SerializeField]
    private RawImage icon;

    public void ChangeSelectorState(bool isActive)
    {
        selectorFrame.SetActive(isActive);
    }

    public void SetIcon(Sprite newIcon)
    {
        icon.texture = newIcon.texture;
    }
}
