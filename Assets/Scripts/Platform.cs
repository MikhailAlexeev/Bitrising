using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public int curPoint = 0;

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
            curPoint++;

            if (curPoint >= points.Length)
            {
                curPoint = 0;
            }

            SetFromTo();
        }
    }

    private void SetFromTo()
    {
        from = points[curPoint];
        to = curPoint + 1 >= points.Length ? points[0] : points[curPoint + 1];
    }

    private bool ReachedFinish()
    {
        return Vector2.Distance(transform.position, to.position) < DIST_EPSILON;
    }
}