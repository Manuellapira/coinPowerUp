using UnityEngine;

public class Collectables : MonoBehaviour
{
    public bool isCoins, isSpeedUp;
    public float speedUpMultiplier = 1.2f;
    public float speedUpDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            test1 playerScript = other.GetComponent<test1>();
            if (isCoins)
            {
                playerScript.score++;
                Destroy(gameObject);
            }
            if (isSpeedUp)
            {
                playerScript.SpeedUp(speedUpMultiplier, speedUpDuration);
                Destroy(gameObject);
            }
        }
    }
}
