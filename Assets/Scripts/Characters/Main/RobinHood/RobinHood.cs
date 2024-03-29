using UnityEngine;
using Characters.CharacterTypes.Ground;
using Characters.Movement;

namespace Characters.Main.RobinHood
{
    [RequireComponent(typeof(SpriteFlipper))]
    public class RobinHood : GroundCharacter
    {
        [SerializeField] private GameObject m_BowObj;
        private Bow m_Bow;
        private SpriteFlipper m_SpriteFlipper;
        private bool m_ShootMode = false;

        private void Start()
        {
            m_SpriteFlipper = GetComponent<SpriteFlipper>();
            m_Bow = m_BowObj.GetComponent<Bow>();
            m_BowObj.SetActive(false);
        }

        private void Update()
        {
            TryMechanic();
            SetAnimation();
        }

        private void TryMechanic()
        {
            if (m_IsMain && Input.GetKeyDown(KeyCode.Space) && GetHorizontalDirection() == 0f && m_GroundHandler.JumpManager.IsGrounded())
            {
                m_ShootMode = !m_ShootMode;
                if (m_ShootMode)
                {
                    if (m_SpriteFlipper.FacingRight())
                        m_Bow.ForceFacingRight();
                    else
                        m_Bow.ForceFacingLeft();
                    m_BowObj.SetActive(true);
                    DisableMovement();
                }
                else
                {
                    m_BowObj.SetActive(false);
                    EnableMovement();
                }
            }
        }

        private void SetAnimation()
        {
            m_Animator.SetBool(AnimatorHashes.JUMP, m_Rigidbody2D.velocity.y > 0f);
            m_Animator.SetBool(AnimatorHashes.FALL, m_Rigidbody2D.velocity.y < 0f);
            m_Animator.SetBool(AnimatorHashes.IDLE, GetHorizontalDirection() == 0f);
            m_Animator.SetBool(AnimatorHashes.WALK, GetHorizontalDirection() != 0f);
            m_Animator.SetBool(AnimatorHashes.SHOOT, m_ShootMode);
        }

        public override void DisableSpecialMechanics()
        {
            m_ShootMode = false;
            m_BowObj.SetActive(false);
        }

        public override void EnableSpecialMechanics()
        {
        }
    }
}