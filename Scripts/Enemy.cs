using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // Получения урона и уничтожение врага 
{ // Добавление переменных
    public int maxHelth = 100; // Здоровье врага(публичный(можно изменить))
    int currentHelth;
    
    void Start()
    {
        currentHelth = maxHelth; // Присваеваем значения
    }

    public void TakeDamage(int damge) // Получения урона
    {
        currentHelth -= damge;

        if (currentHelth <= 0) // Если здоровье остаётся меньше 0 то....
        {
            Die(); // Выполняетя (ссылка на void Die)
        }
    }

    void Die()
    
    {
        Debug.Log("Enemy died!");
        Destroy(this.gameObject); // Уничтожение объекта
    }
}
