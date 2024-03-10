# Unity: Eye Tracking with Meta Quest Pro

This Unity project demonstrates the basic setup for eye tracking using a Meta Quest Pro headset. 
The project utilizes a GameObject named `CenterEyeAnchor` located under `OVRCameraRig/TrackingSpace`, which represents the eye. 
The `OVREyeGaze` script attached to this GameObject rotates and moves it in the space. 
Among other things, the `Confidence Threshold` can be set here, which is necessary to determine whether the detected change in the eyes is applied to the object.

The `CameraRay` script utilizes the position and rotation of the `CenterEyeAnchor` to create a raycast. 
For debugging purposes, a visible line can be drawn by setting the `drawDebugLine` variable.
Objects of the `Highlighter` class have their `IsHovered` variable set to true when looked at, allowing them to apply a different material accordingly. 
This is where other behaviors can be implemented, or interactions with other classes can be added in the `CameraRay` script when looking at these objects.

## Usage

1. Ensure you have the Meta Quest Pro headset connected and properly set up.
2. Open the Unity project.
3. Navigate to the `OVRCameraRig` in the hierarchy and locate the `CenterEyeAnchor` GameObject.
4. Adjust the `Confidence Threshold` parameter in the `OVREyeGaze` script attached to the `CenterEyeAnchor` GameObject if necessary.
5. Run the Unity scene.
6. Look at the objects in the scene to trigger highlighting and see the eye tracking in action.
7. Use this project to use eye tracking with Unity and Meta Quest Pro in your own project.

## Additional Notes

- For more complex interactions, consider extending the functionality of the `Highlighter` class or integrating interactions with other scripts when objects are being looked at.
- Ensure proper calibration and positioning of the Meta Quest Pro headset for accurate eye tracking results.

## Further Information
- [Eye Tracking for Movement SDK for Unity](https://developer.oculus.com/documentation/unity/move-eye-tracking/)
- [Movement SDK for Unity - Overview and Setup](https://developer.oculus.com/documentation/unity/move-overview/)
