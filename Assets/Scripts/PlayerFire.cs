using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private bool isCoroutine = false;
    [SerializeField] private bool isFiring = false;
    [SerializeField] private float fireDelay = 0.5f;
    [SerializeField] private bool isReloading = false;
    [SerializeField] private float reloadDelay = 3f;
    private Animator animator;

    public Transform muzzle;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isFiring)
        {
            if (!isCoroutine) StartCoroutine(FireCoroutine());
        }
    }


    private void OnFire(InputValue inputValue)
    {
        Debug.Log(inputValue.Get());
        if (inputValue.Get() != null) isFiring = true;
        else isFiring = false;
    }

    private IEnumerator FireCoroutine()
    {
        isCoroutine = true;

        Debug.Log("��");

        animator.SetTrigger("Fire");

        yield return new WaitForSeconds(fireDelay);

        isCoroutine = false;
    }

    private void OnReload(InputValue inputValue)
    {
        Debug.Log("������");
        if (!isReloading)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;

        Debug.Log("ö��");

        animator.SetTrigger("Reload");

        yield return new WaitForSeconds(reloadDelay);

        isReloading = false;
    }


}
