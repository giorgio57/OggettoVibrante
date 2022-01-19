using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDisappear : MonoBehaviour
{
    public ViewPoint viewpoint;

    public float changeVariable;
    
    public void DisappearUpdateUp()
    {
        viewpoint.VisibilityAngle += changeVariable * Time.deltaTime;
        
    }

    public void DisappearUpdateDown()
    {
        viewpoint.VisibilityAngle -= changeVariable * Time.deltaTime;

    }
}
