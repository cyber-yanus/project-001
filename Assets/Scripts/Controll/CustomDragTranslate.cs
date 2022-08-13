using UnityEngine;
using Lean.Touch;
using CW.Common;


public class CustomDragTranslate : MonoBehaviour
{
    public LeanFingerFilter Use = new LeanFingerFilter(true);
    
    [SerializeField] private Camera camera;
    [SerializeField] private float sensitivity = 1.0f;
    [SerializeField] private float damping = -1.0f;
    [Space]
    [SerializeField] private float minPositionX;
    [SerializeField] private float maxPositionX;
    [Space]
    [SerializeField] [Range(0.0f, 1.0f)] private float inertia;
    [SerializeField] private Vector3 remainingTranslation;
    
    
    
    
    #if UNITY_EDITOR
    		protected virtual void Reset()
    		{
    			Use.UpdateRequiredSelectable(gameObject);
    		}
    #endif
    
    		protected virtual void Awake()
    		{
    			Use.UpdateRequiredSelectable(gameObject);
    		}
    
    		protected virtual void Update()
    		{
    			// Store
    			var oldPosition = transform.localPosition;
    
    			// Get the fingers we want to use
    			var fingers = Use.UpdateAndGetFingers();
    
    			// Calculate the screenDelta value based on these fingers
    			var screenDelta = LeanGesture.GetScreenDelta(fingers);
    
    			if (screenDelta != Vector2.zero)
    			{
	                Translate(screenDelta);
                }
    
    			// Increment
    			remainingTranslation += transform.localPosition - oldPosition;
    
    			// Get t value
    			var factor = CwHelper.DampenFactor(damping, Time.deltaTime);
    
    			// Dampen remainingDelta
    			var newRemainingTranslation = Vector3.Lerp(remainingTranslation, Vector3.zero, factor);
    
    			// Shift this transform by the change in delta
    			transform.localPosition = oldPosition + remainingTranslation - newRemainingTranslation;
    
    			if (fingers.Count == 0 && inertia > 0.0f && damping > 0.0f)
    			{
    				newRemainingTranslation = Vector3.Lerp(newRemainingTranslation, remainingTranslation, inertia);
    			}
    
    			// Update remainingDelta with the dampened value
    			remainingTranslation = newRemainingTranslation;
    		}
            
            private void Translate(Vector2 screenDelta)
            {
	            // Make sure the camera exists
	            var camera = CwHelper.GetCamera(this.camera, gameObject);

	            if (camera != null)
	            {
		            Vector3 transformPosition = transform.position;
				
		            // Screen position of the transform
		            var screenPoint = camera.WorldToScreenPoint(transformPosition);

		            // Add the deltaPosition
		            screenPoint += (Vector3)screenDelta * sensitivity;

		            float newPositionX = camera.ScreenToWorldPoint(screenPoint).x;
		            float newPositionY = transformPosition.y;
		            float newPositionZ = transformPosition.z;

		            if (newPositionX > minPositionX && newPositionX < maxPositionX)
		            {
			            transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);    
		            }
		            
	            }
	            else
	            {
		            Debug.LogError("Failed to find camera. Either tag your camera as MainCamera, or set one in this component.", this);
	            }
            }
}
