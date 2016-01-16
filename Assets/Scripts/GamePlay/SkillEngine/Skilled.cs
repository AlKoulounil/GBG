using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Skill {
	
	public enum ALL_SKILLS {
		STR = 0
	}

	public class Skilled : MonoBehaviour {

		public const int SKILL_NUMBER = 1;
        //private static System.Type[] SkillClasses;

		private ASkill[] mSkills;

        public ASkill[] Skills
        {
            get { return mSkills; }
        }


		// Use this for initialization
        void Awake()
        {
            //if (SkillClasses == null) {
            //    SkillClasses = new System.Type[SKILL_NUMBER];
            //    SkillClasses [(int)ALL_SKILLS.STR] = typeof(Strength);
            //}

            mSkills = new ASkill[SKILL_NUMBER];
            mSkills[(int)ALL_SKILLS.STR] = GetComponentInChildren<Strength>();

            //Debug.Log(mSkills[(int)ALL_SKILLS.STR]);

		}
		
	}
}