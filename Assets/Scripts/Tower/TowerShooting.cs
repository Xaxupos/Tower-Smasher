using UnityEngine;

public class TowerShooting : TowerComponent
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private WeaponStrategy _currentStrategy;

    private void Awake() 
    {
        _currentStrategy?.Initialize();
    }

    private void Update() 
    {
        //just to test the strattegy pattern
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _currentStrategy.Fire(_firePoint, _bulletConfig);
        }
    }
}