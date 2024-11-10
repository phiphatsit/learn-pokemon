using UnityEngine;

public class BasePanel : MonoBehaviour
{
    public virtual void OpenPanel()
    {
        PlayerMovement.Instance.enabled = false;
    }

    public virtual void ClosePanel()
    {
        PlayerMovement.Instance.enabled = true;
    }
}
