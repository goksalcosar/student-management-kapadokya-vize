using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_İşleri_Otomasyonu.Helper
{
    public class UserUtils
    {
        public static void ClearAllInputData(MainForm form)
        {
            form.userNameTxt.Clear();
            form.userSurnameTxt.Clear();
            form.userMaskedBirthDay.Clear();
            form.userCitionTxt.Clear();
            form.userPasswordTxt.Clear();
            form.userCitionStatusTxt.Clear();
            form.userSurnameStatusTxt.Clear();
            form.materialTextBox2.Clear();
            form.materialMaskedTextBox2.Clear();
            form.materialTextBox1.Clear();
            form.materialMultiLineTextBox21.Clear();
            form.userGenderMaleRadio.Checked = false;
            form.userGenderWomanRadio.Checked = false;
            form.userStatusChecbox.Checked = false;
        }

        public static void ClearAllTeachernputData(MainForm form)
        {
            form.materialTextBox11.Clear();
            form.materialTextBox10.Clear();
            form.materialMaskedTextBox3.Clear();
            form.materialTextBox8.Clear();
            form.materialRadioButton2.Checked = false;
            form.materialCheckbox1.Checked = false;
            form.materialTextBox9.Clear();
            form.materialTextBox5.Clear();
            form.materialMaskedTextBox1.Clear();
            form.materialTextBox6.Clear();
            form.materialMultiLineTextBox22.Clear();
            form.materialTextBox12.Clear();
        }
    }
}
