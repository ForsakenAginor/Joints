using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Reloader _reloader;
    [SerializeField] private GameObject _joint;

    private void Update()
    {
        if (_reloader.IsArmed == false)
            return;

        if(Input.GetMouseButtonDown(1))
        {
            _joint.SetActive(false);
            _reloader.Defuse();
        }
    }
}
