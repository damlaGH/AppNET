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
        IProductService productService = IOCContainer.Resolve<IProductService>();

        private void FillCategoryGrid()
        {
            grdCategory.DataSource = categoryService.GetAll();
        }
        private void FillProductGrid()
        {
            grdProduct.DataSource = productService.GetAll();
        }
        private void FillCategoryCbb()
        {
            cbbCategory.DataSource = categoryService.GetAll();
            cbbCategory.DisplayMember = nameof(Category.Name);
            cbbCategory.ValueMember = nameof(Category.Id); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCategoryGrid();
            FillProductGrid();
            FillCategoryCbb();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (btnSaveCategory.Text == "kaydet")
            {
                int id = Convert.ToInt32(txtCategoryId.Text); //Textbox daki değerler default olarak string olduğu için int e çevirdik çünkü Create metodu id yi int bekliyor
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
            DialogResult result = MessageBox.Show($"{categoryName} kategorisini silmek istediğinizden emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.No)
                return;

            int id = Convert.ToInt32(grdCategory.CurrentRow.Cells["Id"].Value);
            categoryService.Delete(id);
            FillCategoryGrid();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string categoryName = grdCategory.CurrentRow.Cells["Name"].Value.ToString();
            string id = grdCategory.CurrentRow.Cells["Id"].Value.ToString();
            txtCategoryId.Text = id;
            txtCategoryName.Text = categoryName;

            txtCategoryId.Enabled = false;
            btnSaveCategory.Text = "Güncelle";
            groupBox1.Text = "Kategori Güncelle";
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "kaydet")
            {
                int id = Convert.ToInt32(txtProductId.Text); //Textbox daki değerler default olarak string olduğu için int e çevirdik çünkü Create metodu id yi int bekliyor
                decimal price = Convert.ToDecimal(txtProductPrice.Text);
                int stock = Convert.ToInt32(txtProductStock.Text);
                int categoryId=Convert.ToInt32(txtCategoryId.Text); 
                productService.Create(id, txtProductName.Text, price, stock, categoryId);
                cbbCategory.SelectedIndex = 0;
            }
            else
            {
                int id = Convert.ToInt32(txtProductId.Text);
                Product p = productService.GetAll().FirstOrDefault(x => x.Id == id);
                p.Name = txtProductName.Text;
                p.Stock = Convert.ToInt32(txtProductStock.Text);
                p.Price = Convert.ToDecimal(txtProductPrice.Text);
                p.CategoryId = Convert.ToInt32(cbbCategory.SelectedValue);
                productService.Update(Convert.ToInt32(txtProductId.Text), p);
            }
            FillProductGrid();
               
                button1.Text = "kaydet";
                groupBox2.Text = "Yeni Ürün";
                txtProductId.Enabled = true;
                txtProductId.Text = "";
                txtProductName.Text = "";
                txtProductPrice.Text = "";
                txtProductStock.Text = "";
                cbbCategory.SelectedIndex = 0;


        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string productName = grdProduct.CurrentRow.Cells["Name"].Value.ToString();
            DialogResult result = MessageBox.Show($"{productName} ürününü silmek istediğinizden emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.No)
                return;

            int id = Convert.ToInt32(grdProduct.CurrentRow.Cells["Id"].Value);
            productService.Delete(id);
            FillProductGrid();
        }

        private void düzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtProductName.Text = grdProduct.CurrentRow.Cells["Name"].Value.ToString();
            txtProductId.Text = grdProduct.CurrentRow.Cells["Id"].Value.ToString();
            txtProductPrice.Text = grdProduct.CurrentRow.Cells["Price"].Value.ToString();
            txtProductStock.Text = grdProduct.CurrentRow.Cells["Stock"].Value.ToString();
           
            txtProductId.Enabled = false;
            button1.Text = "Güncelle";
            groupBox2.Text = "Ürünü Güncelle";
        }

       
    }
    
}