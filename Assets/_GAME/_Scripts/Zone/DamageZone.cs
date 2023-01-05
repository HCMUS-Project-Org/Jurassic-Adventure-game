using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage = 1;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            controller.health.ChangeHealth(-damage);
            controller.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80f, ForceMode2D.Impulse);
        }
    }
}