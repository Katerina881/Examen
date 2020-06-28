using Logic.BindingModel;
using Logic.BuisnessLogic;
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
    public partial class FormOsns : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IOsn Osn;

        private readonly BackUpAbstractLogic backUpAbstractLogic;

        public FormOsns(IOsn Osn, BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            this.Osn = Osn;
            this.backUpAbstractLogic = backUpAbstractLogic;
        }

        private void FormOsns_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = Osn.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormOsn>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonCh_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormOsn>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        Osn.Delete(new OsnBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void продуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDops>();
            form.ShowDialog();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }

        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Файл сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
