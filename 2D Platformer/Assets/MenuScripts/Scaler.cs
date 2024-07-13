using System.Collections;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private float _minScale = 1.5f;
    private float _maxScale = 3.0f;
    private float _step = 0.5f;

    private bool _Activated = false;

    public void Scale()
    {
        if (_Activated == false)
        {
            StartCoroutine(nameof(ChangeButtonSize));
        }
    }

    private IEnumerator ChangeButtonSize()
    {
        _Activated = true;

        float scaleX = transform.localScale.x;
        float scaleY = transform.localScale.y;
        WaitForSeconds wait = new WaitForSeconds(0.02f);

        while(transform.localScale.x != _minScale && transform.localScale.y != _minScale)
        {
            scaleX -= _step;
            scaleY -= _step;

            transform.localScale = new Vector2(scaleX, scaleY);

            yield return wait;
        }

        while (transform.localScale.x != _maxScale && transform.localScale.y != _maxScale)
        {
            scaleX += _step;
            scaleY += _step;

            transform.localScale = new Vector2(scaleX, scaleY);

            yield return wait;
        }

        _Activated = false;
    }
}