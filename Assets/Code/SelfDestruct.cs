using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float selfDestructDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCountdown());
    }

    private IEnumerator startCountdown()
    {
        yield return new WaitForSeconds(selfDestructDelay);

        GameObject.Destroy(gameObject);
    }
}
