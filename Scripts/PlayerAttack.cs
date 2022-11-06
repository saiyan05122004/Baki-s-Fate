using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour //Создание анимации и точки атаки игрока
{
     // Добавление переменных и ссылок
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamge = 40; 
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Получения кода клавиши "G" для выполнения Attack()
        {
            Attack(); // ссылка на (void Attack)
            
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // Загрузка анимации
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange , enemyLayers); //получение колайдера

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamge);
        }
    }

    void OnDrawGizmosSelected() // Параметр для показа (attackPoint.position, attackRange) зоны атаки , для дальнейшего насторойки атаки 
    {
        if  (attackPoint == null )
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
  
}
