using UnityEngine;

namespace _GAME._Scripts.Enemy
{
    [CreateAssetMenu]
    public class EnemyData : ScriptableObject
    {
        public     Sprite image;
        public new string name;
        public     string height;
        public     string length;
        public     string weight;
        public     string speed;
        [TextArea(0,10)]
        public     string description;
    }
}