using UnityEngine;

public class EatFood : MonoBehaviour
{
[SerializeField] public string FoodItEats;
private bool IsHungry = true;

[Serializefield] private 
private void OnCollisionEnter(Collision collision)
{
    if (!IsHungry)
    {
        return;
    }

    if (collision.gameObject.name == FoodItEats || collision.gameObject.CompareTag(FoodItEats))
    {
        Destroy(collision.gameObject);
        IsHungry = false;
    }
}
}