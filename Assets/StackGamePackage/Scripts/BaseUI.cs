using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager_Stack uiManager;

    public virtual void Init(UIManager_Stack uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}