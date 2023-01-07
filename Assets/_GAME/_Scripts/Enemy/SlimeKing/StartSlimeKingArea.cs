using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSlimeKingArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // start boss move
        if (col.CompareTag("Player"))
        {
            SlimeKingController.locked = false;
            Destroy(gameObject);
        }
    }
}