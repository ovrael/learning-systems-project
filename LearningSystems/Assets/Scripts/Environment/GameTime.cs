using System;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;

    [Tooltip("How many minutes per real life second")]
    [Range(0.5f, 90f)]
    [SerializeField]
    private float simulationSpeed = 1;
    private float elapsed = 0f;

    [SerializeField]
    private int day = 0;
    public int Day
    {
        get
        {
            return day;
        }
        set
        {
            day = value;
        }
    }

    [SerializeField]
    private int minute = 0;
    public int Minute
    {
        get
        {
            return minute;
        }
        set
        {
            if (value > 59)
            {
                minute = value % 60;
                Hour++;
            }
            else
            {
                minute = value;
            }
        }
    }

    [SerializeField]
    private int hour = 0;
    public int Hour
    {
        get
        {
            return hour;
        }
        set
        {
            if (value > 23)
            {
                hour = value % 24;
                Day++;
            }
            else
            {
                hour = value;
            }
        }
    }

    public void AddTime(int minute, int hour, int day)
    {
        Minute += minute;
        Hour += hour;
        Day += day;
    }
    private void Start()
    {
        timeText.text = GetTime();
        Time.timeScale = simulationSpeed;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            int minutes = ((int)elapsed) % 100;
            AddTime(minutes, 0, 0);

            elapsed %= 1f;
            timeText.text = GetTime();
        }
    }

    private void OnValidate()
    {
        Time.timeScale = simulationSpeed;
    }

    public string GetTime()
    {
        return $"{AddLeftPadding(Hour)}.{AddLeftPadding(Minute)} Day {AddLeftPadding(Day)}";
    }

    private string AddLeftPadding(int value)
    {
        return value < 10 ? $"0{value}" : $"{value}";
    }
}