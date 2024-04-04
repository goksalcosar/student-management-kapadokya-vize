using MaterialSkin;
using MaterialSkin.Controls;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.ClassDataModel;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject;
using Öğrenci_İşleri_Otomasyonu.Helper;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.LessonDataModel;


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
            getUsersButton.Enabled = false;
            // Asenkron işlemi başlat
            await LoadUserDataAsync("Öğrenci");
        }

        private async Task LoadUserDataAsync(string role)
        {
            try
            {
                if (role == "Öğrenci")
                {
                    // Verileri DataGridView kontrolüne at
                    userDataGrid.DataSource = await Task.Run(() => SelectUserDataOperations.GetAllUser());
                    getUsersButton.Enabled = true;
                }
                else
                {
                    dataGridView1.DataSource = await Task.Run(() => SelectUserDataOperations.getAllTeacher());
                    materialButton3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bildir
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private async Task LoadLessonDataAsync()
        {
            try
            {
                dataGridView2.DataSource = await Task.Run(() => SelectLessonDataOperations.getAllLessons());
                materialButton12.Enabled = true;

            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bildir
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            string result = CreateUserDataOperations.CreateStudent
            (
                userNameTxt.Text,
                userSurnameTxt.Text,
                userMaskedBirthDay.Text,
                userCitionTxt.Text,
                userGenderMaleRadio.Checked ? "Erkek" : "Kadın",
                userStatusChecbox.Checked ? true : false,
                userPasswordTxt.Text,
                materialTextBox2.Text,
                materialMaskedTextBox2.Text,
                materialTextBox1.Text,
                materialMultiLineTextBox21.Text
            );

            MessageBox.Show(result);

            await LoadUserDataAsync("Öğrenci");
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            string result = UpdateUserDataOperations.UpdateStudent
            (
                userNameTxt.Text,
                userSurnameTxt.Text,
                userMaskedBirthDay.Text,
                userCitionTxt.Text,
                userGenderMaleRadio.Checked ? "Erkek" : "Kadın",
                userStatusChecbox.Checked ? true : false,
                userPasswordTxt.Text,
                materialTextBox2.Text,
                materialMaskedTextBox2.Text,
                materialTextBox1.Text,
                materialMultiLineTextBox21.Text,
                int.Parse(invisibleTxt.Text)
            );

            MessageBox.Show(result);

            await LoadUserDataAsync("Öğrenci");
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < userDataGrid.Rows.Count)
            {
                // İlgili satırdaki verileri al
                DataGridViewRow selectedRow = userDataGrid.Rows[rowIndex];

                // İlgili hücrelerdeki verilere erişerek işlemlerinizi yapabilirsiniz
                int userID = int.Parse(selectedRow.Cells["Kullanıcı_ID"].Value.ToString());

                var context = new MainContext().StudentManagementContext;
                inputAreaSetStudentData(SelectUserDataOperations.GetFindByIdUser(userID, context));
            }
        }

        public void inputAreaSetStudentData(DataObjects.User? user)
        {
            userNameTxt.Text = user.Name;
            userSurnameTxt.Text = user.Surname;
            userMaskedBirthDay.Text = user.BirthDate.ToString("yyyy-MM-dd");
            userCitionTxt.Text = user.TcNo;
            userPasswordTxt.Text = user.Password;
            materialTextBox2.Text = user.Role;
            materialMaskedTextBox2.Text = user.PhoneNumber;
            materialTextBox1.Text = user.Email;
            materialMultiLineTextBox21.Text = user.Address;
            invisibleTxt.Text = user.Id.ToString();

            if (user.Gender == "Erkek")
            {
                userGenderMaleRadio.Checked = true;
            }
            else
            {
                userGenderWomanRadio.Checked = true;
            }

            userStatusChecbox.Checked = user.IsActive;
        }

        public void inputAreaSetTeacherData(DataObjects.User? user)
        {
            materialTextBox11.Text = user.Name;
            materialTextBox10.Text = user.Surname;
            materialMaskedTextBox3.Text = user.BirthDate.ToString();
            materialTextBox8.Text = user.TcNo;
            materialTextBox9.Text = user.Password;
            materialTextBox5.Text = user.Role;
            materialMaskedTextBox1.Text = user.PhoneNumber;
            materialTextBox6.Text = user.Email;
            materialMultiLineTextBox22.Text = user.Address;
            materialTextBox12.Text = user.Expertise;
            materialTextBox7.Text = user.Id.ToString();

            if (user.Gender == "Erkek")
            {
                materialRadioButton2.Checked = true;
            }
            else
            {
                materialRadioButton1.Checked = true;
            }

            materialCheckbox1.Checked = user.IsActive;
        }

        private async void materialButton5_Click_1(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            var result = DisableUserDataOperations.disableUserData(userSurnameStatusTxt.Text, userCitionStatusTxt.Text);

            MessageBox.Show(result);
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            UserUtils.ClearAllInputData(this);
        }

        private void userRoleTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void materialButton4_Click_1(object sender, EventArgs e)
        {
            materialTextBox4.Enabled = false;
            // Asenkron işlemi başlat
            await LoadUserDataAsync("Öğretmen");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                // İlgili satırdaki verileri al
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                // İlgili hücrelerdeki verilere erişerek işlemlerinizi yapabilirsiniz
                int userID = int.Parse(selectedRow.Cells["Kullanıcı_ID"].Value.ToString());

                var context = new MainContext().StudentManagementContext;
                inputAreaSetTeacherData(SelectUserDataOperations.GetFindByIdUser(userID, context));
            }
        }

        private async void materialButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click_1(object sender, EventArgs e)
        {
        }

        private void userStatusButton_Click(object sender, EventArgs e)
        {
            var result = DisableUserDataOperations.disableUserData(userSurnameStatusTxt.Text, userCitionStatusTxt.Text);

            MessageBox.Show(result);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void materialButton4_Click_2(object sender, EventArgs e)
        {
            string result = CreateUserDataOperations.CreateTeacher
            (
                materialTextBox11.Text,
                materialTextBox10.Text,
                materialMaskedTextBox3.Text,
                materialTextBox8.Text,
                materialRadioButton2.Checked ? "Erkek" : "Kadın",
                materialCheckbox1.Checked ? true : false,
                materialTextBox9.Text,
                materialTextBox5.Text,
                materialMaskedTextBox1.Text,
                materialTextBox6.Text,
                materialMultiLineTextBox22.Text,
                materialTextBox12.Text
            );

            MessageBox.Show(result);

            await LoadUserDataAsync("Öğretmen");
        }

        private void materialTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private async void materialButton3_Click_2(object sender, EventArgs e)
        {
            materialButton3.Enabled = false;
            // Asenkron işlemi başlat
            await LoadUserDataAsync("Öğretmen");
        }

        private async void materialButton5_Click_2(object sender, EventArgs e)
        {
            string result = UpdateUserDataOperations.UpdateTeacher
           (
               materialTextBox11.Text,
               materialTextBox10.Text,
               materialMaskedTextBox3.Text,
               materialTextBox8.Text,
               materialRadioButton2.Checked ? "Erkek" : "Kadın",
               materialCheckbox1.Checked ? true : false,
               materialTextBox9.Text,
               materialTextBox5.Text,
               materialMaskedTextBox1.Text,
               materialTextBox6.Text,
               materialMultiLineTextBox22.Text,
               int.Parse(materialTextBox7.Text),
               materialTextBox12.Text
           );

            MessageBox.Show(result);

            await LoadUserDataAsync("Öğretmen");
        }

        private void materialButton2_Click_2(object sender, EventArgs e)
        {
            UserUtils.ClearAllTeachernputData(this);
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            var result = DisableUserDataOperations.disableUserData(materialTextBox3.Text, materialTextBox4.Text);

            MessageBox.Show(result);
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            string result = CreateLessoneDataOpertions.CreateLesson
            (
                materialTextBox14.Text,
                materialComboBox1.SelectedItem.ToString()
            );

            MessageBox.Show(result);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var lesson = SelectLessonDataOperations.getKeyValueLessons();
            var teacher = SelectUserDataOperations.getTeacher();

            foreach (var item in teacher)
            {
                materialComboBox3.Items.Add(item.Value);
            }

            foreach (var item in lesson)
            {
                materialComboBox4.Items.Add(item.Value);
            }
        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void materialCard20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            string result = CreateLessoneDataOpertions.SetLessonTeacher
            (
                materialComboBox3.SelectedItem.ToString(),
                materialComboBox4.SelectedItem.ToString()

            );

            MessageBox.Show(result);
        }

        private async void materialButton12_Click(object sender, EventArgs e)
        {
            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadLessonDataAsync();
        }
    }
}
