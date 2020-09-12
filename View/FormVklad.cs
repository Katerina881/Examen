using Logic.BindingModel;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormVklad : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IVklad Vklad;

        private readonly IBank Bank;

        private int? id;

        public FormVklad(IVklad service, IBank BankService)
        {
            InitializeComponent();
            this.Vklad = service;
            this.Bank = BankService;
        }

        private void FormVklad_Load(object sender, EventArgs e)
        {
            var list = Bank.Read(null);
            if (list != null)
            {
                comboBox1.DataSource = list;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

            }
            if (id.HasValue)
            {
                try
                {

                    var view = Vklad.Read(new VkladBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFullName.Text = view.Name;
                        textBoxCount.Text = view.Sum.ToString();
                        dateTimePicker1.Value = view.DataCreateVklad;
                        textBoxJob.Text = view.TypeVal;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFullName.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedValue == null)
            {
                
                MessageBox.Show("Выберите банк", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(textBoxFullName.Text, @"^[а-яА-Я]+$"))
            {
                MessageBox.Show("В названии могут быть только буквы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(textBoxCount.Text, @"^\d+$"))
            {
                MessageBox.Show("В количестве могут быть только цифры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(textBoxJob.Text, @"^[а-яА-Я]+$"))
            {
                MessageBox.Show("В месте изготовления могут быть только буквы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Vklad.CreateOrUpdate(new VkladBindingModel
                {
                    Id = id,
                    VkladName = textBoxFullName.Text,
                    Sum = Convert.ToInt32(textBoxCount.Text),
                    TypeVal = textBoxJob.Text,
                    DataCreateVklad = dateTimePicker1.Value,
                    BankId = Convert.ToInt32(comboBox1.SelectedValue)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
