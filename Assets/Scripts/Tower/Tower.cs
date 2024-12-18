using UnityEngine;

public class Tower : MonoBehaviour, ITarget
{
    [Header("Dependencies")] 
    [SerializeField] private TowerShooting _towerShooting;


    private void Start()
    {
        _towerShooting.Initialize(this);
    }
}