using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPrefab; // Префаб кирпичика
    public int[,] levelMatrix = new int[,]
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    }; // Пример фиксированной матрицы

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        int width = levelMatrix.GetLength(1);
        int height = levelMatrix.GetLength(0);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Проверяем, нужно ли создать кирпич
                if (levelMatrix[y, x] == 1)
                {
                    CreateBrick(x, y, width, height);
                }
            }
        }
    }

    void CreateBrick(int x, int y, int width, int height)
    {
        float spacing = 0.5f; // Расстояние между кирпичами (размер кирпича)

        // Смещение по оси X и Y
        float posX = x - (width / 2f) + 0.5f;
        float posY = y - (height / 2f) + 2.5f;

        Vector3 position = new Vector3(posX * spacing, posY * spacing, 0);
        Instantiate(brickPrefab, position, Quaternion.identity); // Создаём кирпичик
    }
}
