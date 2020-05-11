
using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{
public Transform player;
private bool _isplayerNotNull;


// Update is called once per frame
    private void Start()
    {
        _isplayerNotNull = player!=null;
    }

    void Update()
    {
        if (_isplayerNotNull)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, 0.0f);
        }
    }
}
