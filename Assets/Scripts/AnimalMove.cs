using UnityEngine;

public class AnimalMove : MonoBehaviour
{
[SerializeField] private float animalSpeed;
private float outOfScene;

private void Update()
{
    MoveForward();
    DeleteOutOfScene();
}

private void MoveForward()
{
    transform.Translate(Vector3.forward * (animalSpeed * Time.deltaTime));
}

private void DeleteOutOfScene()
{
    if (transform.position.z > outOfScene || transform.position.z < -outOfScene || transform.position.x > outOfScene || transform.position.x < -outOfScene)
    {
     Destroy(gameObject);
    }
}
}