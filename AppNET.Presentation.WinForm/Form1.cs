using AppNET.App;
using AppNET.Domain.Entities;
using AppNET.Infrastructure;

namespace AppNET.Presentation.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ICategoryService categoryService = IOCContainer.Resolve<ICategoryService>();

       
        private void FillCategoryGrid()
        {
            grdCategory.DataSource = categoryService.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCategoryGrid();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (btnSaveCategory.Text == "kaydet")
            {
                int id = Convert.ToInt32(txtCategoryId.Text); //Textbox daki de�erler default olarak string oldu�u i�in int e �evirdik ��nk� Create metodu id yi int bekliyor
                categoryService.Create(id, txtCategoryName.Text);
            }
            else 
            {
                categoryService.Update(Convert.ToInt32(txtCategoryId.Text), txtCategoryName.Text);
                btnSaveCategory.Text = "kaydet";
                groupBox1.Text = "Yeni Kategori";
                txtCategoryId.Enabled = true;
            }
            txtCategoryId.Text = "";
            txtCategoryName.Text = "";
            FillCategoryGrid();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string categoryName = grdCategory.CurrentRow.Cells["Name"].Value.ToString();
            DialogResult result= MessageBox.Show($"{categoryName} kategorisini silmek istedi�inizden emin misiniz?",
                "Silme Onay�", MessageBoxButtons.YesNo,MessageBoxIcon.Question);


            if (result == DialogResult.No)
                return;

            int id = Convert.ToInt32(grdCategory.CurrentRow.Cells["Id"].Value);
            categoryService.Delete(id);
            FillCategoryGrid();
        }

        private void d�zenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string categoryName = grdCategory.CurrentRow.Cells["Name"].Value.ToString();
            string id = grdCategory.CurrentRow.Cells["Id"].Value.ToString();
            txtCategoryId.Text = id;
            txtCategoryName.Text = categoryName;

            txtCategoryId.Enabled = false;
            btnSaveCategory.Text = "G�ncelle";
            groupBox1.Text = "Kategori G�ncelle";
        }
    }
}