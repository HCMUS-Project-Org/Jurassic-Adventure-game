using TMPro;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    [SerializeField] private TMP_Text name;

    public void Save()
    {
        var score = new Score(name.text, PlayerController.score);
        Scoreboard.AddNewScore(score);
    }
}