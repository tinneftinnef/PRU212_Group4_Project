using UnityEngine;

public class AnimationScaleBehaviour : MonoBehaviour
{
    public AnimationCurve scaleCurve;
    public float duration = 1f;
    public bool playOnStart = true;

    private UnityEngine.Transform objectToScale;
    private float currentTime = 0f;
    private Vector3 initialScale;

    private void Start()
    {
        objectToScale = GetComponent<UnityEngine.Transform>();
        initialScale = objectToScale.localScale;

        if (playOnStart)
        {
            PlayAnimation();
        }
    }

    private void Update()
    {
        if (currentTime <= duration)
        {
            float t = currentTime / duration;
            float scaleValue = scaleCurve.Evaluate(t);

            objectToScale.localScale = initialScale * scaleValue;

            currentTime += Time.deltaTime;
        }
    }

    public void PlayAnimation()
    {
        currentTime = 0f;
    }
}