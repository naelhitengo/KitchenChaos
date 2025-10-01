using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour {

    private const string OPEN_CLOSE = "OpenClose";

    [SerializeField] private ContainerCounter containerCounter;

    private Animator animator;

    public void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {

        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPpayerGrabbedObject;

    }

    private void ContainerCounter_OnPpayerGrabbedObject(object sender, System.EventArgs e) {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
