using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGCharacterAnims.Lookups
{
    public class UIWeaponSelection : MonoBehaviour
    {
        public RPGCharacterInputController myController;

        public void SelectSword()
        {
            myController.SetWeaponChoice(Weapon.TwoHandSword);
           
        }

        public void SelectAxe()
        {
            myController.SetWeaponChoice(Weapon.TwoHandAxe);
        }
    }
}
