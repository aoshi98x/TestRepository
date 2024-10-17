using UnityEngine;

public class RandomActivator : MonoBehaviour
{
    EggController eggController;
    public GameObject[] effects;
    public AudioClip correctSound, incorrectSound;
    [Header ("Cooldown variables")]
    public float resetCool;
    public float cooldown, temporalCount;

    [Header ("Time to see Eggs variables")]
    public int time;
    public int minRange; 
    public int maxRange;

    [Header ("Is Egg on?")]
    [SerializeField] bool eggOn;
    private void Start() {
        
        cooldown = resetCool;
        eggController = transform.parent.GetComponent<EggController>();
        
        
    }
    void Update()
    {
        switch (eggOn)
        {
            case true:
                cooldown -= Time.deltaTime;
                if(cooldown <= 0)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                    cooldown = resetCool;
                    eggOn = false;
                }
            break;

            case false:
                temporalCount += Time.deltaTime;
                time = (int)temporalCount;
                if(time >= Random.Range(minRange,maxRange))
                {
                    effects[0].SetActive(false); 
                    effects[1].SetActive(false); 
                    transform.GetChild(Random.Range(0,2)).gameObject.SetActive(true);
                    time = 0;
                    temporalCount =0;
                    eggOn = true;
                }

            break;
        }
    }
    private void OnMouseDown() {
        if(eggOn && transform.GetChild(0).gameObject.activeInHierarchy)
        {
            eggOn=false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            eggController.points++;
            effects[0].SetActive(true);
            AudioManager.Instance.PlaySFX(correctSound); 
        }
        else if(eggOn && transform.GetChild(1).gameObject.activeInHierarchy)
        {
            eggOn=false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            eggController.points--;
            effects[1].SetActive(true); 
            AudioManager.Instance.PlaySFX(incorrectSound); 
        }
    }
}
