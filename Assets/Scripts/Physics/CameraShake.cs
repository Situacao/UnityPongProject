using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public IEnumerator CameraShakeMethod(float _duration, float _amount)
    {
        //yield return new WaitForSeconds(3f);
        float startTime = Time.time;
        Vector3 startPos = transform.position;

        while (Time.time < startTime + _duration)
        {
            float newPosX = Random.Range(-1f, 1f) * _amount;
            float newPosY = Random.Range(-1f, 1f) * _amount;
            Vector3 newPos = new Vector3(newPosX, newPosY);
            Vector3 finalPos = startPos + newPos * Time.deltaTime;

            transform.position = finalPos;

            // Este return vai fazer com que o while passe por vários frames
            yield return null;
        }
        transform.position = startPos;

    }
}
