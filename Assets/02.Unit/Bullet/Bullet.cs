using UnityEngine;

[RequireComponent(typeof(BulletDestroySystem))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;

    [SerializeField] protected int bulletDamage;

    [SerializeField] protected TeamType teamType;

    [SerializeField] protected GameObject hitEffect;

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.up);
    }


    private void Damage(Collider other, Unit unit)
    {
        if (unit.GetTeamType() != teamType)
        {
            unit.TakeDamage(bulletDamage);
            GameObject spawnHitEffect = Instantiate(hitEffect);
            spawnHitEffect.transform.position = other.transform.position;
            spawnHitEffect.transform.eulerAngles = -other.transform.forward;
            Destroy(gameObject);
        }
    }

    public TeamType GetTeamType()
    {
        return teamType;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Unit unit))
        {
            Damage(other, unit);
        }
    }
}