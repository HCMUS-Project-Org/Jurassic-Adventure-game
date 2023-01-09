using System.Collections;
using UnityEngine;

namespace _GAME._Scripts.Enemy.Minotaur
{
    public class HomingProjectile : MonoBehaviour
    {
        public IEnumerator AimTo(PlayerController player, float shootTime, float vel)
        {
            var         tf = transform;
            Vector3     dir;
            float       angle;
            Quaternion  rotate;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            var t = shootTime;

            while ((t -= Time.deltaTime) >= 0)
            {
                dir   = (player.transform.position - tf.position).normalized;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                rotate      = Quaternion.AngleAxis(angle, Vector3.forward);
                tf.rotation = Quaternion.Slerp(tf.rotation, rotate, Time.deltaTime * vel);
                rb.velocity = new Vector2(dir.x * 2 * vel, dir.y * 2 * vel);

                yield return null;
            }

            Destroy(gameObject);
        }
    }
}