using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlimeKingController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D projectilePrefab;

    private PlayerController player;

    private const float ThinkingTime = 3f;
    private       float dt           = ThinkingTime;
    public static bool  locked       = true;
    private       int   Action;

    private float playerDir => transform.position.x > player.transform.position.x ? -1f : 1f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    private void Update()
    {
        if ((dt -= Time.deltaTime) > 0) return;

        if (locked) return;
        dt = ThinkingTime;
        DecideNextAction();
    }

    private void DecideNextAction()
    {
        Action = Random.Range(0, 3);
        switch (Action)
        {
            case 0:
                Jump();
                break;
            case 1:
                Dash();
                break;
            case 2:
                Shoot();
                break;
        }
    }

    [SerializeField] private float jumpX,      jumpY;
    [SerializeField] private float dashX,      dashY;
    [SerializeField] private float jumpShootX, jumpShootY;

    [SerializeField] private float shootXmin, shootXmax;
    [SerializeField] private float shootYmin, shootYmax;
    [SerializeField] private float shootTime;


    private void Jump()
    {
        rb.AddForce(new Vector2(playerDir * jumpX, jumpY));
    }

    private void Dash()
    {
        rb.AddForce(new Vector2(playerDir * dashX, dashY));
    }

    private void Shoot()
    {
        rb.AddForce(new Vector2(playerDir * jumpShootX, jumpShootY));

        for (int i = 0; i < 3; i++)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 361));
            var shootX = Random.Range(shootXmin, shootXmax);
            var shootY = Random.Range(shootYmin, shootYmax);
            projectile.AddForce(new Vector2(shootX, shootY));
            Destroy(projectile.gameObject, shootTime);
        }
    }
}