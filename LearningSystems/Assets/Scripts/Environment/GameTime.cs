using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;

    [Tooltip("How many minutes per real life second")]
    [Range(1, 60)]
    [SerializeField]
    private int simulationSpeed = 1;
    public int SimulationSpeed { get { return simulationSpeed; } }

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

    private void Increase1Minute()
    {
        Minute += simulationSpeed;
    }

    private void Awake()
    {
        Day = 0;
        Hour = 5;
        Minute = 0;
        timeText.text = GetTime();
    }

    private void Start()
    {
        InvokeRepeating("Increase1Minute", 1f, 1f);  //1s delay, repeat every 1s
    }

    private void Update()
    {
        timeText.text = GetTime();
    }

    public string GetTime()
    {
        return $"{AddLeftPadding(Hour)}.{AddLeftPadding(Minute)} Day {AddLeftPadding(Day)}";
    }

    private string AddLeftPadding(int value)
    {
        return value < 10 ? $"0{value}" : $"{value}";
    }
    //private void FixedUpdate()
    //{
    //    Minute++;
    //}

}