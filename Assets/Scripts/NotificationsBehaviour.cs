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
    void Start()
    {
        eggController = FindAnyObjectByType<EggController>();
        animatorController = GetComponent<Animator>();
        imageNotification = GetComponent<Image>();
        initialColor = imageNotification.color;
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
         if(eggController.points == 5)
        {
            AudioManager.Instance.PlaySFX(goodNotify);
            animatorController.SetTrigger("Notify");
            message.text = "nice!";
            notified = true;
        }
        else if(eggController.points == 10)
        {
            AudioManager.Instance.PlaySFX(veryGoodNotify);
            animatorController.SetTrigger("Notify");
            message.text = "SO GOOD!";
            imageNotification.color = Color.green;
            notified = true;
        }
        if(eggController.points == -5)
        {
            AudioManager.Instance.PlaySFX(wrongNotify);
            animatorController.SetTrigger("Notify");
            imageNotification.color = Color.red;
            message.text = "are u ok?";
            notified = true;
        }
    }

    public void Notified()
    {
        notified = false;
        imageNotification.color = initialColor;
    }

}
