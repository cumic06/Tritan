using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private Text timeTxt;

    public void SetTimeUI(float time)
    {
        timeTxt.text = $"PlayTime {TimeManager.Instance.Min:00}:{time:F2}";
    }
}
