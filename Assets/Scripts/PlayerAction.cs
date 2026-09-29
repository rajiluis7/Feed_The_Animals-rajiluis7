/*
 * GameObject: Player
 * Component: PlayerAction
 * 
 * Description:
 * Handles the player's food throwing actions based on input from the Player Input component.
 * Evaluates the pressed button control, selects the corresponding food item prefab from an array,
 * instantiates the prefab at the player's center position, plays a sound effect via AudioSource,
 * and applies forward physics force to launch the food item.
 */

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject[] foodItems;
    private AudioSource audioSource;
    private string controlNameContains;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Called by: Player Input
    public void OnPlayerInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            string keyName = ctx.control.name;
            SelectFood(keyName);
        }
    }

    private void SelectFood(string keyName)
    {
        int index = -1;
        Debug.Log($"Select Food {keyName}");

        if (keyName == "z")
        {
            index = 0;
        }
        else if (keyName == "x")
        {
            index = 1;
        }
        else if (keyName == "c")
        {
            index = 2;
        }

        if (index >= 0 && index < foodItems.Length)
        {
            ThrowFood(index);
        }
    }

    private void ThrowFood(int index)
    {
        if (foodItems != null && index < foodItems.Length && foodItems[index] != null)
        {
            GameObject food = Instantiate(foodItems[index], transform.position +Vector3.up, transform.rotation);

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            Rigidbody rb = food.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            }
        }
    }
}