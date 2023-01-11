using System;
using System.Collections.Generic;
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
        SetRow(scores[0], name1, score1);
        SetRow(scores[1], name2, score2);
        SetRow(scores[2], name3, score3);
        SetRow(scores[3], name4, score4);
        SetRow(scores[4], name5, score5);
    }

    public static void AddNewScore(Score score)
    {
        scores.Add(score.score, score);
    }

    private void SetRow(Score score, TMP_Text nameText, TMP_Text scoreText)
    {
        string name     = score?.name ?? "<empty>";
        string scoreInt = score?.score.ToString() ?? "<empty>";

        nameText.SetText(name);
        scoreText.SetText(scoreInt);
    }
}