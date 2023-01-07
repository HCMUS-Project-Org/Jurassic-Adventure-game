using System;
using System.Collections.Generic;
using _GAME._Scripts.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME._Scripts.UI.Library
{
    public class LibraryPanel : MonoBehaviour
    {
        [SerializeField] private     Image    image;
        [SerializeField] private new TMP_Text name;
        [SerializeField] private     TMP_Text height;
        [SerializeField] private     TMP_Text length;
        [SerializeField] private     TMP_Text weight;
        [SerializeField] private     TMP_Text speed;
        [SerializeField] private     TMP_Text description;

        [SerializeField] private GameObject emptyPanel, infoPanel;

        public static List<EnemyData> datas        = new();
        public        int             currentIndex = 0;

        public void OnEnable()
        {
            if (datas.Count == 0)
            {
                emptyPanel.SetActive(true);
                infoPanel.SetActive(false);
            }
            else
            {
                emptyPanel.SetActive(false);
                infoPanel.SetActive(true);
                currentIndex = 0;
                UpdateData();
            }
        }

        public void NextPressed()
        {
            currentIndex++;
            if (currentIndex == datas.Count)
            {
                currentIndex = 0;
            }

            UpdateData();
        }

        public void PreviousPressed()
        {
            currentIndex--;
            if (currentIndex == -1)
            {
                currentIndex = datas.Count - 1;
            }

            UpdateData();
        }

        private void UpdateData()
        {
            var enemy = datas[currentIndex];

            image.sprite = enemy.image;
            name.SetText(enemy.name);
            height.SetText(enemy.height);
            length.SetText(enemy.length);
            weight.SetText(enemy.weight);
            speed.SetText(enemy.speed);
            description.SetText(enemy.description);
        }
    }
}