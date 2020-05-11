using DG.Tweening;
using UnityEngine;

public class AutoHideBehaviour : MonoBehaviour
{
    [SerializeField] private bool autoHide;
    [SerializeField] private float hideAfterSec;
    [SerializeField] private float hideDurationSec;
    [SerializeField] private Ease hideEaseType;
    private float _passedSec;
    private Transform _objectToHide;

    private void Start()
    {
        _passedSec = 0.0f;
        if (gameObject.transform.childCount>0)
        {
            _objectToHide = gameObject.transform.GetChild(0);
        }
        else
        {
            _objectToHide = gameObject.transform;
        }
    }

    void Update()
    {
        AutoHide();
    }

    private void AutoHide()
    {
        if (autoHide)
        {
            _passedSec += Time.deltaTime;
            if (_passedSec >= hideAfterSec)
            {
                _passedSec = 0.0f;
                _objectToHide.DOScale(0, hideDurationSec).SetEase(hideEaseType);
                if (_objectToHide.localScale.magnitude <= 0.001f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}