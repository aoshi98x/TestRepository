using TMPro;
using UnityEngine;

public class CanvasUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointText;
    PhysicsController controller;
    void Start()
    {
        controller = GameObject.FindAnyObjectByType<PhysicsController>();
    }

    
    void Update()
    {
        if(controller != null)
        {
            pointText.text = "Points: " + controller.points;
        }
    }
}
