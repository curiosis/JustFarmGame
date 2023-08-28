using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MainPlayerPanel : ClosablePanel
{
    [Serializable]
    public struct MainPlayerPanelList
    {
        public string PanelName;
        public GameObject ButtonGO;
        public GameObject PanelGO;
    }

    [SerializeField]
    private List<MainPlayerPanelList> panelList;

    private int activePanel;

    [SerializeField]
    private static MainPlayerPanel instance;
    public static MainPlayerPanel Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<MainPlayerPanel>();
            return instance;
        }
    }

    private void Start()
    {
        instance = FindObjectOfType<MainPlayerPanel>();
    }

    public void ShowMainPlayerPanel(int startPanel)
    {
        Vector3 temp;
        mainPanel.SetActive(true);
        TimeManager.Instance.StopTime();
        foreach (MainPlayerPanelList mainPlayerPanelList in panelList)
        {
            mainPlayerPanelList.PanelGO.SetActive(false);
            temp = mainPlayerPanelList.ButtonGO.GetComponent<RectTransform>().anchoredPosition;
            temp.y = 310.0f;
            mainPlayerPanelList.ButtonGO.GetComponent<RectTransform>().anchoredPosition = temp;
        }
        panelList[startPanel].PanelGO.SetActive(true);
        temp = panelList[startPanel].ButtonGO.GetComponent<RectTransform>().anchoredPosition;
        temp.y = 325.0f;
        panelList[startPanel].ButtonGO.GetComponent<RectTransform>().anchoredPosition = temp;
    }
}
