using UnityEngine;
using UnityEngine.UI;

public class UIConditions : MonoBehaviour
{
    public Condition health;
    public Condition hunger;
    public Condition stamina;
    //public Condition mana;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }
}
