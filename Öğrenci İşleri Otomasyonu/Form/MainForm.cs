using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System.Security.Policy;
using System;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject;

namespace Öğrenci_İşleri_Otomasyonu
{
    public partial class MainForm : MaterialForm
    {

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private async void materialButton4_Click(object sender, EventArgs e)
        {
            materialButton4.Enabled = false;
            // Asenkron işlemi başlat
            await LoadUserDataAsync();
        }

        private async Task LoadUserDataAsync()
        {
            try
            {
                // Verileri asenkron olarak al
                var userData = await Task.Run(() => SelectUserDataOperations.GetAllUser());

                // Verileri DataGridView kontrolüne at
                dataGridView2.DataSource = userData;
                materialButton4.Enabled = true;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bildir
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            string result = CreateUserDataOperations.CreateUser
            (
                materialTextBox1.Text,
                materialTextBox2.Text,
                materialTextBox3.Text,
                materialTextBox4.Text,
                materialRadioButton1.Checked ? "Erkek" : "Kadın",
                materialCheckbox1.Checked ? true : false,
                materialTextBox8.Text,
                materialComboBox1.SelectedItem.ToString()
            );

            MessageBox.Show(result);

            await LoadUserDataAsync();
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            string result = UpdateUserDataOperations.UpdateUser
            (
                materialTextBox1.Text,
                materialTextBox2.Text,
                materialTextBox3.Text,
                materialTextBox4.Text,
                materialRadioButton1.Checked ? "Erkek" : "Kadın",
                materialCheckbox1.Checked ? true : false,
                materialTextBox8.Text,
                materialComboBox1.SelectedItem.ToString(),
                int.Parse(materialTextBox7.Text)
            );

            MessageBox.Show(result);

            await LoadUserDataAsync();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView2.Rows.Count)
            {
                // İlgili satırdaki verileri al
                DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];

                // İlgili hücrelerdeki verilere erişerek işlemlerinizi yapabilirsiniz
                int userID = int.Parse(selectedRow.Cells["Kullanıcı_ID"].Value.ToString());

                var context = new MainContext().StudentManagementContext;
                inputAreaSetUserData(SelectUserDataOperations.GetFindByIdUser(userID, context));
            }
        }

        public void inputAreaSetUserData(DataObjects.User? user)
        {
            materialTextBox1.Text = user.Name;
            materialTextBox2.Text = user.Surname;
            materialTextBox3.Text = user.BirthDate.ToString("yyyy-MM-dd");
            materialTextBox4.Text = user.TcNo;
            materialTextBox8.Text = user.Password;
            materialComboBox1.SelectedItem = user.Role;
            materialTextBox7.Text = user.Id.ToString();

            if (user.Gender == "Erkek")
            {
                materialRadioButton1.Checked = true;
            }
            else
            {
                materialRadioButton2.Checked = true;
            }

            materialCheckbox1.Checked = user.IsActive;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            var result = DisableUserDataOperations.disableUserData(materialTextBox9.Text, materialTextBox5.Text);

            MessageBox.Show(result);
        }
    }
}
