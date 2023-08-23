using UnityEngine;
using UnityEngine.UI;

public class DistanceSlider : MonoBehaviour
{
    [SerializeField]
    Transform _player, _winPortal;
    [SerializeField]
    Slider _distanceSlider;


    private void Start()
    {
        float distance = _winPortal.transform.position.x - _player.position.x;
        _distanceSlider.maxValue = distance;
    }
    private void FixedUpdate()
    {
        DistanceControl();
    }


    public void DistanceControl()
    {
        float distance = _winPortal.transform.position.x - _player.position.x;
        _distanceSlider.value = _distanceSlider.maxValue - distance;
    }
}
