using System.Collections;
using UnityEngine;

public class FoodLifeCycle : MonoBehaviour
{
[SerializeField] private float lifeDuration;

private void Start()
{
    StartCoroutine(DeleteAfterLifeDuration());
}

private IEnumerator DeleteAfterLifeDuration()
{
    yield return new WaitForSeconds(lifeDuration);
    Destroy(gameObject);
}
}