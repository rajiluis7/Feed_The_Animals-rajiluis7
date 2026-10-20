using UnityEngine;

public class SpawnManager : MonoBehaviour
{
public static SpawnManager Instance { get; private set; }
[SerializeField] private GameObject[] animalPrefab;
[SerializeField] private int animalsToFeed;
[SerializeField] private float spawnStart;
[SerializeField] private float startFrequency;
[SerializeField] private float spawnZPosition;
[SerializeField] private float centerToEdge;
private float timer;
public bool isGameOver{get; private set;}

private void Awake()
{
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
}

private void Start()
{
    spawnZPosition = 20f;
    centerToEdge = 15f;
    timer = startFrequency;
    isGameOver = false;
}

private void Update()
{
    HandleSpawning();
}

private void HandleSpawning()
{
    if (isGameOver)
    {
        return;
    }

    timer -= Time.deltaTime;

    if (timer <= 0f)
    {
        SpawnAnimal();
        timer = startFrequency;
    }
}

private void SpawnAnimal()
{
    if (animalPrefab == null || animalPrefab.Length == 0)
    {
        return;
    }
    if(animalsToFeed > 0)
    {
        int randomPrefabIndex = Random.Range(0, animalPrefab.Length);
        float randomXPosition = Random.Range(-centerToEdge, centerToEdge);
        Vector3 spawnPosition = new Vector3(randomXPosition, 0f, spawnZPosition);

        Instantiate(animalPrefab[randomPrefabIndex], spawnPosition, animalPrefab[randomPrefabIndex].transform.rotation);
        animalsToFeed--;
    }
    else
    {
        GameOver();
    }
}

private void GameOver()
{
    Debug.Log("Game Over");
    isGameOver = true;
}

// Called by: UIManager
public int GetNumberOfAnimalsToFeed()
{
    return animalsToFeed;
}
}