using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] protected float maxHealth;
    protected float _currentHealth;
    
    [SerializeField] protected float moveSpeed;

    public bool IsDead { get; protected set; }

    protected virtual void Awake()
    {
        _currentHealth = maxHealth;
    }

    // 공통 데미지 처리 로직
    public virtual void TakeDamage(float damage)
    {
        if (IsDead) return;
        
        _currentHealth -= damage;
        OnHit();

        if (_currentHealth <= 0) Die();
    }

    protected abstract void OnHit(); // 피격 시 연출 (역경직, 이펙트 등)
    protected abstract void Die();   // 사망 처리
}