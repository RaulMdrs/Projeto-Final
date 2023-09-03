using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public ControlSelectionEnum ControlSelection;

    void Start()
    {
        ControlSelection = ControlSelectionEnum.Keyboard;
    }

    // Update is called once per frame
    void Update()
    {       
    }
}
