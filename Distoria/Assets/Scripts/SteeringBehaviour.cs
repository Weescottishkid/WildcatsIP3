using UnityEngine;
using System.Collections;

public class SteeringBehaviour : MonoBehaviour
{
	public float maxSpeed = 40.0f;
	public float maxSteering = 2.0f;
	
	protected Rigidbody rigidBody;

	// Use this for initialization
	private void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	// FixedUpdate is called once per physics frame
	private void FixedUpdate()
	{
		CooperativeArbitration();
	}

	// Update is called once per game frame
	private void Update()
	{
		SetDirection();
	}
	
	#region Helper functions
	/// <summary>
	/// Returns the mouse position in 2d space
	/// </summary>
	/// <returns>the mouse position in 2d space</returns>
	protected Vector2 GetMousePosition()
	{
		Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return new Vector3(temp.x, temp.y, temp.z);
	}

	/// <summary>
	/// Sets the direction of the triangle to the direction it is moving in to give the illusion it is turning. Trying taking out the function
	/// call in Update() to see what happens
	/// </summary>
	protected void SetDirection()
	{
		// Don't set the direction if no direction
		if (rigidBody.velocity.sqrMagnitude > 0.0f)
		{
			transform.up = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
		}
	}


	protected Vector3 LimitSteering(Vector3 steeringVelocity)
	{
		// This limits the steering velocity to maxSteering. sqrMagnitude is used rather than magnitude as in magnitude a square root must be computed which is a slow operation.
		// By using sqrMagnitude and comparing with maxSteering squared we can around using the expensive square root operation.
		if (steeringVelocity.sqrMagnitude > maxSteering * maxSteering)
		{
			steeringVelocity.Normalize();
			steeringVelocity *= maxSteering;
		}
		return steeringVelocity;
	}

	protected Vector3 LimitVelocity(Vector3 velocity)
	{
		// This limits the velocity to max speed. sqrMagnitude is used rather than magnitude as in magnitude a square root must be computed which is a slow operation.
		// By using sqrMagnitude and comparing with maxSpeed squared we can around using the expensive square root operation.
		if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
		{
			velocity.Normalize();
			velocity *= maxSpeed;
		}
		return velocity;
	}
	#endregion

	#region Behaviours: Feel free to add more to this section
	protected Vector3 Seek(Vector3 currentVelocity, Vector3 targetPosition)
	{
		// These 3 lines are equivalent to: desiredVelocity = Normalise(targetPosition - currentPoisition) * MaxSpeed
		Vector3 desiredVelocity = targetPosition - new Vector3(transform.position.x, transform.position.y, transform.position.z);
		desiredVelocity.Normalize();
		desiredVelocity *= maxSpeed;
		
		// Calculate steering velocity
		Vector3 steeringVelocity = desiredVelocity - currentVelocity;
		steeringVelocity = LimitSteering(steeringVelocity);

		// Useful for showing directions in scene view to visualise what the AI is doing
		Debug.DrawRay(transform.position, desiredVelocity, Color.red);
		Debug.DrawRay(transform.position, currentVelocity);

		return steeringVelocity;
	}

	/*protected Vector2 Flee(Vector2 currentVelocity, Vector2 targetPosition)
	{
		// Notice for flee that this is identical to seek except the targetPosition and current position is swapped round
		// These 3 lines are equivalent to: desiredVelocity = Normalise(currentPoisition - targetPosition) * MaxSpeed
		Vector2 desiredVelocity = new Vector2(transform.position.x, transform.position.y) - targetPosition;
		desiredVelocity.Normalize();
		desiredVelocity *= maxSpeed;
		
		// Calculate steering velocity
		Vector2 steeringVelocity = desiredVelocity - currentVelocity;
		steeringVelocity = LimitSteering(steeringVelocity);

		// Useful for showing directions in scene view to visualise what the AI is doing
		Debug.DrawRay(transform.position, desiredVelocity, Color.red);
		Debug.DrawRay(transform.position, currentVelocity);

		return steeringVelocity;
	}*/
	#endregion

	#region BehaviorManagement
	/// <summary>
	/// This is responsible for how to deal with multiple behaviours and selecting which ones to use. Please see this link for some decent descriptions of below:
	/// https://alastaira.wordpress.com/2013/03/13/methods-for-combining-autonomous-steering-behaviours/
	/// Remember some options for choosing are:
	/// 1 Finite state machines which can be part of the steering behaviours or not (Not the best approach but quick)
	/// 2 Weighted Truncated Sum
	/// 3 Prioritised Weighted Truncated Sum
	/// 4 Prioritised Dithering
	/// 5 Context Behaviours: https://andrewfray.wordpress.com/2013/03/26/context-behaviours-know-how-to-share/
	/// 6 Any other approach you come up with
	/// </summary>
	protected void CooperativeArbitration()
	{
		// Get a new target position which is just the mouse position for now. This could be other game agents - think about the Dog, cat, mouse example
		Vector3 targetPosition = GetMousePosition();

		// Currently just choosing seeking so no arbitration is happening
		Vector3 currentVelocity = rigidBody.velocity;
		currentVelocity += Seek(currentVelocity, targetPosition);

		// Uncomment the next line to activate flee. See what happens when you do both behaviours and observe why Cooperative Arbitration is needed
		//currentVelocity += Flee(currentVelocity, targetPosition);

		currentVelocity = LimitVelocity(currentVelocity);
		rigidBody.velocity = currentVelocity;
	}
	#endregion
}