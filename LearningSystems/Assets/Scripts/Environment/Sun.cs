using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int dayNightOffsetPosition = 3000;
    [SerializeField]
    private int heightAboveGround = 1500;
    private readonly int heightOffset = 700;

    [SerializeField]
    private float timeCounter = 0f;
    private readonly int timeCounterOffset = 140;

    private readonly float speedFix = 4f;

    private Transform transform;
    [SerializeField]
    private GameObject moon;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        timeCounter = timeCounterOffset;
        //moon.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        timeCounter += Time.deltaTime / speedFix;
        transform.position = Quaternion.AngleAxis(timeCounter, Vector3.back) * new Vector3(heightAboveGround, 0f) + new Vector3(0, heightOffset, 0);

        //moon.SetActive(timeCounter > 320 || timeCounter < timeCounterOffset + 40);

        if (timeCounter >= timeCounterOffset + 360)
        {
            timeCounter = timeCounterOffset;
        }
    }
}
