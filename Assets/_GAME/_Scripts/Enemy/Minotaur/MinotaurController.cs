using System;
using System.Collections;
using _GAME._Scripts.Enemy.Minotaur;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinotaurController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D      rb;
    [SerializeField] private HomingProjectile projectilePrefab;

    [SerializeField] private Animator         animator;
    private                  PlayerController player;

    private EnemyController _enemyController;

    private const float ThinkingTime = 3f;
    private       float dt           = ThinkingTime;
    public static bool  locked       = true;
    private       int   Action;

    private float playerDir => transform.position.x > player.transform.position.x ? -1f : 1f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerDir == -1f)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        if ((dt -= Time.deltaTime) > 0) return;

        if (locked) return;
        dt = ThinkingTime;
        DecideNextAction();
    }

    private void DecideNextAction()
    {
        Action = Random.Range(0, 4);
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
            case 3:
                StartCoroutine(Run());
                break;
        }
    }

    [SerializeField] private float runvel, runseconds;

    private IEnumerator Run()
    {
        Debug.Log("Run");
        animator.SetBool("Running", true);
        var t = runseconds;

        while ((t -= Time.deltaTime) > 0)
        {
            rb.velocity = new Vector2(runvel * playerDir, 0);
            yield return null;
        }

        animator.SetBool("Running", false);
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
        yield return new WaitForSeconds(.3f);

        // second jump
        Debug.Log("Jump 1");
        rb.AddForce(new Vector2(playerDir * jumpX * 1f, jumpY * 1.3f));
        animator.transform.DOLocalRotate(new Vector3(0, 0, -360f), .5f, RotateMode.FastBeyond360).From(Vector3.zero);

        yield return new WaitForSeconds(.5f);
    }


    [SerializeField] private float slash1delay,  slash2delay, slash3delay;
    [SerializeField] private float slash2xscale, slash3xscale;


    private IEnumerator Dash()
    {
        // first dash
        rb.AddForce(new Vector2(playerDir * dashX, dashY));
        animator.SetTrigger("Slash1");
        yield return new WaitForSeconds(slash1delay);

        // second dash
        rb.AddForce(new Vector2(playerDir * dashX * slash2xscale, dashY));
        animator.SetTrigger("Slash2");
        yield return new WaitForSeconds(slash2delay);

        // third dash
        rb.AddForce(new Vector2(playerDir * dashX * slash3xscale, dashY));
        animator.SetTrigger("Slash3");
    }

    [SerializeField] private float JumpShootDelay;
    [SerializeField] private float JumpShootRatio;
    [SerializeField] private float projectileVel;

    private IEnumerator Shoot()
    {
        animator.SetBool("Shoot", true);
        rb.gravityScale = 1f;
        rb.AddForce(new Vector2(playerDir * jumpShootX, jumpShootY));
        yield return new WaitForSeconds(JumpShootDelay);

        rb.velocity    = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        for (int i = 0; i < 3; i++)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            StartCoroutine(projectile.AimTo(player, shootTime, projectileVel));
            yield return new WaitForSeconds(.3f);
        }

        animator.SetBool("Shoot", false);
        rb.constraints  = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 8f;
        rb.AddForce(new Vector2(playerDir * jumpShootX, jumpShootY * JumpShootRatio));
    }
}