using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswardManager : MonoBehaviour
{
    public static PasswardManager Instance;
    public GameObject GameUI;
    public string InputPassward;
    public string CorrectAnswer;
    public GameObject Door;
    public Text TextShow;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HandlePlayerInput(int x)
    {
        InputPassward += x.ToString();
        if(CorrectAnswer == InputPassward)
        {
            Door.GetComponent<Animator>().SetTrigger("OPEN");
            HandleEndMiniGame();
        }
    }

    public void HandleStartMiniGame()
    {
        GameUI.SetActive(true);
        InputPassward = "";
        Cursor.visible = true;
    }

    public void HandleEndMiniGame()
    {
        GameUI.SetActive(false);
        Cursor.visible = false;
        PlayerControl.Instance.IsInteractingWithUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        TextShow.text = InputPassward;
    }
}
