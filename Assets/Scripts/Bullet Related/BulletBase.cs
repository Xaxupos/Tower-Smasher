using UnityEngine;
using VInspector;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private BulletConfig _config;
    [ReadOnly] [SerializeField] private BulletCurrentData _currentData;

    private WeaponStrategy _weaponStrategy;
    private Timer _projectileLifeTimer;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        ContactPoint2D contact = other.contacts[0];

        if(other.gameObject.GetComponentInChildren<HealthSystem>())
        {
            var healthSystem = other.gameObject.GetComponentInChildren<HealthSystem>();
            healthSystem.TakeDamage((int)_currentData.Damage);
        }

        CreateAudioVisuals(_config.ImpactVFX, contact.point, _config.ImpactClip, true);
        _projectileLifeTimer?.StopTimer();
        PoolManager.Instance.ReleaseToPool(_config.BulletType, gameObject);
    }

    public virtual void Initialize(WeaponStrategy weaponStrategy)
    {
        _weaponStrategy = weaponStrategy;
        _currentData = new BulletCurrentData();
        _projectileLifeTimer = new Timer(_config.ProjectileLifetime, () => PoolManager.Instance.ReleaseToPool(_config.BulletType, gameObject));
        _projectileLifeTimer.Start();

        CalculateCurrentData();
        CreateAudioVisuals(_config.FireVFX, transform.position, _config.FireClip);
    }
    
    public virtual void Update()
    {
        _projectileLifeTimer?.Update(Time.deltaTime);
    }

    public virtual void FixedUpdate() 
    {
        _rigidbody2D.linearVelocity = transform.right * _currentData.Speed;
    }

    protected virtual void CalculateCurrentData()
    {
        _currentData.Speed = _weaponStrategy.ProjectileSpeed * _config.SpeedModificator;
        _currentData.Damage = _weaponStrategy.Damage * _config.DamageModificator;
    }

    protected virtual void CreateAudioVisuals(PooledType vfxType, Vector3 position, AudioClip clip = null, bool setRightToUp = false)
    {
        if(clip)
            AudioSource.PlayClipAtPoint(clip, transform.position);

        if(vfxType != PooledType.EMPTY)
        {
            var pooledVFX = PoolManager.Instance.GetFromPool(vfxType);
            pooledVFX.transform.position = position;
            pooledVFX.transform.right = -transform.right;

            if(setRightToUp)
                pooledVFX.transform.up = -transform.right;

            ReturnVFXToPool(pooledVFX, vfxType);
        }   
    }

    private void ReturnVFXToPool(GameObject vfx, PooledType poolType)
    {
        var ps = vfx.GetComponent<ParticleSystem>();

        if(ps == null)
        {
            ps = vfx.GetComponentInChildren<ParticleSystem>();
        }

        PoolManager.Instance.ReleaseToPool(poolType, vfx, ps.main.duration);
    }
}