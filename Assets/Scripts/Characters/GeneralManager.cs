using UnityEngine;
using Characters.CharacterTypes;

namespace Characters
{
    public class GeneralManager : MonoBehaviour
    {
        [SerializeField] private Commons m_Commons = null;
        [SerializeField] private CharacterManager[] m_Characters;
        [SerializeField] private CharacterManager m_Main;

        private bool m_CanSwitch = true;
        private CharacterSwitcher m_CharacterSwitch;

        private void Start()
        {
            foreach (var character in m_Characters)
                character.SetMain(false);

            m_Main.SetMain(true);

            m_CharacterSwitch = GetComponent<CharacterSwitcher>();
            m_CharacterSwitch.enabled = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K)) 
                GoTogether();
            else if (Input.GetKeyDown(KeyCode.L)) 
                GoSeparate();

            if (m_CanSwitch)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (!m_CharacterSwitch.enabled)
                        m_CharacterSwitch.enabled = true;
                }
                else if(Input.GetKeyUp(KeyCode.LeftShift))
                {
                    if (m_CharacterSwitch.enabled)
                        m_CharacterSwitch.enabled = false;
                }
            }

        }

        public void SetMain(CharacterManager newMain)
        {
            if (newMain != null)
            {
                m_Main.SetMain(false);
                m_Main = newMain;
                m_Main.SetMain(true);
                Debug.Log("Now playing as " + m_Main.gameObject.name);
            }
        }

        public CharacterManager GetMain() => m_Main;

        void GoTogether()
        {
            m_CanSwitch = false;
            foreach(var character in m_Characters)
            {
                character.DisableSpecialMechanics();
                character.EnableMovement();
                character.SetCommonMovement(m_Commons);
            }
        }

        void GoSeparate()
        {
            m_CanSwitch = true;
            foreach(var character in m_Characters)
            {
                character.DisableMovement();
                character.SetNormalMovement();
            }
            m_Main.EnableMovement();
        }

        public void SetCharacterSwitch(bool value) => m_CanSwitch = value;
    }
}