using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 델리게이트 제작
public delegate void CalculationCompleetedEventHander(int result);

public class TestClass
{
    public void TestClassFunction(int result)
    {
        Debug.Log($"result : {result}");
    }
}

public class Calculator
{
    // 델리게이트 선언
    public CalculationCompleetedEventHander CalculationCompleted;
    
    // Add 함수 제작
    public void Add(int a, int b)
    {
        int result = a + b;
        
        // ?는 nullcheck 대신 사용 하고 Invoke는 function(); 함수호출과 비슷하다.
        CalculationCompleted?.Invoke(result);
    }

    // Subtract 함수 제작
    public void Subtract(int a, int b)
    {
        int result = a - b;
        CalculationCompleted?.Invoke(result);
    }

}

public class delegateExample : MonoBehaviour
{
    private Calculator _calculator;
    private int sumResult = 0;
    
    public TestClass testClass;
    
    void Start()
    {
        _calculator = new Calculator();
        testClass = new TestClass();
        
        // delegateExample의 클래스의 CalculationCompletedEventHandler 함수를 등록한다.
        _calculator.CalculationCompleted += CalculationCompletedEventHandler;
        _calculator.CalculationCompleted += testClass.TestClassFunction;
    }

    void CalculationCompletedEventHandler(int result)
    {
        Debug.Log($"result : {result}");
        
        // sumResult의 변수 값을 결과값으로 변경한다.
        sumResult = result;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // _calculator의 Add 함수를 호출한다.
            _calculator?.Add(sumResult, 1);
        }
        
        // 델리게이트에서 빼기
        // CalculationCompleted 함수에 무언가 담겨있다면
        if (sumResult >= 5 && _calculator is { CalculationCompleted: not null })
        {
            _calculator.CalculationCompleted -= CalculationCompletedEventHandler;
        }
    }
}