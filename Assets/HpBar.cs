using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image _background;
    public Image _mask;
    public TextMeshProUGUI _hpStringState;

    public MyCharacterControllerScript _characterControllerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHpBarStatus();
    }

    void UpdateHpBarStatus()
    {
        float currentHp = _characterControllerScript.CurrentHp;
        float maxHp = _characterControllerScript.MaxHp;

        _hpStringState.text = string.Format("{0} / {1}", _characterControllerScript.CurrentHp, _characterControllerScript.MaxHp);

        // mask�� height�� ������ �����Ŷ� �׳� �����´�.
        float height = _mask.GetComponent<RectTransform>().sizeDelta.y;

        // background�� width���� x�ε� �̰� �ִ� ũ���̴ϱ� fullWidth�� ����Ѵ�.
        float fullWidth = _background.GetComponent<RectTransform>().sizeDelta.x;

        // hp / maxHp => 0~1������ ���� ���Եǰ� 0.5 * fullWidth�ϰ� �Ǹ� => �������� ����ŷ ����� �ȴ�.
        _mask.GetComponent<RectTransform>().sizeDelta = new Vector2(_characterControllerScript.CurrentHp / _characterControllerScript.MaxHp * fullWidth, height);
    }
}