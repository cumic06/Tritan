using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIEffect : MonoSigleton<PlayerUIEffect>
{
    [SerializeField] private Image hitImage;
    [SerializeField] private Image healImage;

    public void ActiveHitEffect(bool active)
    {
        hitImage.gameObject.SetActive(active);
    }

    public void ActiveHealEffect(bool active)
    {
        healImage.gameObject.SetActive(active);
    }
}
