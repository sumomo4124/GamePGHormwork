using UnityEngine;
using UnityEngine.UI;

public class BoostGaugeController : MonoBehaviour
{
	// Robot および RobotController が必要なので、準備をする
	public GameObject playerObject;

	Slider slider = null;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        // SliderComponentを取得する
		slider = GetComponent<Slider>();

        if (slider != null)
        {
            // BootTimeを取得して、maxValueに反映する
            RobotController controller = playerObject.GetComponent<RobotController>();

            if (controller != null)
            {
				slider.minValue = 0.0f;
				slider.maxValue = controller.boostTime;//maxValueにRobotControllerのboostTime変数を代入する
                slider.value = slider.maxValue;
			}
		}
		else
		{
			Debug.Log("Slider is null");
		}
    }

    // Update is called once per frame
    void Update()
    {
		// boostTimerの値でvalueを更新する
		// BootTimeを取得して、maxValueに反映する
		RobotController controller = playerObject.GetComponent<RobotController>();

		if (controller != null)
		{
			//ゲージをカウントダウン形式で減らしていっている
			slider.value = controller.boostTime - controller.boostTimer;
		}
	}
}
