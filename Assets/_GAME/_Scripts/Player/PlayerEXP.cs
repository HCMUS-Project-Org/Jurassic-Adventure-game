using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEXP : MonoBehaviour
{
    private Slider EXPSlider;

    private static readonly int[] EXPLevels    = { 3, 7, 12, 20 };
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
        EXPSlider.minValue = 0;
        EXPSlider.maxValue = EXPLevels[0];
    }
    
    private void OnExpGained(int amount)
    {
        currentEXP      += amount;
        EXPSlider.value =  currentEXP;

        if (currentEXP == EXPLevels[currentLevel - 1])
            LevelUp();
    }

    private void LevelUp()
    {
        currentLevel++;
        upgradePoint++;

        EXPSlider.minValue = EXPLevels[currentLevel - 1];
        EXPSlider.minValue = EXPLevels[currentLevel];
    }
}