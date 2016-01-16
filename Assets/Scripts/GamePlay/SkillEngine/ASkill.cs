using UnityEngine;
using System.Collections;
using UnityEngine.UI;



namespace Skill
{
    public abstract class ASkill : MonoBehaviour
    {
        
        public int mValue = 0;

        public int Value
        {
            get
            {
                return mValue;
            }
            set
            {
                mValue = value;
                mText.text = this.GetSkillName() + " : " + mValue;
            }
        }

        private Text mText;

        public abstract string GetSkillName();

        // Use this for initialization
        void Awake()
        {
            mText = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //public static T NewSkill<T>(float val)
        //    where T : ASkill, new()
        //{
        //    T skill = new T();

        //    skill.Value = val;

        //    return skill;
        //}
    }
}
