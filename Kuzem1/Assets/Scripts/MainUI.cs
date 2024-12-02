using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public CanvasGroup failCanvasGroup;
    public CanvasGroup victoryCanvasGroup;
    public TMP_Text levelText;

    public void CloseMainUI()
    {
        failCanvasGroup.gameObject.SetActive(false);
    }
    public void LevelFailed()
    {
        failCanvasGroup.gameObject.SetActive(true);
    }

    public void SetLevelText(int level)
    {
        levelText.text = "Level: " + level;
    }
    public void LevelComplated()
    {
        victoryCanvasGroup.gameObject.SetActive(true);
    }
}
