using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private bool _isEnenmy;
    [SerializeField] private float _intervalAttack;

    public event Action Fire;

    private bool _isReady = false;

    private void Start()
    {
        StartCoroutine(Reload());
    }

    private void Update()
    {
        if (_isReady == false)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && _isEnenmy == false)
            Shoot();
        else if (_isEnenmy)
            Shoot();
    }

    private void Shoot()
    {
        _isReady = false;
        
        Fire?.Invoke();

        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_intervalAttack);
        _isReady = true;
    }
}
