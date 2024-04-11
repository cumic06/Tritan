using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSigleton<TimeManager>
{
    #region º¯¼ö
    [SerializeField] private float time = 0;
    public float currentTime => time;

    private TimeUI timeUI;
    public int Min = 0;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        timeUI = GetComponent<TimeUI>();
    }

    private void FixedUpdate()
    {
        AddTime();
    }

    private void AddTime()
    {
        if (time >= 60)
        {
            time = 0;
            Min++;
        }

        time += Time.deltaTime;
        timeUI.SetTimeUI(time);
    }

    public float GetTime()
    {
        return time;
    }
}
