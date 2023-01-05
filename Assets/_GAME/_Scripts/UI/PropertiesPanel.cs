using System;
using UnityEngine;

namespace _GAME._Scripts.UI
{
    public class PropertiesPanel : MonoBehaviour
    {
        private PlayerEXP _playerExp;

        private void Start()
        {
            _playerExp = FindObjectOfType<PlayerEXP>();
        }

        public void UpgradeHealPressed()
        {
            if (_playerExp.upgradePoint > 0)
            {
                _playerExp.upgradePoint    -= 1;
                PlayerHealth.currentHealth += 1;
                PlayerHealth.maxHealth     += 1;
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