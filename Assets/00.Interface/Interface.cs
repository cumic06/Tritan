interface IDamageable
{
    public abstract void TakeDamage(int damageValue);
}

interface IHealable
{
    public void TakeHeal(int healValue);
}