using DG.Tweening;
using UnityEngine;

public class AutoHideBehaviour : MonoBehaviour
{
    [SerializeField] private bool autoHide;
    [SerializeField] private float hideAfterSec;
    [SerializeField] private float hideDurationSec;
    [SerializeField] private Ease hideEaseType;
    private float _passedSec;
    private Transform _childTransform;

    private void Start()
    {
        _passedSec = 0.0f;
        _childTransform = gameObject.transform.GetChild(0);
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
                _childTransform.DOScale(0, hideDurationSec).SetEase(hideEaseType);
                if (_childTransform.localScale.magnitude <= 0.001f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}