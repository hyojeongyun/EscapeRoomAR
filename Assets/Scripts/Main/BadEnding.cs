using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BadEnding : MonoBehaviour
{
    public Sprite[] personSprites;
    public Image[] content;
    public Image personImage;
    public Image personColor;
    public Text nameText;
    public Text dialogText;
    public AudioSource[] audioSource;
    public GameObject infopopup;
    public GameObject Button;
    public GameObject back1;
    public GameObject back2;
    public GameObject back3;
    public GameObject back4;
    public GameObject back5;
    public GameObject back6;

    public Image fade;
    public float fades = 1.0f;
    public float time = 0;
    public bool last = false;
    private Color _targetColor;
    private List<Dialog> _dialogs;
    private int _index;

    private void Start()
    {
        for(int i=0; i<3; i++)
        {
            content[i].enabled = false;
        }

        _index = -1;
    }

    private void Update()
    {
        personColor.color = Color.Lerp(personColor.color, _targetColor, 0.05f);

        if (last)
        {
            content[2].enabled = true;
            time += Time.deltaTime;
            if (fades > 0.0f && time >= 0.1f)
            {
                fades -= 0.1f;
                fade.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, fades);
                time = 0;
            }
            else if (fades <= 0.0f)
            {
                time = 0;
            }
        }
    }

    public void SetDialog(Dialog dialog)
    {
 
        personImage.sprite = personSprites[(int)dialog.name];

        if ((int)dialog.name == 1)
        {
            RectTransform rect = (RectTransform)personImage.transform;
            rect.anchoredPosition = new Vector2(-460, 400);
            rect.sizeDelta = new Vector2(600, 500);
        }
        else if ((int)dialog.name == 0)
        {
            RectTransform rect = (RectTransform)personImage.transform;
            rect.anchoredPosition = new Vector2(20, 400);
            rect.sizeDelta = new Vector2(450, 450);
        }
         _targetColor = dialog.Color;

        nameText.text = dialog.Name;
        dialogText.text = dialog.text;

        if (dialog.variables == null)
        {
            return;
        }

        foreach (var variable in dialog.variables)
        {
            VariableBehaviour(variable);
        }
    }

    public void OnPopupClick()
    {
        Change();
        _index++;
        SetDialog(_dialogs[_index]);
    }

    public void Change()
    {
        var _d = new List<Dialog>();
        _d.Add(new Dialog("Main", "Ʋ�� ����."));
        _d.Add(new Dialog("Main", "�������� �ܼ��� ��� �����غ��� ������ �����Ⱑ �и���."));
        _d.Add(new Dialog("Main", "���� �����鵵 �״�� �ְ�\n ��Ʈ�ϰ� ��ø�� ���� ��ȹ�� �������� ���� �������ݾ�?"));
        _d.Add(new Dialog("Main", "�̰� �Ź� 1���� �����̰ŴϿ� \n���� TV ���������� ���� �� �ְھ�!"));
        _d.Add(new Dialog("Main", "��ī�ο� ������ �������� ���� ������ �˾Ƴ� ����! \n�̰� ���� ���� Ư���� �ǰڱ���."));
        _d.Add(new Dialog("Main", "����, ���� ������ �����⸸ �ϸ� �Ǵµ�."));
        _d.Add(new Dialog("Main", "�� �̷��� �� ���Ⱑ ������?"));
        _d.Add(new Dialog("Main", "�������� �濡 ���Ⱑ �ڿ��� �ž�? \nŸ�� ������ ���� �ʾҴµ�.", "PIC_APPEAR_1"));
        _d.Add(new Dialog("Main", "�ݷ�, �ݷ�.", "AUDIO_1"));//��ħ�Ҹ�
        _d.Add(new Dialog("Main", "����, �� ������."));
        _d.Add(new Dialog("Main", "����ּ���...!", "AUDIO_2"));//�������¼Ҹ�
        _d.Add(new Dialog("Main", "���� �����? ����, ��� �־��...!"));
        _d.Add(new Dialog("Main", "����ּ���...!", "PIC_APPEAR_2"));
        _d.Add(new Dialog("Colleague", "���� ��� �־���."));
        _d.Add(new Dialog("Main", "�� ����...! �� �� ���Ⱑ �ʹ� �����. \n����, �������� ����."));
        _d.Add(new Dialog("Colleague", "�׷�. ���� ���� ������ �ٰ�. �ϴ� ��ø� ���� �־�. \n���� �ߵ��Ǹ� �� �Ǵϱ� ���Ⱑ �� ���� ������ ���� ������."));
        _d.Add(new Dialog("Main", "�װ� ���� �Ҹ���! �� ����!"));
        _d.Add(new Dialog("Colleague", "���� CCTV ���� ������ ���� �� ���������ؼ� ����? \n�׷��� ������ ����Ʈ�� �������� �Ű�."));
        _d.Add(new Dialog("Colleague", "������ �ٹ̱� ���� ���̶�� �Ҹ���."));
        _d.Add(new Dialog("Colleague", "USB�� ���� ���� �ϸ��͸� ��ų �������� �װ� ��û�ؼ� �����̾�."));
        _d.Add(new Dialog("Main", "(�̰� �� ���� �Ҹ���.)"));
        _d.Add(new Dialog("Main", "(���� �� ���ϱ� �ʹ� ��������.)"));
        _d.Add(new Dialog("Main", "(������ ���� �� ����.)"));
        _d.Add(new Dialog("Colleague", "���� ��簡 �ö󰡱� �� �ž�. \n�� ������� 1���̶����, Ư���̶������ �ƴϰ�����."));
        _d.Add(new Dialog("Colleague", "�׳� ��� ���� �� ���ڰ� ������ ���� �����ϴٰ� \n�Ǽ��� ���� �� ����ߴٴ� ����� �ž�."));
        _d.Add(new Dialog("Colleague", "��, ���Ⱑ �� ����. ���� �����߰ھ�."));
        _d.Add(new Dialog("Colleague", "�� ��. ���Ÿ� ������༭ ������."));
        _d.Add(new Dialog("Main", "", "DIALOG_END"));
        _dialogs = _d;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Title");
    }

    public void VariableBehaviour(string variable)
    {
        switch (variable)
        {
            case "PIC_APPEAR_1":
                content[0].enabled = true;
                break;
            case "PIC_APPEAR_2":
                content[0].enabled = false;
                content[1].enabled = true;
                break;
            case "DIALOG_END":
                content[1].enabled = false;
                back1.SetActive(false);
                back2.SetActive(false);
                back3.SetActive(false);
                back4.SetActive(false);
                back5.SetActive(false);
                back6.SetActive(false);

                last = true;
                Button.SetActive(true);
                break;
            case "AUDIO_1":
                audioSource[0].Play();
                break;
            case "AUDIO_2":
                audioSource[1].Play();
                break;
            default:
                break;
        }
    }
}