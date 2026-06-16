using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    [Header("Target Configuration")]
    public int pointValue = 5;
    public ParticleSystem explosionParticle;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),
                            ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && gameManager.isGameActive)
        {
            // Debug.Log("Mouse was clicked");
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos); // Ray from camera to mouse point
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);
            
            if (Physics.Raycast(ray, out RaycastHit hit)) // out meaning send the output to ...
            {
                if (hit.transform == transform)
                {
                    gameManager.UpdateScore(pointValue);
                    Instantiate(explosionParticle, transform.position,
                                explosionParticle.transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }
}
