using System;
using _GAME._Scripts.Enemy;
using UnityEngine;

namespace _GAME._Scripts.UI.Library
{
    public class GiveEnemyData : MonoBehaviour
    {
        [SerializeField] private EnemyData dataToGive;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
                LibraryPanel.datas.Add(dataToGive);
        }
    }
}