using AppNET.App;
using AppNET.Domain.Entities;
using AppNET.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

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
        IInvoiceService invoiceService = IOCContainer.Resolve<IInvoiceService>();
        ICashService cashService = IOCContainer.Resolve<ICashService>();
        IShoppingService shoppingService = IOCContainer.Resolve<IShoppingService>();
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
        private void FillInvoiceGrid()
        {
            grdShopping.DataSource = invoiceService.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCategoryGrid();
            FillProductGrid();
            FillCategoryCbb();
            FillInvoiceGrid();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (btnSaveCategory.Text == "kaydet")
            {
                int id = Convert.ToInt32(txtCategoryId.Text); //Textbox daki değerler default olarak string olduğu için int e çevirdik çünkü Create metodu id yi int bekliyor
                categoryService.Create(id, txtCategoryName.Text);
                Product alreadyRegistered=productService.GetAll().FirstOrDefault(x => x.Id == id);
                if (alreadyRegistered != null)
                {
                    MessageBox.Show($"{id} daha önce kaydedilmiş, lütfen yeni id değeri giriniz.");
                }
                
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
            FillCategoryCbb();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string categoryName = grdCategory.CurrentRow.Cells["Name"].Value.ToString();
            int categoryId = Convert.ToInt32(grdCategory.CurrentRow.Cells["Id"].Value);

            var data = productService.GetAll().Where(x => x.CategoryId == categoryId);
            string uyari = "";
            if (data.Count()> 0)
            {
                uyari = $"{categoryId} ve ona bağlı {data.Count()} adet ürün silinecektir.";
            }
            DialogResult result=MessageBox.Show($"{uyari} Devam etmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
           
            if (result == DialogResult.No)
                return;
            #region Ürün Silinmesi
            if (data.Count()> 0)
            {
                productService.DeleteProductsByCategory(categoryId);
                FillProductGrid();
            }
            #endregion



            #region Kategori Silinmesi
            bool x = categoryService.Delete(categoryId);
            FillCategoryGrid();
            FillCategoryCbb();
            #endregion

            txtProductId.Enabled = true;
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtProductStock.Text = "";
            cbbCategory.SelectedIndex = 0;

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
        {      //al butonu ile ürünü kaydederken satın almış da oluyoruz.
        
                int id = Convert.ToInt32(txtProductId.Text); //Textbox daki değerler default olarak string olduğu için int e çevirdik çünkü Create metodu id yi int bekliyor
                string name = txtProductName.Text;
                int stock = Convert.ToInt32(txtProductStock.Text);
                int selectedValue = Convert.ToInt32(cbbCategory.SelectedValue);
                decimal buyPrice= Convert.ToDecimal(txtProductBuyPrice.Text);
                decimal sellPrice = Convert.ToDecimal(txtProductSellPrice.Text);

                productService.Create(id,name,stock,selectedValue,buyPrice,sellPrice);
                shoppingService.BuyProduct(id, name, stock, buyPrice);

                FillProductGrid();
               
                txtProductId.Enabled = true;
                txtProductId.Text = "";
                txtProductName.Text = "";
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
            txtProductStock.Text = grdProduct.CurrentRow.Cells["Stock"].Value.ToString();
            txtProductBuyPrice.Text= grdProduct.CurrentRow.Cells["BuyPrice"].Value.ToString();
            txtProductSellPrice.Text = grdProduct.CurrentRow.Cells["SellPrice"].Value.ToString();
            txtProductId.Enabled = false;
           
        }
        private void satToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            txtProductBuyPrice.Text = "";
            cbbCategory.SelectedValue = "";
            int id = Convert.ToInt32(grdProduct.CurrentRow.Cells["Id"].Value);
            string name = grdProduct.CurrentRow.Cells["Name"].Value.ToString();
            int stock= Convert.ToInt32(grdProduct.CurrentRow.Cells["Stock"].Value);
            decimal sellPrice= Convert.ToDecimal(grdProduct.CurrentRow.Cells["SellPrice"].Value);
            shoppingService.SellProduct(id, name, stock, sellPrice);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            decimal balance = Convert.ToInt32(txtShowBalance.Text);
            cashService.ShowBalance();             

            FillInvoiceGrid();

            txtShowBalance.Text = "";
            


        }

        
    }
    }
    
