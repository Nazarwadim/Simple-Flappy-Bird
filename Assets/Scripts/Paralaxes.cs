using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxes : MonoBehaviour
{
    public void ResetToStartPosition() {
        foreach(Transform t in transform) {
            if(t.TryGetComponent(out ParallaxController component)) {
                component.ResetToStartPosition();
            }
        }
    }
}
