using UnityEngine;

namespace SorgeProject.Object
{
    public class EnumerabledLocator : MonoBehaviour
    {
        [SerializeField] RectTransform[] locators;
        public Vector2 GetPosition(int index)
        {
            return locators[index].anchoredPosition;
        }
    } 
}
