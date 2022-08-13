using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] MyVector2D myFirstVector = new MyVector2D(x: -3, y: 4);
    [SerializeField] MyVector2D mySecondVector = new MyVector2D(x: 3, y: 4);
    [Range(0, 1)][SerializeField] float scalar = 0;

    private void Update()
    {
        MyVector2D diff = (mySecondVector - myFirstVector) * scalar;
        MyVector2D final = myFirstVector + diff;

        #region Debug
        myFirstVector.Draw(Color.red);
        mySecondVector.Draw(Color.green);
        diff.Draw(Color.yellow);
        diff.Draw(myFirstVector, Color.yellow);
        final.Draw(Color.blue);
        #endregion
    }
}
