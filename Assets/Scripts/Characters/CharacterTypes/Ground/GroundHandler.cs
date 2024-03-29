using Characters.Movement;

namespace Characters.CharacterTypes.Ground
{
    public class GroundHandler
    {
        public RunManager RunManager { get; private set; }
        public JumpManager JumpManager { get; private set; }

        public GroundHandler(Character character, bool disable = false)
        {
            RunManager = character.gameObject.GetComponent<RunManager>();
            JumpManager = character.gameObject.GetComponent<JumpManager>();
            if (disable)
                Disable();
        }

        public void Enable()
        {
            RunManager.enabled = true;
            JumpManager.enabled = true;
        }

        public void Disable()
        {
            RunManager.enabled = false;
            JumpManager.enabled = false;
        }

        public void SetCommon(General.Commons commons)
        {
            RunManager.SetRunSpeed(commons.runSpeed);
            JumpManager.SetJumpForce(commons.jumpForce);
        }

        public void SetNormal()
        {
            RunManager.SetDefaultRunSpeed();
            JumpManager.SetDefaultJumpForce();
        }
    }
}