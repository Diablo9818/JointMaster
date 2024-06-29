using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Transform _projectilePoint;
    [SerializeField] private float _shootForce;
    [SerializeField] private ProjectileSpawner _projectileSpawner;
    [SerializeField] private Rigidbody _starPoint;
    [SerializeField] private Rigidbody _endPoint;

    private readonly int LeftMouseButtonCode = 0;
    private readonly int RightMouseButtonCode = 1;

    private void Start()
    {
        _projectileSpawner.DelayedSpawn(_projectilePoint);
    }

    private void Update()
    {
        Shoot();
        Reload();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonCode))
        {
            _springJoint.connectedBody = _starPoint;
            _springJoint.spring = _shootForce;
        }
    }

    private void Reload()
    {
        if (Input.GetMouseButtonDown(RightMouseButtonCode))
        {
            _springJoint.connectedBody = _endPoint;
            _springJoint.spring = 0;
            _projectileSpawner.DelayedSpawn(_projectilePoint);
        }
    }
}
