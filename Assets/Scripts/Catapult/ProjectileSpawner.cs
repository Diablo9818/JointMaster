using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _delayTime;

    public void DelayedSpawn(Transform spawnPoint)
    {
        StartCoroutine(Spawn(spawnPoint));
    }

    private IEnumerator Spawn(Transform spawnPoint)
    {
        yield return new WaitForSeconds(_delayTime);
        Instantiate(_projectile, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}
