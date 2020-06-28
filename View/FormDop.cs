using Logic.BindingModel;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormDop : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IDop Dop;

        private readonly IOsnv Osnv;

        private int? id;

        public FormDop(IDop service, IOsnv OsnvService)
        {
            InitializeComponent();
            this.Dop = service;
            this.Osnv = OsnvService;
        }

        private void FormDop_Load(object sender, EventArgs e)
        {
            var list = Osnv.Read(null);
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

                    var view = Dop.Read(new DopBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFullName.Text = view.Name;
                        textBoxCount.Text = view.Count.ToString();
                        dateTimePicker1.Value = view.DataCreateDop;
                        textBoxJob.Text = view.Place;

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
                //nas
                MessageBox.Show("Выберите блюдо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Dop.CreateOrUpdate(new DopBindingModel
                {
                    Id = id,
                    DopName = textBoxFullName.Text,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Place = textBoxJob.Text,
                    DataCreateDop = dateTimePicker1.Value,
                    OsnvId = Convert.ToInt32(comboBox1.SelectedValue)
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
