using System.Collections;
using UnityEngine;

public class test1 : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public Rigidbody rigidbody;

    public int score;
    public float BaseMoveSpeed;

    private Coroutine speedUpCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        moveSpeed = BaseMoveSpeed; // Initialize moveSpeed to BaseMoveSpeed
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetButton("Jump"))
        {
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    public void SpeedUp(float multiplier, float duration)
    {
        if (speedUpCoroutine != null)
        {
            StopCoroutine(speedUpCoroutine);
        }
        speedUpCoroutine = StartCoroutine(SpeedUpCoroutine(multiplier, duration));
    }

    private IEnumerator SpeedUpCoroutine(float multiplier, float duration)
    {
        moveSpeed *= multiplier;
        yield return new WaitForSeconds(duration);
        moveSpeed = BaseMoveSpeed;
    }
}
