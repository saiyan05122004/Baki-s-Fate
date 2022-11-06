using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Подключение необходиммых библиотек

public class Teleport : MonoBehaviour // Загрузка сцены при соприкосновении 
{
    
    private void OnTriggerEnter2D(Collider2D collision) // Получение колайдера
    {
        if (collision.gameObject.tag == "Player") // Услловие (Если {колайдер} соприкосается с тэгом) то...
        {
            SceneManager.LoadScene("Game2"); // С помощью библиотеки загружаем сцену "..."
        }
    }
}
