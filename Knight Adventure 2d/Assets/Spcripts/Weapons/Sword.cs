using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PolygonCollider2D _polygonCollider2D;
    public event EventHandler OnSwordSwing;
    [SerializeField] int _damageAmount = 2;
    private void Awake() {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }
    private void Start() {
        AttackColliderTurnOff();
    }
    public void Attack()
    {
        AttackColliderTurnOffOn();
        OnSwordSwing?.Invoke(this,EventArgs.Empty);
    }   
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.TryGetComponent(out EnemyEntity enemyEntity))
        {
            enemyEntity.TakeDamage(_damageAmount);
        }
    }
    public void AttackColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }
    private void AttackColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }
    private void AttackColliderTurnOffOn()
    {
        AttackColliderTurnOff();
        AttackColliderTurnOn();
    }
}
