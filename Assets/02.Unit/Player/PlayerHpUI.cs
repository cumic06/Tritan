using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoSigleton<PlayerHpUI>
{
    [SerializeField] private Slider hpSlider;

    public void PlayerHpSlider(float hpPer)
    {
        hpSlider.value = hpPer;
    }
}
