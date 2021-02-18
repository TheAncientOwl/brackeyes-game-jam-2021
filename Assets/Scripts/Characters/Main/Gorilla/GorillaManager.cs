using UnityEngine;
using Characters.CharacterTypes;

namespace Characters.Main.Gorilla
{
    public class GorillaManager : GroundCharacterManager
    {
        private static readonly int s_WALK = Animator.StringToHash("Walk");
        private static readonly int s_IN_AIR = Animator.StringToHash("InAir");
        private static readonly int s_LEFT_PUNCH = Animator.StringToHash("LeftPunch");
        private static readonly int s_RIGHT_PUNCH = Animator.StringToHash("RightPunch");

        private bool m_LeftPunch = true;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && m_IsMain)
            {
                m_Animator.SetTrigger(m_LeftPunch ? s_LEFT_PUNCH : s_RIGHT_PUNCH);
                m_LeftPunch = !m_LeftPunch;
            }
        }

        private void FixedUpdate()
        {
            m_Animator.SetBool(s_WALK, GetHorizontalDirection() != 0f);
            m_Animator.SetBool(s_IN_AIR, m_Rigidbody2D.velocity.normalized.y != 0f);
        }

        public override void DisableSpecialMechanics()
        {
        }

        public override void EnableSpecialMechanics()
        {
        }
    }
}