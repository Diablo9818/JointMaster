using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Transform _projectilePoint;
    [SerializeField] private float _shootForce;
    [SerializeField] private ProjectileSpawner _projectileSpawner;
    [SerializeField] private Rigidbody _starPoint;
    [SerializeField] private Rigidbody _endPoint;

    private readonly int _leftMouseButtonCode = 0;
    private readonly int _rightMouseButtonCode = 1;

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
        if (Input.GetMouseButtonDown(_leftMouseButtonCode))
        {
            _springJoint.connectedBody = _starPoint;
            _springJoint.spring = _shootForce;
        }
    }

    private void Reload()
    {
        if (Input.GetMouseButtonDown(_rightMouseButtonCode))
        {
            _springJoint.connectedBody = _endPoint;
            _springJoint.spring = 0;
            _projectileSpawner.DelayedSpawn(_projectilePoint);
        }
    }
}
