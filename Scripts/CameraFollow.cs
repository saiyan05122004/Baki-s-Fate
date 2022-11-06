using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour //Нахождение игрока и его отслеживание
{
    //Добавление переменных
    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool faceLeft;
    private Transform player;
    private int lastX;

    void Start() // Начальные действия кода (Найти игрока , по ссылке на публичный класс)
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y); // Вычисление математической формулой
        FindPlayer(faceLeft); // ссылка на FindPlayer
    }

    public void FindPlayer(bool playerFaceLeft) // Публичный класс с добавлением переменной
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока по добавленному ему тэгу
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerFaceLeft) //Создаём условие если игрок изначально смотрит налево
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    void Update() // Постоянное отслеживание игрока и обновление данных
    {
        if (player) // Условие с мат. вычислениями
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (faceLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
