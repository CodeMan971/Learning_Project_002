﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StockTracking
{
    public partial class FrmDeleted : Form
    {
        public FrmDeleted()
        {
            InitializeComponent();
        }

        SalesDTO dto = new SalesDTO();
        SalesBLL bll = new SalesBLL();

        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cmbDeletedData.Items.Add("Category");
            cmbDeletedData.Items.Add("Customer");
            cmbDeletedData.Items.Add("Product");
            cmbDeletedData.Items.Add("Sales");

            dto = bll.Select(true); // Select deleted items records
            dataGridView1.DataSource = dto.Sales;
            dataGridView1.Columns[0].HeaderText = "Customer Name";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Category Name";
            dataGridView1.Columns[6].HeaderText = "Sales Amount";
            dataGridView1.Columns[7].HeaderText = "Price";
            dataGridView1.Columns[8].HeaderText = "Sales Date";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        CategoryDetailDTO categorydetail = new CategoryDetailDTO();
        CustomerDetailDTO customerdetail = new CustomerDetailDTO();
        ProductDetailDTO productdetail = new ProductDetailDTO();
        SalesDetailDTO salesdetail = new SalesDetailDTO();

        CategoryBLL categoryBLL = new CategoryBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        ProductBLL productBLL = new ProductBLL();
        SalesBLL salesBLL = new SalesBLL();

        private void cmbDeletedData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dto.Categories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Category Name";
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dto.Customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Customer Name";
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                dataGridView1.DataSource = dto.Products;
                dataGridView1.Columns[0].HeaderText = "Product Name";
                dataGridView1.Columns[1].HeaderText = "Category Name";
                dataGridView1.Columns[2].HeaderText = "Stock Amount";
                dataGridView1.Columns[3].HeaderText = "Price";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
            else
            {
                dataGridView1.DataSource = dto.Sales;
                dataGridView1.Columns[0].HeaderText = "Customer Name";
                dataGridView1.Columns[1].HeaderText = "Product Name";
                dataGridView1.Columns[2].HeaderText = "Category Name";
                dataGridView1.Columns[6].HeaderText = "Sales Amount";
                dataGridView1.Columns[7].HeaderText = "Price";
                dataGridView1.Columns[8].HeaderText = "Sales Date";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                categorydetail = new CategoryDetailDTO();
                categorydetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                categorydetail.CategoryName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                customerdetail = new CustomerDetailDTO();
                customerdetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                customerdetail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                productdetail = new ProductDetailDTO();
                productdetail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                productdetail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                productdetail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                productdetail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                productdetail.IsCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);

            }
            else
            {
                salesdetail = new SalesDetailDTO();
                salesdetail.SalesID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                salesdetail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                salesdetail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                salesdetail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                salesdetail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                salesdetail.SalesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                salesdetail.IsCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
                salesdetail.IsCustomerDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
                salesdetail.IsProductDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            }
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                if (categoryBLL.GetBack(categorydetail))
                {
                    MessageBox.Show("Category was Get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Categories;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                if (customerBLL.GetBack(customerdetail))
                {
                    MessageBox.Show("Customer was Get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Customers;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                if (productdetail.IsCategoryDeleted)
                    MessageBox.Show("Category was deleted. First, get back category");
                else if (productBLL.GetBack(productdetail))
                {
                    MessageBox.Show("Product was Get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Products;
                }
            }
            else
            {
                if (salesdetail.IsCategoryDeleted || salesdetail.IsCustomerDeleted || salesdetail.IsProductDeleted)
                { 
                    if(salesdetail.IsCategoryDeleted)
                        MessageBox.Show("Category was deleted. First, get back category");
                    else if (salesdetail.IsCustomerDeleted)
                        MessageBox.Show("Customer was deleted. First, get back customer");
                    else if (salesdetail.IsProductDeleted)
                        MessageBox.Show("Product was deleted. First, get back product");
                }
                else if (salesBLL.GetBack(salesdetail))
                {
                    MessageBox.Show("Sales was Get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Sales;
                }
            }
        }
    }
}
