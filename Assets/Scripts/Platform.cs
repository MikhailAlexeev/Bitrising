using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public int currentPoint = 0;

    private Transform from;
    private Transform to;

    private const float DIST_EPSILON = 0.001f;


    private void Awake()
    {
        SetFromTo();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, to.position, Time.deltaTime * speed);

        if (ReachedFinish())
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }

            SetFromTo();
        }
    }

    private void SetFromTo()
    {
        from = points[currentPoint];
        to = currentPoint + 1 >= points.Length ? points[0] : points[currentPoint + 1];
    }

    private bool ReachedFinish()
    {
        return Vector2.Distance(transform.position, to.position) < DIST_EPSILON;
    }
}