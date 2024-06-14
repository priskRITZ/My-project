using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOrFunc3 : MonoBehaviour
{
    public ActionOrFunc2 _actionOrFunc2;
    
    
    void Func1()
    {
        Debug.Log("Func1");
    }
    
    void Func2()
    {
        Debug.Log("Func2");
    }
    
    void Func3()
    {
        Debug.Log("Func3");
    }
    
    void Func4()
    {
        Debug.Log("Func4");
    }
    
    void Func5()
    {
        Debug.Log("Func5");
    }

    
    // Start is called before the first frame update
    void Start()
    {
        _actionOrFunc2 = GetComponent<ActionOrFunc2>();
    }
    
    void Update()
    {
        _actionOrFunc2.RegisitAction(null);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            _actionOrFunc2.RegisitAction(Func1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _actionOrFunc2.RegisitAction(Func2);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _actionOrFunc2.RegisitAction(Func3);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _actionOrFunc2.RegisitAction(Func4);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _actionOrFunc2.RegisitAction(Func5);
        }
    }
}