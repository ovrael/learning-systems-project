using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int dayNightOffsetPosition = 3000;
    [SerializeField]
    private int heightAboveGround = 1500;
    [SerializeField]
    private int dayLightTime = 22 - 6; //16 hours of day light

    private float timeCounter = 0f;
    private readonly float timeCounterOffset = 140f;

    [SerializeField]
    [Range(1f, 5f)]
    private float speedFix = 3f;

    private Transform transform;
    private GameTime gameTime;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        gameTime = GetComponent<GameTime>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        timeCounter = timeCounterOffset;
        transform.position = new Vector3(0f, heightAboveGround, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        timeCounter += (Time.deltaTime * gameTime.SimulationSpeed) / speedFix;
        transform.position = Quaternion.AngleAxis(timeCounter, Vector3.back) * new Vector3(heightAboveGround, 0f);

        if (timeCounter >= timeCounterOffset + 360)
        {
            timeCounter = timeCounterOffset;
        }
    }
}
