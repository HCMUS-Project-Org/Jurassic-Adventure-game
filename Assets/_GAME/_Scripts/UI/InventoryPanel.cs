using System;
using TMPro;
using UnityEngine;

namespace _GAME._Scripts.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        private PlayerEXP    _playerExp;
        private PlayerHealth _playerHealth;

        [SerializeField] private TMP_Text
            healText, attackText, defenseText, upgradePointsText, levelText;

        private void Awake()
        {
            _playerExp    = FindObjectOfType<PlayerEXP>();
            _playerHealth = _playerExp.GetComponent<PlayerHealth>();
        }

        private void Update()
        {
            healText.SetText("Health: " + PlayerHealth.maxHealth);
            attackText.SetText("Attack: " + Projectile.damage);
            defenseText.SetText("Defend: " + PlayerHealth.defense);
            upgradePointsText.SetText(_playerExp.upgradePoint.ToString());
            levelText.SetText(_playerExp.currentLevel.ToString());
        }

        public void UpgradeHealPressed()
        {
            if (_playerExp.upgradePoint > 0)
            {
                _playerExp.upgradePoint    -= 1;
                PlayerHealth.maxHealth     += 1;
                _playerHealth.ChangeHealth(1);
            }
        }

        public void UpgradeAttackPressed()
        {
            if (_playerExp.upgradePoint > 0)
            {
                _playerExp.upgradePoint -= 1;
                Projectile.damage       += 1;
            }
        }

        public void UpgradeDefensePressed()
        {
            if (_playerExp.upgradePoint > 0)
            {
                _playerExp.upgradePoint -= 1;
                PlayerHealth.defense    += 1;
            }
        }
    }
}