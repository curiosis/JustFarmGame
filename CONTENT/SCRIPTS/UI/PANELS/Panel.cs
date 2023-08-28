using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField]
    protected GameObject mainPanel;
}

public class ClosablePanel : Panel
{
    [SerializeField]
    private Button ExitButton;

    private void OnEnable()
    {
        ExitButton.onClick.AddListener(ExitPanel);
    }

    private void OnDisable()
    {
        ExitButton.onClick.RemoveAllListeners();
    }

    protected void ExitPanel()
    {
        mainPanel.SetActive(false);
        TimeManager.Instance.ResumeTime();
    }
}
