using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoblinKingController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D projectilePrefab;

    [SerializeField] private Transform        visual;
    private                  PlayerController player;

    private const float ThinkingTime = 5f;
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
                StartCoroutine(Jump());
                break;
            case 1:
                StartCoroutine(Dash());
                break;
            case 2:
                StartCoroutine(Shoot());
                break;
        }
    }

    [SerializeField] private float jumpX,      jumpY;
    [SerializeField] private float dashX,      dashY;
    [SerializeField] private float jumpShootX, jumpShootY;

    [SerializeField] private float shootXmin, shootXmax;
    [SerializeField] private float shootYmin, shootYmax;
    [SerializeField] private float shootTime;


    private IEnumerator Jump()
    {
        Debug.Log("Jump 0");
        rb.AddForce(new Vector2(playerDir * jumpX, jumpY));
        yield return new WaitForSeconds(.5f);

        // second jump
        Debug.Log("Jump 1");
        rb.AddForce(new Vector2(playerDir * jumpX * 2f, jumpY * 2f));
        visual.DORotate(new Vector3(0, 0, 360), .5f);
        yield return new WaitForSeconds(.5f);
    }

    private IEnumerator Dash()
    {
        // first dash
        Debug.Log("Dash 0");
        rb.AddForce(new Vector2(playerDir * dashX, dashY));
        yield return new WaitForSeconds(.3f);

        // second dash
        Debug.Log("Dash 1");
        rb.AddForce(new Vector2(playerDir * dashX * 1.3f, dashY));
        yield return new WaitForSeconds(.6f);

        // third dash
        Debug.Log("Dash 2");
        rb.AddForce(new Vector2(playerDir * dashX * 0.3f, dashY));
    }

    private IEnumerator Shoot()
    {
        rb.AddForce(new Vector2(playerDir * jumpShootX, jumpShootY));
        yield return new WaitForSeconds(.1f);

        rb.velocity    = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Shoot " + i);
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // projectile.AddForce(new Vector2(shootX, shootY));
            Destroy(projectile.gameObject, shootTime);
            yield return new WaitForSeconds(.3f);
        }

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}