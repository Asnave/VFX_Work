using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    
    public float cooldown1 = 5f;
    bool isCoolDown = false;
    public KeyCode ability1;

    Vector3 position;
    public Canvas ability1Canvas;
    public Image skillShot;
    public Transform player;

    public Image abilityImage1;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 1;
        skillShot.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x,hit.point.y, hit.point.z);
        }

        // Canvas Inputs 

         
       Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
       ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);
    }

     void Ability1()
    {
        if (Input.GetKey(ability1) && isCoolDown == false)
        {
            isCoolDown = true;
            abilityImage1.fillAmount = 1;
            skillShot.GetComponent<Image>().enabled = true;
          
            Debug.Log("Cooldown");
        }

     

        if(isCoolDown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            skillShot.GetComponent<Image>().enabled = false;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 1;
                skillShot.GetComponent<Image>().enabled = true;
                isCoolDown = false;
            }
        }
      
    }
}
