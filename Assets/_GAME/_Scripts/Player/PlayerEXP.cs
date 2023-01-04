using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEXP : MonoBehaviour
{
    private Slider   EXPSlider;
    private TMP_Text LevelText;

    private static readonly int[] EXPLevels    = { 0, 3, 7, 12, 20 };
    private                 int   currentEXP   = 0;
    private                 int   currentLevel = 1;

    public        int         upgradePoint;
    public static Action<int> GainedEXP;

    private void Awake()
    {
        GainedEXP += OnExpGained;
        InitEXPSlider();
    }

    private void OnDestroy()
    {
        GainedEXP -= OnExpGained;
    }

    private void InitEXPSlider()
    {
        EXPSlider          = GameObject.Find("EXPBar").GetComponent<Slider>();
        LevelText          = GameObject.Find("LevelText").GetComponent<TMP_Text>();
        EXPSlider.minValue = EXPLevels[0];
        EXPSlider.maxValue = EXPLevels[1];
    }

    private void OnExpGained(int amount)
    {
        currentEXP      += amount;
        EXPSlider.value =  currentEXP;

        if (currentEXP == EXPLevels[currentLevel])
            LevelUp();
    }

    private void LevelUp()
    {
        currentLevel++;
        upgradePoint++;

        EXPSlider.minValue = EXPLevels[currentLevel - 1];
        EXPSlider.maxValue = EXPLevels[currentLevel];
        LevelText.SetText($"Level {currentLevel}");
    }
}