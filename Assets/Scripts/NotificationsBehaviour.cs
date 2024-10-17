using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationsBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI message;
    Image imageNotification;
    Color initialColor;
    public AudioClip goodNotify, veryGoodNotify, wrongNotify;
    EggController eggController;
    Animator animatorController;
    bool notified;
    int previousPoints, pointsDifference;  // Variable para almacenar los puntos anteriores

    void Start()
    {
        eggController = FindAnyObjectByType<EggController>();
        animatorController = GetComponent<Animator>();
        imageNotification = GetComponent<Image>();
        initialColor = imageNotification.color;
        previousPoints = eggController.points;  // Inicializa con los puntos actuales
    }

    void Update()
    {
        if(!notified)
        {
            Notify();
        }
    }

    void Notify()
    {
        pointsDifference = eggController.points - previousPoints;  // Diferencia de puntos
        Debug.Log(pointsDifference);
        Debug.Log(previousPoints);
        if(pointsDifference >= 5)
        {
            if (pointsDifference < 10)  // Si ha ganado entre 5 y 9 puntos
            {
                AudioManager.Instance.PlaySFX(goodNotify);
                animatorController.SetTrigger("Notify");
                message.text = "nice!";
            }
            else if (pointsDifference >= 10)  // Si ha ganado 10 o más puntos
            {
                AudioManager.Instance.PlaySFX(veryGoodNotify);
                animatorController.SetTrigger("Notify");
                message.text = "SO GOOD!";
                imageNotification.color = Color.green;
                previousPoints = eggController.points;  // Actualiza los puntos anteriores
            }
            notified = true;
        }
        else if(pointsDifference <= -5)  // Si ha perdido 5 o más puntos
        {
            AudioManager.Instance.PlaySFX(wrongNotify);
            animatorController.SetTrigger("Notify");
            imageNotification.color = Color.red;
            message.text = "are u ok?";
            notified = true;
            previousPoints = eggController.points;  // Actualiza los puntos anteriores
        }

    }

    public void Notified()
    {
        notified = false;
        imageNotification.color = initialColor;
    }
}
