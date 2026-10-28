using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
public static UIManager Instance { get; private set; }

[SerializeField] private UIDocument uiDocument;

private Label animalsRemainingUI;
private Label scoreUI;
private int animalsRemaining;
private int score = 0;

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
    if (uiDocument != null)
    {
        VisualElement root = uiDocument.rootVisualElement;
        if (root != null)
        {
            scoreUI = root.Q<Label>("ScoreLabel");
            animalsRemainingUI = root.Q<Label>("AnimalsRemainingLabel");
        }
    }

    score = 0;

    if (scoreUI != null)
    {
        scoreUI.text = "Score: " + score;
    }

    if (SpawnManager.Instance != null)
    {
        animalsRemaining = SpawnManager.Instance.GetNumberOfAnimalsToFeed();
    }

    if (animalsRemainingUI != null)
    {
        animalsRemainingUI.text = "Animals Remaining: " + animalsRemaining.ToString();
    }
}

// Called by: Animal
public void ScoreUpdate(int scoreUpdate)
{
    score += scoreUpdate;

    if (scoreUI != null)
    {
        scoreUI.text = "Score: " + score;
    }
}

// Called by: Animal
public void AnimalsRemainingUpdate()
{
    if (animalsRemaining > 0)
    {
        animalsRemaining--;

        if (animalsRemainingUI != null)
        {
            animalsRemainingUI.text = "Animals Remaining: " + animalsRemaining;
        }

        if (animalsRemaining <= 0 && SpawnManager.Instance != null)
            {
                SpawnManager.Instance.GameOver();
            }
    }
}
}