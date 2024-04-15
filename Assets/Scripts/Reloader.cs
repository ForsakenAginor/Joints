using System.Collections;
using UnityEngine;

public class Reloader : MonoBehaviour
{
    [SerializeField] private GameObject _joint;
    [SerializeField] private Transform _spherePrefab;
    [SerializeField] private Transform _spawnPoint;

    private bool _isReloading = true;
    private bool _isArmed = false;

    public bool IsArmed => _isArmed;

    private void Start()
    {
        StartCoroutine(Reloading());    
    }

    private void Update()
    {
        if (_isArmed)
            return;

        if (_isReloading)
            return;

        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Reloading());
    }

    public void Defuse()
    {
        _isArmed = false;
    }

    private IEnumerator Reloading()
    {
        float reloadingTime = 3f;
        WaitForSeconds reloadingDelay = new WaitForSeconds(reloadingTime);
        _isReloading = true;
        _joint.SetActive(true);

        yield return reloadingDelay;

        Vector3 spawnPoint = _spawnPoint.TransformPoint(Vector3.zero);
        Instantiate(_spherePrefab, spawnPoint, Quaternion.identity);
        _isReloading = false;
        _isArmed = true;
    }
}
