using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoSigleton<InGameUIManager>
{
    [SerializeField] private Image useItemImage;
    [SerializeField] private Text useItemText;
    Coroutine useCor;

    private void Start()
    {
        Time.timeScale = 1;
        UseItemImage(GameManager.Instance.gameStage.ToString());
    }


    public void UseItemImage(string value)
    {
        if (useCor != null)
        {
            StopCoroutine(useCor);
        }
        useCor = StartCoroutine(UseItem());

        IEnumerator UseItem()
        {
            useItemImage.gameObject.SetActive(true);
            useItemText.text = value;
            yield return new WaitForSeconds(1);
            useItemImage.gameObject.SetActive(false);
        }
    }
}
