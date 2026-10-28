using UnityEngine;

public class FoodLifeCycle : MonoBehaviour
{
[SerializeField] private float lifeDuration;

private void Start()
{
    Destroy(gameObject, lifeDuration);
}
}