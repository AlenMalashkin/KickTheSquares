using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Target : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform rect;
    public RectTransform Rect => rect;

    private Lifebar _lifebar;
    private Score _score;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnTargetClick();
    }

    public void Init(Score score, Lifebar lifebar)
    {
        _lifebar = lifebar;
        _score = score;
    }

    private void OnTargetClick()
    {
        _score.AddScore();
        Destroy(gameObject);
    }

    private void OnTargetScaleEnd()
    {
        _animator.Play("ShrinkTarget");   
    }

    private void OnTargetShrinkEnd()
    {
        _lifebar.TakeDamage();
        Destroy(gameObject);
    }
}
