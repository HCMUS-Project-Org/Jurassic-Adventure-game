using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Score
{
    public string name;
    public int    score;

    public Score(string name, int score)
    {
        this.name  = name;
        this.score = score;
    }
}

public class Scoreboard : MonoBehaviour
{
    private static SortedList<int, Score> scores;

    [SerializeField] private TMP_Text name1,  name2,  name3,  name4,  name5;
    [SerializeField] private TMP_Text score1, score2, score3, score4, score5;

    private void OnEnable()
    {
        SetRow(scores.ElementAtOrDefault(0).Value, name1, score1);
        SetRow(scores.ElementAtOrDefault(1).Value, name2, score2);
        SetRow(scores.ElementAtOrDefault(2).Value, name3, score3);
        SetRow(scores.ElementAtOrDefault(3).Value, name4, score4);
        SetRow(scores.ElementAtOrDefault(4).Value, name5, score5);
    }

    public static void AddNewScore(Score score)
    {
        scores ??= new SortedList<int, Score>();
        scores.Add(score.score, score);
    }

    private void SetRow(Score score, TMP_Text nameText, TMP_Text scoreText)
    {
        if (score == default) return;
        score.name = Regex.Replace(score.name, @"\p{C}+", string.Empty);

        string name     = string.IsNullOrEmpty(score.name) ? "Sat Thu Vo Hinh" : score.name;
        string scoreInt = score.score.ToString();

        nameText.SetText(name);
        scoreText.SetText(scoreInt);
    }
}