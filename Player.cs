using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;        
	[SerializeField] private bool m_AirControl = false;   	
	private bool m_Grounded;            
	private bool m_FacingRight = true;

	void Start()
	{
		
    }

   
    public void Move(float move, bool crouch, bool jump)//ใช้ในการกลับด้าน
	{

		if (m_Grounded || m_AirControl)
		{
			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}
		
	}

	private void Flip()
    {

        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}
