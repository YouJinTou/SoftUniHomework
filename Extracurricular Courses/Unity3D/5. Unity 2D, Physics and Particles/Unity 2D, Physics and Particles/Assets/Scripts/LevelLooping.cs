using UnityEngine;

public class LevelLooping : MonoBehaviour
{
    private const float LoopSpeed = 0.03f;

    void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);

            if (child.rotation.z == 1f)
            {
                child.Translate(Vector2.right * LoopSpeed);
            }
            else
            {
                child.Translate(Vector2.left * LoopSpeed);
            }
        }
    }    
}
