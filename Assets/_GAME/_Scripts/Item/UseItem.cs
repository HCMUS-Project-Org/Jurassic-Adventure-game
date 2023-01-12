using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [SerializeField] private KeyCode onKey;
    // [SerializeField] private ItemSlot item;

    [SerializeField] private AudioClip _useItemSound;

    private void Update()
    {
        if (Input.GetKeyDown(onKey))
        {
            if (AudioControl.instance != null)
                AudioControl.instance.PlaySound(_useItemSound);
            Use();
        }
    }

    private void Use()
    {
        if (transform.childCount == 1)
        {
            transform.GetComponentInChildren<Item>().Use();
        }
    }
}