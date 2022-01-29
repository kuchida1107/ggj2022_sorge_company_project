using UnityEngine;
using UnityEngine.UI;

namespace SorgeProject.View
{
    public class InfomationView : MonoBehaviour
    {
        [SerializeField] Text titleStr;
        [SerializeField] Text powerValue;
        [SerializeField] Text moralValue;
        [SerializeField] Text trustValue;
        [SerializeField] Text profitValue;
        [SerializeField] Text costValue;

        public void SetData(Object.InfomationBehaviour behaviour)
        {
            titleStr.text = behaviour.Title;
            powerValue.text = behaviour.Power.ToString();
            moralValue.text = behaviour.Moral.ToString();
            trustValue.text = behaviour.Trust.ToString();
            profitValue.text = behaviour.SellCost.ToString();
            costValue.text = behaviour.Cost.ToString();
        }
    }
}