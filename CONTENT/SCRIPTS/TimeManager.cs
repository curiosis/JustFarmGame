using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI calendarText;
    [SerializeField]
    private RectTransform hClock, minClock;
    [SerializeField]
    private GameObject timeAndClockGO;

    public int Min { get; private set; }
    public int Day { get; private set; }
    public int H { get; private set; }

    public bool IsShow { get => timeAndClockGO.activeSelf; private set => IsShow = value; }

    private static TimeManager instance;
    private float time;

    public static TimeManager Instance
    {
        get => instance;
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<TimeManager>();
        }
        SetStartH(8);
    }

    private void Update()
    {
        CalculateTime();
        ShowTimeAndCalendar();
    }

    public void StopTime()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }

    private void CalculateTime()
    {
        time += Time.deltaTime;
        Min = ((int)(time / 2.0f))%60;
        H = (((int)(time / 2.0f))/60)% 24;
        Day = ((((int)(time / 2.0f)) / 60) / 24) + 1;
    }

    private void ShowTimeAndCalendar()
    {
        timeText.text = H.ToString("00") + ":" + Min.ToString("00");
        calendarText.text = "Day: " + Day.ToString();

        Vector3 currentRotation = hClock.eulerAngles;
        currentRotation.z = -30 * H;
        hClock.eulerAngles = currentRotation;

        currentRotation = minClock.eulerAngles;
        currentRotation.z = -6 * Min;
        minClock.eulerAngles = currentRotation;
    }

    private void SetStartH(int startH)
    {
        time = 120.0f * startH;
    }

    public void ChangeVisUITimeAndCalendar()
    {
        timeAndClockGO.SetActive(!IsShow);
    }
}
