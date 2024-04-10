using MaterialSkin;
using MaterialSkin.Controls;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.AbsenceDataModel;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.DiscontinuityDataModel;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.ExamResultDataModel;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.LessonDataModel;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;
using Öğrenci_İşleri_Otomasyonu.Helper;


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
                    userDataGrid.DataSource = await Task.Run(() => SelectUserDataOperations.GetAllStudent());
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

        private async Task LoadExamResultDataAsync()
        {
            try
            {
                dataGridView3.DataSource = await Task.Run(() => SelectExamResultDataOpertions.getAllExamResult());
                materialButton16.Enabled = true;

            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bildir
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }
        private async Task LoadExamFilteringResultDataAsync(string citionNumber)
        {
            try
            {
                dataGridView4.DataSource = await Task.Run(() => SelectExamResultDataOpertions.getAllFilteringExamResult(citionNumber));
                materialButton16.Enabled = true;

            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bildir
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private async Task LoadAbsenceDataAsync()
        {
            try
            {
                dataGridView5.DataSource = await Task.Run(() => SelectAbsenceDataOperations.getAbsence());
                materialButton22.Enabled = true;

            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bildir
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private async Task LoadAbsenceFilteringDataAsync(string citionNumber)
        {
            try
            {
                dataGridView6.DataSource = await Task.Run(() => SelectAbsenceDataOperations.getAbsenceFilteringCitionNumber(citionNumber));
                materialButton23.Enabled = true;

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
                int userID = int.Parse(selectedRow.Cells["Öğrenci_ID"].Value.ToString());

                var context = new MainContext().StudentManagementContext;
                inputAreaSetStudentData(SelectUserDataOperations.GetFindByIdUser(userID, context));
            }
        }

        public void inputAreaSetStudentData(DataObjects.User? user)
        {
            userNameTxt.Text = user.Name;
            userSurnameTxt.Text = user.Surname;
            userMaskedBirthDay.Text = user.BirthDate.ToString("dd-MM-yyyy");
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

        public void inputAreaSetExamResultData(DataObjects.ExamResult? examResult)
        {
            materialComboBox7.SelectedItem = examResult.Lesson.Name;
            materialComboBox6.SelectedItem = examResult.Type;
            materialComboBox2.SelectedItem = examResult.User.Name + " " + examResult.User.Surname;
            materialMaskedTextBox4.Text = examResult.Score.ToString();
            materialTextBox13.Text = examResult.Id.ToString();

            materialComboBox7.Refresh();
            materialComboBox6.Refresh();
            materialComboBox2.Refresh();
            materialMaskedTextBox4.Refresh();
        }

        public void inputAreaSetLessonData(DataObjects.Lesson? lesson, int lessonId, string lessonName, string lessonType)
        {
            if (lesson != null)
            {
                var teacher = lesson.LessonTeachers.FirstOrDefault().Teacher;

                materialTextBox14.Text = lesson.Name;
                materialComboBox4.SelectedItem = lesson.Name;
                materialComboBox1.SelectedItem = lesson.Type;
                materialComboBox3.SelectedItem = teacher.Name;
                materialTextBox16.Text = lesson.Id.ToString();
                materialTextBox15.Text = lesson.Name;
            }
            else
            {
                materialTextBox14.Text = lessonName;
                materialComboBox4.SelectedItem = lessonName;
                materialComboBox1.SelectedItem = lessonType;
                materialComboBox3.SelectedItem = lessonName;
                materialTextBox16.Text = lessonId.ToString();
                materialTextBox15.Text = lessonName;
            }

            materialComboBox4.Refresh();
            materialComboBox1.Refresh();
            materialComboBox3.Refresh();
        }

        public void inputAreaSetAbsenceData(DataObjects.Absence? absence)
        {
            materialComboBox8.SelectedItem = absence.User.Name + " " + absence.User.Surname;
            materialTextBox17.Text = absence.Id.ToString();

            if (int.TryParse(absence.ExcusedAbsence, out _))
            {
                materialSwitch1.Checked = true;
            }
            else
            {
                materialSwitch1.Checked = false;
            }

            materialComboBox8.Refresh();
            materialTextBox17.Refresh();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            UserUtils.ClearAllInputData(this);
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
                int userID = int.Parse(selectedRow.Cells["Öğretmen_ID"].Value.ToString());

                var context = new MainContext().StudentManagementContext;
                inputAreaSetTeacherData(SelectUserDataOperations.GetFindByIdUser(userID, context));
            }
        }

        private async void userStatusButton_Click(object sender, EventArgs e)
        {
            var result = DisableUserDataOperations.UserStatusUpdate(userSurnameStatusTxt.Text, userCitionStatusTxt.Text, materialSwitch2.Checked);
            getUsersButton.Enabled = false;
            // Asenkron işlemi başlat
            await LoadUserDataAsync("Öğrenci");

            MessageBox.Show(result);
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

        private async void materialButton1_Click_1(object sender, EventArgs e)
        {
            var result = DisableUserDataOperations.UserStatusUpdate(materialTextBox3.Text, materialTextBox4.Text, materialSwitch3.Checked);
            getUsersButton.Enabled = false;
            // Asenkron işlemi başlat
            await LoadUserDataAsync("Öğretmen");

            MessageBox.Show(result);
        }

        private async void materialButton6_Click(object sender, EventArgs e)
        {
            string result = CreateLessoneDataOpertions.CreateLesson
            (
                materialTextBox14.Text,
                materialComboBox1.SelectedItem.ToString()
            );

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadLessonDataAsync();
            ClearAllLessonsInputData();

            MessageBox.Show(result);
        }

        private async void materialButton9_Click(object sender, EventArgs e)
        {
            string result = CreateLessoneDataOpertions.SetLessonTeacher
            (
                materialComboBox3.SelectedItem.ToString(),
                materialComboBox4.SelectedItem.ToString()

            );

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadLessonDataAsync();
            ClearAllLessonsInputData();

            MessageBox.Show(result);
        }

        private async void materialButton12_Click(object sender, EventArgs e)
        {
            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadLessonDataAsync();
        }

        private void materialComboBox4_Click(object sender, EventArgs e)
        {
            materialComboBox4.Items.Clear();

            var lesson = SelectLessonDataOperations.getKeyValueLessons();

            foreach (var item in lesson)
            {
                materialComboBox4.Items.Add(item.Value);
                materialComboBox7.Items.Add(item.Value);
            }
        }

        private void materialComboBox3_Click(object sender, EventArgs e)
        {
            materialComboBox3.Items.Clear();

            var teacher = SelectUserDataOperations.getTeacher();

            foreach (var item in teacher)
            {
                materialComboBox3.Items.Add(item.Value);
            }
        }


        private void materialComboBox2_Click(object sender, EventArgs e)
        {
            materialComboBox2.Items.Clear();

            var student = SelectUserDataOperations.getStudent();

            foreach (var item in student)
            {
                materialComboBox2.Items.Add(item.Key + " " + item.Value);
            }
        }


        private void materialComboBox7_Click(object sender, EventArgs e)
        {
            materialComboBox7.Items.Clear();

            var lessons = SelectLessonDataOperations.getKeyValueLessons();

            foreach (var item in lessons)
            {
                materialComboBox7.Items.Add(item.Value);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TabControlByRoleControl(UserSessionInfo.Role);

            var lesson = SelectLessonDataOperations.getKeyValueLessons();
            var teacher = SelectUserDataOperations.getTeacher();
            var student = SelectUserDataOperations.getStudent();

            foreach (var item in lesson)
            {
                materialComboBox4.Items.Add(item.Value);
                materialComboBox7.Items.Add(item.Value);
            }

            foreach (var item in teacher)
            {
                materialComboBox3.Items.Add(item.Value);
            }

            foreach (var item in student)
            {
                materialComboBox2.Items.Add(item.Key + " " + item.Value);
                materialComboBox8.Items.Add(item.Key + " " + item.Value);
                materialComboBox5.Items.Add(item.Key + " " + item.Value);
            }
        }

        private async void materialButton7_Click(object sender, EventArgs e)
        {
            string result = UpdateLessonDataOperations.UpdateLesson
              (
                    materialTextBox14.Text,
                    materialComboBox1.SelectedItem.ToString()
              );

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadLessonDataAsync();
            ClearAllLessonsInputData();

            MessageBox.Show(result);
        }

        private async void materialButton8_Click(object sender, EventArgs e)
        {
            string result = UpdateLessonDataOperations.UpdateTeacherRelationLesson
              (
                    materialTextBox14.Text,
                    materialComboBox3.SelectedItem.ToString()
              );

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadLessonDataAsync();
            ClearAllLessonsInputData();

            MessageBox.Show(result);
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            ClearAllLessonsInputData();
        }

        private async void materialButton13_Click(object sender, EventArgs e)
        {
            string result = CreateExamResultDataOpertions.CreateLessonNote
            (
                UserSessionInfo.Name,
                materialComboBox7.SelectedItem.ToString(),
                materialComboBox2.SelectedItem.ToString(),
                float.Parse(materialMaskedTextBox4.Text),
                materialComboBox6.SelectedItem.ToString()
            );

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadExamResultDataAsync();
            ClearExamResultInputData();

            MessageBox.Show(result);
        }

        private async void materialButton16_Click(object sender, EventArgs e)
        {
            await LoadExamResultDataAsync();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView3.Rows.Count)
            {
                // İlgili satırdaki verileri al
                DataGridViewRow selectedRow = dataGridView3.Rows[rowIndex];

                // İlgili hücrelerdeki verilere erişerek işlemlerinizi yapabilirsiniz
                int examResultId = int.Parse(selectedRow.Cells["Not_Id"].Value.ToString());

                var context = new MainContext().StudentManagementContext;
                inputAreaSetExamResultData(SelectExamResultDataOpertions.GetFindByIdExamResult(examResultId, context));
            }
        }

        private async void materialButton11_Click(object sender, EventArgs e)
        {
            string result = UpdateExamResultDataOperations.UpdateExamResult
            (
                int.Parse(materialTextBox13.Text),
                materialComboBox7.SelectedItem.ToString(),
                materialComboBox6.SelectedItem.ToString(),
                materialComboBox2.SelectedItem.ToString(),
                materialMaskedTextBox4.Text
            );

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadExamResultDataAsync();
            ClearExamResultInputData();

            MessageBox.Show(result);
        }

        private async void materialButton17_Click(object sender, EventArgs e)
        {
            string result = DeleteExamResultDataOperations.DeleteExamResult(int.Parse(materialTextBox13.Text));

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadExamResultDataAsync();

            MessageBox.Show(result);
        }

        private void materialButton18_Click(object sender, EventArgs e)
        {
            ClearExamResultInputData();
        }

        public void ClearExamResultInputData()
        {
            materialTextBox13.Clear();
            materialComboBox7.SelectedIndex = -1;
            materialComboBox6.SelectedIndex = -1;
            materialComboBox2.SelectedIndex = -1;
            materialMaskedTextBox4.Clear();

            materialComboBox7.Refresh();
            materialComboBox6.Refresh();
            materialComboBox2.Refresh();
        }

        public void ClearAllLessonsInputData()
        {
            materialTextBox14.Clear();
            materialComboBox1.SelectedIndex = -1;
            materialComboBox4.SelectedIndex = -1;
            materialComboBox3.SelectedIndex = -1;
            materialTextBox16.Clear();
            materialTextBox15.Clear();

            materialComboBox1.Refresh();
            materialComboBox4.Refresh();
            materialComboBox3.Refresh();
        }

        public void ClearAllAbsenceInputData()
        {
            materialComboBox8.SelectedIndex = -1;
            materialTextBox17.Clear();
            materialSwitch1.Checked = false;

            materialComboBox8.Refresh();
        }

        private async void materialButton15_Click(object sender, EventArgs e)
        {
            string result = DeleteLessonDataOperations.DeleteLesson(int.Parse(materialTextBox16.Text));

            materialButton12.Enabled = false;
            // Asenkron işlemi başlat
            await LoadLessonDataAsync();
            ClearAllLessonsInputData();

            MessageBox.Show(result);
        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView2.Rows.Count)
            {
                // İlgili satırdaki verileri al
                DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];

                // İlgili hücrelerdeki verilere erişerek işlemlerinizi yapabilirsiniz
                int lessonId = int.Parse(selectedRow.Cells["Ders_Id"].Value.ToString());
                string lessonName = selectedRow.Cells["Ders_Adı"].Value.ToString();
                string lessonType = selectedRow.Cells["Ders_Tipi"].Value.ToString();

                var context = new MainContext().StudentManagementContext;
                inputAreaSetLessonData(SelectLessonDataOperations.GetFindByIdLesson(lessonId, context), lessonId, lessonName, lessonType);
            }
        }

        public void TabControlByRoleControl(string role)
        {
            switch (role)
            {
                case "Öğretmen":
                    materialTabControl1.TabPages.Remove(tabPage2);
                    materialTabControl1.TabPages.Remove(tabPage3);
                    materialTabControl1.TabPages.Remove(tabPage4);
                    materialTabControl1.TabPages.Remove(tabPage5);
                    materialTabControl1.TabPages.Remove(tabPage7);
                    break;
                case "Öğrenci":
                    materialTabControl1.TabPages.Remove(tabPage1);
                    materialTabControl1.TabPages.Remove(tabPage2);
                    materialTabControl1.TabPages.Remove(tabPage3);
                    materialTabControl1.TabPages.Remove(tabPage4);
                    materialTabControl1.TabPages.Remove(tabPage6);
                    break;
                default:
                    materialTabControl1.TabPages.Remove(tabPage5);
                    materialTabControl1.TabPages.Remove(tabPage7);
                    break;
            }
        }

        private async void materialButton14_Click(object sender, EventArgs e)
        {
            await LoadExamFilteringResultDataAsync(UserSessionInfo.CitionNumber);
        }

        private async void materialButton21_Click(object sender, EventArgs e)
        {
            string result = CreateAbsenceDataOperations.CreateStudentAbsence
            (
                materialComboBox8.SelectedItem.ToString(),
                materialSwitch1.Checked
            );

            materialButton22.Enabled = false;
            //// Asenkron işlemi başlat
            await LoadAbsenceDataAsync();
            ClearExamResultInputData();

            MessageBox.Show(result);
        }

        private async void materialButton22_Click(object sender, EventArgs e)
        {
            await LoadAbsenceDataAsync();
        }

        private async void materialButton20_Click(object sender, EventArgs e)
        {
            string result = UpdateAbsenceDataOperations.UpdateAbsence
            (
                int.Parse(materialTextBox17.Text),
                materialComboBox8.SelectedItem.ToString(),
                materialSwitch1.Checked
            );

            materialButton22.Enabled = false;
            // Asenkron işlemi başlat
            await LoadAbsenceDataAsync();
            ClearAllAbsenceInputData();

            MessageBox.Show(result);
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView5.Rows.Count)
            {
                // İlgili satırdaki verileri al
                DataGridViewRow selectedRow = dataGridView5.Rows[rowIndex];

                // İlgili hücrelerdeki verilere erişerek işlemlerinizi yapabilirsiniz
                int absenceId = int.Parse(selectedRow.Cells["Devamsızlık_Id"].Value.ToString());
                string student = selectedRow.Cells["Öğrenci"].Value.ToString();

                var context = new MainContext().StudentManagementContext;
                inputAreaSetAbsenceData(SelectAbsenceDataOperations.GetFindByIdAbsence(absenceId, context));
            }
        }

        private async void materialButton19_Click(object sender, EventArgs e)
        {
            string result = DeleteAbsenceDataOperations.DeleteAbsence(int.Parse(materialTextBox17.Text));

            materialButton22.Enabled = false;
            // Asenkron işlemi başlat
            await LoadAbsenceDataAsync();

            MessageBox.Show(result);
        }

        private void materialButton25_Click(object sender, EventArgs e)
        {
            var context = new MainContext().StudentManagementContext;

            var result = SelectAbsenceDataOperations.GetFindByFullNameStudentAbsenceData(materialComboBox5.SelectedItem.ToString(), context);

            materialTextBox18.Text = result.TotalUnexcusedAbsence.ToString();
            materialTextBox19.Text = result.TotalExcusedAbsence.ToString();
        }

        private async void materialButton23_Click(object sender, EventArgs e)
        {
            var context = new MainContext().StudentManagementContext;

            var result = SelectAbsenceDataOperations.GetFindByFullNameStudentAbsenceData(UserSessionInfo.Name + " " + UserSessionInfo.SurName, context);
            await LoadAbsenceFilteringDataAsync(UserSessionInfo.CitionNumber);

            materialTextBox20.Text = result.TotalExcusedAbsence.ToString();
            materialTextBox21.Text = result.TotalUnexcusedAbsence.ToString();
        }
    }
}
