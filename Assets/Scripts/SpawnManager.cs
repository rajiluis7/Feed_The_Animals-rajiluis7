using Mono.Cecil.Cil;
using Unity.CodeEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
public static SpawnManager Instance { get; private set; }
[SerializeField] private GameObject[] animalPrefab;
[SerializeField] private int animalsToFeed = 4;
[SerializeField] private float spawnStart = 2f;
[SerializeField] private float startFrequency =1.5f;
[SerializeField] private float spawnZPosition = 20f;
[SerializeField] private float centerToEdge = 20f;
[SerializeField] private int animalsSpawned =0;
private float timer;
public bool isGameOver = false;

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
    timer = startFrequency;
}

private void Update()
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
   
    if (animalsSpawned < animalsToFeed)
    {
        animalsSpawned++;
        int randomPrefabIndex = Random.Range(0, animalPrefab.Length);
        float randomXPosition = Random.Range(-centerToEdge, centerToEdge);
        Vector3 spawnPosition = new Vector3(randomXPosition, 0f, spawnZPosition);

        Instantiate(animalPrefab[randomPrefabIndex], spawnPosition, animalPrefab[randomPrefabIndex].transform.rotation);
        animalsToFeed--;
    }
}

public void GameOver()
{
    isGameOver = true;
}

// Called by: UIManager
public int GetNumberOfAnimalsToFeed()
{
   return animalsToFeed;

}
}