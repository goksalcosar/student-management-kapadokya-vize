using MaterialSkin;
using MaterialSkin.Controls;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;

namespace Öğrenci_İşleri_Otomasyonu.Form
{
    public partial class LoginPanel : MaterialForm
    {
        public LoginPanel()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var context = new MainContext().StudentManagementContext;
            var user = SelectUserDataOperations.GetFindByCitionNumberPassowrd(userCitionTxt.Text, userPasswordTxt.Text, context);

            if (user != null)
            {
                MainForm mainForm = new MainForm();
                MessageBox.Show(string.Format("Giriş Başarılı! Hoş geldiniz, {0}", (user.Name + " " + user.Surname)));
                UserSessionInfo.Name = user.Name;
                UserSessionInfo.SurName = user.Surname;
                UserSessionInfo.Role = user.Role;
                UserSessionInfo.CitionNumber = user.TcNo;

                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız! Lütfen Giriş Bilgilerinizi Kontrol ediniz...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void LoginPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
