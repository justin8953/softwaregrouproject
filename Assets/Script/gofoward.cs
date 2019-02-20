using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gofoward : MonoBehaviour
{
    private Renderer Object_render;
    public Button btn;
    bool FD_isValid, BD_isValid, LT_isValid, RT_isValid,Jmp_isValid;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        FD_isValid = BD_isValid = LT_isValid = RT_isValid = Jmp_isValid = false;
        btn = GameObject.Find("Button").GetComponent<Button>();
        Object_render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        btn.onClick.AddListener(FDOnClick);
        if(FD_isValid)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            FD_isValid = false;
        }

    }
    void FDOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        FD_isValid = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
