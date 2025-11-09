
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TestAddIn
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        // initialize component
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.search = new System.Windows.Forms.TextBox();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.labelPRValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.personalInfoPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastOrdersTable = new System.Windows.Forms.DataGridView();
            this.lastOrderAnz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastOrderNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastOrderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastOrderSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastOrderExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastOrderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelKNR = new System.Windows.Forms.Label();
            this.knr = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.labelStr = new System.Windows.Forms.Label();
            this.str = new System.Windows.Forms.TextBox();
            this.labelOrt = new System.Windows.Forms.Label();
            this.ort = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.footerLabel1 = new System.Windows.Forms.Label();
            this.footerLabel2 = new System.Windows.Forms.Label();
            this.footerLabel3 = new System.Windows.Forms.Label();
            this.footerLabel4 = new System.Windows.Forms.Label();
            this.footerLabel5 = new System.Windows.Forms.Label();
            this.footerLabel6 = new System.Windows.Forms.Label();
            this.footerLabel7 = new System.Windows.Forms.Label();
            this.footerLabel8 = new System.Windows.Forms.Label();
            this.footerLabel9 = new System.Windows.Forms.Label();
            this.labelRabbat = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.labelSumValue = new System.Windows.Forms.Label();
            this.labelCountValue = new System.Windows.Forms.Label();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.labelLastDiscountValue = new System.Windows.Forms.Label();
            this.bannerPanel.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.personalInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lastOrdersTable)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.BackColor = System.Drawing.Color.MediumBlue;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.ForeColor = System.Drawing.Color.Yellow;
            this.search.Location = new System.Drawing.Point(1114, 53);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(308, 50);
            this.search.TabIndex = 0;
            this.search.Text = " ";
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // bannerPanel
            // 
            this.bannerPanel.BackColor = System.Drawing.Color.MediumBlue;
            this.bannerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bannerPanel.Controls.Add(this.labelPRValue);
            this.bannerPanel.Controls.Add(this.label7);
            this.bannerPanel.Controls.Add(this.labelDate);
            this.bannerPanel.Controls.Add(this.menuButton);
            this.bannerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bannerPanel.Location = new System.Drawing.Point(0, 0);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(1631, 50);
            this.bannerPanel.TabIndex = 1;
            // 
            // labelPRValue
            // 
            this.labelPRValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPRValue.AutoSize = true;
            this.labelPRValue.BackColor = System.Drawing.Color.MediumBlue;
            this.labelPRValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelPRValue.ForeColor = System.Drawing.Color.Cyan;
            this.labelPRValue.Location = new System.Drawing.Point(746, 7);
            this.labelPRValue.Name = "labelPRValue";
            this.labelPRValue.Size = new System.Drawing.Size(54, 31);
            this.labelPRValue.TabIndex = 16;
            this.labelPRValue.Text = "     ";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.MediumBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Cyan;
            this.label7.Location = new System.Drawing.Point(670, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 31);
            this.label7.TabIndex = 15;
            this.label7.Text = "PR = ";
            // 
            // labelDate
            // 
            this.labelDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDate.AutoSize = true;
            this.labelDate.BackColor = System.Drawing.Color.MediumBlue;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelDate.ForeColor = System.Drawing.Color.Cyan;
            this.labelDate.Location = new System.Drawing.Point(191, 7);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(374, 31);
            this.labelDate.TabIndex = 14;
            this.labelDate.Text = "                                             ";
            // 
            // menuButton
            // 
            this.menuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Location = new System.Drawing.Point(2583, 16);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(41, 23);
            this.menuButton.TabIndex = 1;
            this.menuButton.Text = "☰";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(121, 70);
            // 
            // menuItem1
            // 
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(120, 22);
            this.menuItem1.Text = "Option 1";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(120, 22);
            this.menuItem2.Text = "Option 2";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(120, 22);
            this.menuItem3.Text = "Option 3";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // personalInfoPanel
            // 
            this.personalInfoPanel.Controls.Add(this.label10);
            this.personalInfoPanel.Controls.Add(this.label1);
            this.personalInfoPanel.Controls.Add(this.labelLastDiscountValue);
            this.personalInfoPanel.Controls.Add(this.lastOrdersTable);
            this.personalInfoPanel.Controls.Add(this.textBoxDiscount);
            this.personalInfoPanel.Controls.Add(this.labelCountValue);
            this.personalInfoPanel.Controls.Add(this.labelSumValue);
            this.personalInfoPanel.Controls.Add(this.labelSum);
            this.personalInfoPanel.Controls.Add(this.labelCount);
            this.personalInfoPanel.Controls.Add(this.labelRabbat);
            this.personalInfoPanel.Controls.Add(this.labelKNR);
            this.personalInfoPanel.Controls.Add(this.knr);
            this.personalInfoPanel.Controls.Add(this.labelName);
            this.personalInfoPanel.Controls.Add(this.name);
            this.personalInfoPanel.Controls.Add(this.labelPhone);
            this.personalInfoPanel.Controls.Add(this.search);
            this.personalInfoPanel.Controls.Add(this.phone);
            this.personalInfoPanel.Controls.Add(this.labelStr);
            this.personalInfoPanel.Controls.Add(this.str);
            this.personalInfoPanel.Controls.Add(this.labelOrt);
            this.personalInfoPanel.Controls.Add(this.ort);
            this.personalInfoPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalInfoPanel.ForeColor = System.Drawing.Color.Yellow;
            this.personalInfoPanel.Location = new System.Drawing.Point(4, 50);
            this.personalInfoPanel.Name = "personalInfoPanel";
            this.personalInfoPanel.Size = new System.Drawing.Size(1615, 647);
            this.personalInfoPanel.TabIndex = 2;
            this.personalInfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.personalInfoPanel_Paint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(1225, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 31);
            this.label10.TabIndex = 25;
            this.label10.Text = "Suche";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(406, 534);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 36);
            this.label1.TabIndex = 24;
            this.label1.Text = "%";
            // 
            // lastOrdersTable
            // 
            this.lastOrdersTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Yellow;
            this.lastOrdersTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.lastOrdersTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lastOrdersTable.BackgroundColor = System.Drawing.Color.MediumBlue;
            this.lastOrdersTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastOrdersTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lastOrdersTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lastOrdersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lastOrdersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastOrderAnz,
            this.lastOrderNr,
            this.lastOrderName,
            this.lastOrderSize,
            this.lastOrderExtra,
            this.lastOrderPrice});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lastOrdersTable.DefaultCellStyle = dataGridViewCellStyle7;
            this.lastOrdersTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.lastOrdersTable.GridColor = System.Drawing.Color.MediumBlue;
            this.lastOrdersTable.Location = new System.Drawing.Point(181, 175);
            this.lastOrdersTable.Name = "lastOrdersTable";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lastOrdersTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.lastOrdersTable.RowHeadersVisible = false;
            this.lastOrdersTable.RowHeadersWidth = 5;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lastOrdersTable.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.lastOrdersTable.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastOrdersTable.RowTemplate.Height = 25;
            this.lastOrdersTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lastOrdersTable.Size = new System.Drawing.Size(1244, 330);
            this.lastOrdersTable.TabIndex = 16;
            this.lastOrdersTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lastOrderAnz
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow;
            this.lastOrderAnz.DefaultCellStyle = dataGridViewCellStyle3;
            this.lastOrderAnz.FillWeight = 7.793834F;
            this.lastOrderAnz.HeaderText = "Anz";
            this.lastOrderAnz.MaxInputLength = 3;
            this.lastOrderAnz.MinimumWidth = 10;
            this.lastOrderAnz.Name = "lastOrderAnz";
            this.lastOrderAnz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lastOrderNr
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.lastOrderNr.DefaultCellStyle = dataGridViewCellStyle4;
            this.lastOrderNr.FillWeight = 7.793834F;
            this.lastOrderNr.HeaderText = "Nr.";
            this.lastOrderNr.MaxInputLength = 3;
            this.lastOrderNr.Name = "lastOrderNr";
            // 
            // lastOrderName
            // 
            this.lastOrderName.FillWeight = 12F;
            this.lastOrderName.HeaderText = "Bez";
            this.lastOrderName.MaxInputLength = 100;
            this.lastOrderName.MinimumWidth = 10;
            this.lastOrderName.Name = "lastOrderName";
            // 
            // lastOrderSize
            // 
            this.lastOrderSize.FillWeight = 7.793834F;
            this.lastOrderSize.HeaderText = "S/J";
            this.lastOrderSize.MaxInputLength = 50;
            this.lastOrderSize.Name = "lastOrderSize";
            // 
            // lastOrderExtra
            // 
            dataGridViewCellStyle5.Format = "N0";
            this.lastOrderExtra.DefaultCellStyle = dataGridViewCellStyle5;
            this.lastOrderExtra.FillWeight = 18F;
            this.lastOrderExtra.HeaderText = "Extra";
            this.lastOrderExtra.MaxInputLength = 3;
            this.lastOrderExtra.Name = "lastOrderExtra";
            // 
            // lastOrderPrice
            // 
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.lastOrderPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.lastOrderPrice.FillWeight = 7.793834F;
            this.lastOrderPrice.HeaderText = "Preis";
            this.lastOrderPrice.MaxInputLength = 10;
            this.lastOrderPrice.Name = "lastOrderPrice";
            // 
            // labelKNR
            // 
            this.labelKNR.AutoSize = true;
            this.labelKNR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelKNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelKNR.ForeColor = System.Drawing.Color.Yellow;
            this.labelKNR.Location = new System.Drawing.Point(179, 0);
            this.labelKNR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKNR.Name = "labelKNR";
            this.labelKNR.Size = new System.Drawing.Size(74, 31);
            this.labelKNR.TabIndex = 0;
            this.labelKNR.Text = "K-Nr";
            // 
            // knr
            // 
            this.knr.BackColor = System.Drawing.Color.MediumBlue;
            this.knr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.knr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.knr.ForeColor = System.Drawing.Color.Yellow;
            this.knr.Location = new System.Drawing.Point(277, 3);
            this.knr.Margin = new System.Windows.Forms.Padding(2);
            this.knr.Name = "knr";
            this.knr.Size = new System.Drawing.Size(154, 31);
            this.knr.TabIndex = 1;
            this.knr.TextChanged += new System.EventHandler(this.knr_TextChanged);
            this.knr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.Yellow;
            this.labelName.Location = new System.Drawing.Point(446, 4);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(123, 31);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "  Name: ";
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.MediumBlue;
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.name.ForeColor = System.Drawing.Color.Yellow;
            this.name.Location = new System.Drawing.Point(584, 1);
            this.name.Margin = new System.Windows.Forms.Padding(2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(274, 31);
            this.name.TabIndex = 3;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelPhone.ForeColor = System.Drawing.Color.Yellow;
            this.labelPhone.Location = new System.Drawing.Point(875, 1);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(103, 31);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "   Tel   ";
            // 
            // phone
            // 
            this.phone.BackColor = System.Drawing.Color.MediumBlue;
            this.phone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.phone.ForeColor = System.Drawing.Color.Yellow;
            this.phone.Location = new System.Drawing.Point(996, 1);
            this.phone.Margin = new System.Windows.Forms.Padding(2);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(207, 31);
            this.phone.TabIndex = 5;
            this.phone.TextChanged += new System.EventHandler(this.phone_TextChanged);
            // 
            // labelStr
            // 
            this.labelStr.AutoSize = true;
            this.labelStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelStr.ForeColor = System.Drawing.Color.Yellow;
            this.labelStr.Location = new System.Drawing.Point(179, 40);
            this.labelStr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStr.Name = "labelStr";
            this.labelStr.Size = new System.Drawing.Size(77, 31);
            this.labelStr.TabIndex = 6;
            this.labelStr.Text = "Str.  ";
            // 
            // str
            // 
            this.str.BackColor = System.Drawing.Color.MediumBlue;
            this.str.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.str.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.str.ForeColor = System.Drawing.Color.Yellow;
            this.str.Location = new System.Drawing.Point(279, 40);
            this.str.Margin = new System.Windows.Forms.Padding(2);
            this.str.Name = "str";
            this.str.Size = new System.Drawing.Size(497, 31);
            this.str.TabIndex = 7;
            this.str.TextChanged += new System.EventHandler(this.str_TextChanged);
            // 
            // labelOrt
            // 
            this.labelOrt.AutoSize = true;
            this.labelOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelOrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelOrt.ForeColor = System.Drawing.Color.Yellow;
            this.labelOrt.Location = new System.Drawing.Point(179, 69);
            this.labelOrt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrt.Name = "labelOrt";
            this.labelOrt.Size = new System.Drawing.Size(79, 31);
            this.labelOrt.TabIndex = 8;
            this.labelOrt.Text = "Ort   ";
            // 
            // ort
            // 
            this.ort.BackColor = System.Drawing.Color.MediumBlue;
            this.ort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ort.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.ort.ForeColor = System.Drawing.Color.Yellow;
            this.ort.Location = new System.Drawing.Point(278, 69);
            this.ort.Margin = new System.Windows.Forms.Padding(2);
            this.ort.Name = "ort";
            this.ort.Size = new System.Drawing.Size(498, 31);
            this.ort.TabIndex = 9;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Cyan;
            this.footerPanel.Controls.Add(this.label8);
            this.footerPanel.Controls.Add(this.label9);
            this.footerPanel.Controls.Add(this.label5);
            this.footerPanel.Controls.Add(this.label6);
            this.footerPanel.Controls.Add(this.label3);
            this.footerPanel.Controls.Add(this.label4);
            this.footerPanel.Controls.Add(this.label2);
            this.footerPanel.Controls.Add(this.footerLabel1);
            this.footerPanel.Controls.Add(this.footerLabel2);
            this.footerPanel.Controls.Add(this.footerLabel3);
            this.footerPanel.Controls.Add(this.footerLabel4);
            this.footerPanel.Controls.Add(this.footerLabel5);
            this.footerPanel.Controls.Add(this.footerLabel6);
            this.footerPanel.Controls.Add(this.footerLabel7);
            this.footerPanel.Controls.Add(this.footerLabel8);
            this.footerPanel.Controls.Add(this.footerLabel9);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 893);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1631, 32);
            this.footerPanel.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Cyan;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(864, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 31);
            this.label8.TabIndex = 14;
            this.label8.Text = "F6:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Cyan;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(915, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 31);
            this.label9.TabIndex = 15;
            this.label9.Text = "Fahrer";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Cyan;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1417, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 31);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ende";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Cyan;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(1348, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "F10:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Cyan;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1244, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "druck";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Cyan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1190, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "F9:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Cyan;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1083, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "R.neu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // footerLabel1
            // 
            this.footerLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel1.AutoSize = true;
            this.footerLabel1.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel1.ForeColor = System.Drawing.Color.Red;
            this.footerLabel1.Location = new System.Drawing.Point(198, 0);
            this.footerLabel1.Name = "footerLabel1";
            this.footerLabel1.Size = new System.Drawing.Size(57, 31);
            this.footerLabel1.TabIndex = 0;
            this.footerLabel1.Text = "F1:";
            // 
            // footerLabel2
            // 
            this.footerLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel2.AutoSize = true;
            this.footerLabel2.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel2.ForeColor = System.Drawing.Color.Black;
            this.footerLabel2.Location = new System.Drawing.Point(254, 0);
            this.footerLabel2.Name = "footerLabel2";
            this.footerLabel2.Size = new System.Drawing.Size(95, 31);
            this.footerLabel2.TabIndex = 1;
            this.footerLabel2.Text = "B.Neu";
            // 
            // footerLabel3
            // 
            this.footerLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel3.AutoSize = true;
            this.footerLabel3.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel3.ForeColor = System.Drawing.Color.Red;
            this.footerLabel3.Location = new System.Drawing.Point(350, 0);
            this.footerLabel3.Name = "footerLabel3";
            this.footerLabel3.Size = new System.Drawing.Size(57, 31);
            this.footerLabel3.TabIndex = 2;
            this.footerLabel3.Text = "F2:";
            // 
            // footerLabel4
            // 
            this.footerLabel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel4.AutoSize = true;
            this.footerLabel4.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel4.ForeColor = System.Drawing.Color.Black;
            this.footerLabel4.Location = new System.Drawing.Point(406, 0);
            this.footerLabel4.Name = "footerLabel4";
            this.footerLabel4.Size = new System.Drawing.Size(96, 31);
            this.footerLabel4.TabIndex = 3;
            this.footerLabel4.Text = "Suche";
            // 
            // footerLabel5
            // 
            this.footerLabel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel5.AutoSize = true;
            this.footerLabel5.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel5.ForeColor = System.Drawing.Color.Red;
            this.footerLabel5.Location = new System.Drawing.Point(511, 0);
            this.footerLabel5.Name = "footerLabel5";
            this.footerLabel5.Size = new System.Drawing.Size(57, 31);
            this.footerLabel5.TabIndex = 4;
            this.footerLabel5.Text = "F3:";
            // 
            // footerLabel6
            // 
            this.footerLabel6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel6.AutoSize = true;
            this.footerLabel6.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel6.ForeColor = System.Drawing.Color.Black;
            this.footerLabel6.Location = new System.Drawing.Point(567, 0);
            this.footerLabel6.Name = "footerLabel6";
            this.footerLabel6.Size = new System.Drawing.Size(123, 31);
            this.footerLabel6.TabIndex = 5;
            this.footerLabel6.Text = "Anderen";
            // 
            // footerLabel7
            // 
            this.footerLabel7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel7.AutoSize = true;
            this.footerLabel7.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel7.ForeColor = System.Drawing.Color.Red;
            this.footerLabel7.Location = new System.Drawing.Point(711, 0);
            this.footerLabel7.Name = "footerLabel7";
            this.footerLabel7.Size = new System.Drawing.Size(57, 31);
            this.footerLabel7.TabIndex = 6;
            this.footerLabel7.Text = "F4:";
            // 
            // footerLabel8
            // 
            this.footerLabel8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel8.AutoSize = true;
            this.footerLabel8.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel8.ForeColor = System.Drawing.Color.Black;
            this.footerLabel8.Location = new System.Drawing.Point(764, 0);
            this.footerLabel8.Name = "footerLabel8";
            this.footerLabel8.Size = new System.Drawing.Size(85, 31);
            this.footerLabel8.TabIndex = 7;
            this.footerLabel8.Text = "R.OK";
            // 
            // footerLabel9
            // 
            this.footerLabel9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel9.AutoSize = true;
            this.footerLabel9.BackColor = System.Drawing.Color.Cyan;
            this.footerLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.footerLabel9.ForeColor = System.Drawing.Color.Red;
            this.footerLabel9.Location = new System.Drawing.Point(1033, 0);
            this.footerLabel9.Name = "footerLabel9";
            this.footerLabel9.Size = new System.Drawing.Size(57, 31);
            this.footerLabel9.TabIndex = 8;
            this.footerLabel9.Text = "F7:";
            // 
            // labelRabbat
            // 
            this.labelRabbat.AutoSize = true;
            this.labelRabbat.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelRabbat.ForeColor = System.Drawing.Color.Yellow;
            this.labelRabbat.Location = new System.Drawing.Point(276, 533);
            this.labelRabbat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRabbat.Name = "labelRabbat";
            this.labelRabbat.Size = new System.Drawing.Size(126, 36);
            this.labelRabbat.TabIndex = 16;
            this.labelRabbat.Text = "Rabbat:";
            this.labelRabbat.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelCount.ForeColor = System.Drawing.Color.Yellow;
            this.labelCount.Location = new System.Drawing.Point(733, 534);
            this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(80, 36);
            this.labelCount.TabIndex = 18;
            this.labelCount.Text = "Anz:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelSum.ForeColor = System.Drawing.Color.Yellow;
            this.labelSum.Location = new System.Drawing.Point(1054, 533);
            this.labelSum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(87, 36);
            this.labelSum.TabIndex = 19;
            this.labelSum.Text = "Sum:";
            // 
            // labelSumValue
            // 
            this.labelSumValue.AutoSize = true;
            this.labelSumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelSumValue.ForeColor = System.Drawing.Color.Lime;
            this.labelSumValue.Location = new System.Drawing.Point(1145, 533);
            this.labelSumValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSumValue.Name = "labelSumValue";
            this.labelSumValue.Size = new System.Drawing.Size(78, 36);
            this.labelSumValue.TabIndex = 20;
            this.labelSumValue.Text = "0.00";
            // 
            // labelCountValue
            // 
            this.labelCountValue.AutoSize = true;
            this.labelCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelCountValue.ForeColor = System.Drawing.Color.Lime;
            this.labelCountValue.Location = new System.Drawing.Point(864, 534);
            this.labelCountValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountValue.Name = "labelCountValue";
            this.labelCountValue.Size = new System.Drawing.Size(33, 36);
            this.labelCountValue.TabIndex = 21;
            this.labelCountValue.Text = "0";
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.BackColor = System.Drawing.Color.MediumBlue;
            this.textBoxDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDiscount.ForeColor = System.Drawing.Color.Lime;
            this.textBoxDiscount.Location = new System.Drawing.Point(465, 536);
            this.textBoxDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(60, 34);
            this.textBoxDiscount.TabIndex = 22;
            this.textBoxDiscount.Text = "0";
            this.textBoxDiscount.TextChanged += new System.EventHandler(this.textBoxDiscount_TextChanged);
            // 
            // labelLastDiscountValue
            // 
            this.labelLastDiscountValue.AutoSize = true;
            this.labelLastDiscountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelLastDiscountValue.ForeColor = System.Drawing.Color.Red;
            this.labelLastDiscountValue.Location = new System.Drawing.Point(534, 533);
            this.labelLastDiscountValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastDiscountValue.Name = "labelLastDiscountValue";
            this.labelLastDiscountValue.Size = new System.Drawing.Size(96, 36);
            this.labelLastDiscountValue.TabIndex = 23;
            this.labelLastDiscountValue.Text = "€0.00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.ClientSize = new System.Drawing.Size(1631, 925);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.personalInfoPanel);
            this.Controls.Add(this.bannerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Test AddIn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bannerPanel.ResumeLayout(false);
            this.bannerPanel.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.personalInfoPanel.ResumeLayout(false);
            this.personalInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lastOrdersTable)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItem3;
        private System.Windows.Forms.Panel personalInfoPanel;
        private System.Windows.Forms.Label labelKNR;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelStr;
        private System.Windows.Forms.Label labelOrt;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label footerLabel1;
        private System.Windows.Forms.Label footerLabel2;
        private System.Windows.Forms.Label footerLabel3;
        private System.Windows.Forms.Label footerLabel4;
        private System.Windows.Forms.Label footerLabel5;
        private System.Windows.Forms.Label footerLabel6;
        private System.Windows.Forms.Label footerLabel7;
        private System.Windows.Forms.Label footerLabel8;
        private System.Windows.Forms.Label footerLabel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox knr;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox str;
        private System.Windows.Forms.TextBox ort;
        private DataGridView lastOrdersTable;
        private Label label1;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label labelDate;
        private Label label7;
        private Label labelPRValue;
        private Label label8;
        private Label label9;
        private DataGridViewTextBoxColumn lastOrderAnz;
        private DataGridViewTextBoxColumn lastOrderNr;
        private DataGridViewTextBoxColumn lastOrderName;
        private DataGridViewTextBoxColumn lastOrderSize;
        private DataGridViewTextBoxColumn lastOrderExtra;
        private DataGridViewTextBoxColumn lastOrderPrice;
        private Label label10;
        private Label labelLastDiscountValue;
        private TextBox textBoxDiscount;
        private Label labelCountValue;
        private Label labelSumValue;
        private Label labelSum;
        private Label labelCount;
        private Label labelRabbat;
    }

    public class CreateOrderForm : UserControl
    {
        private readonly DataGridView dataGridView;
        private readonly Panel panelLastOrdersTable;
        private readonly TextBox textBoxCount;
        private readonly TextBox textBoxArticleNumber;
        private readonly TextBox textBoxCategory;
        private readonly TextBox textBoxExtra;
        private readonly TextBox textBoxPrice;
        private readonly Label lblRabbat;
        private readonly TextBox textRabbatValue;
        private readonly Label lblCount;
        private readonly Label lblTotal;
        private readonly Label lblCountValue;
        private readonly Label lblTotalValue;

        public bool KeyPreview { get; }

        private List<string[]> tempOrders; // Temporary storage for new orders

        // Centralized constants
        private static readonly Font DefaultTextBoxFont = new Font("Microsoft Sans Serif", 16F);
        private static readonly Font DefaultLabelFont = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
        private static readonly Font PanelFont = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
        private const int TextBoxHeight = 32;
        private const int ControlWidth = 1035;
        private const int PanelHeight = 112;
        private const int DataGridViewHeight = 100;
        private const int FormHeight = 300;

        

        public CreateOrderForm()
        {
            tempOrders = new List<string[]>();

            // Initialize controls
            dataGridView = new DataGridView();
            panelLastOrdersTable = new Panel();
            textBoxCount = new TextBox();
            textBoxArticleNumber = new TextBox();
            textBoxCategory = new TextBox();
            textBoxExtra = new TextBox();
            textBoxPrice = new TextBox();
            lblRabbat = new Label();
            textRabbatValue = new TextBox();
            lblCount = new Label();
            lblTotal = new Label();
            lblCountValue = new Label();
            lblTotalValue = new Label();

            // Set KeyPreview and attach KeyDown early
            KeyPreview = true;
            KeyDown += CreateOrderForm_KeyDown;
            System.Diagnostics.Debug.WriteLine("CreateOrderForm constructor: Attached CreateOrderForm_KeyDown at " + DateTime.Now);

            if (IsHandleCreated)
            {
                InitializeComponents();
            }
            else
            {
                HandleCreated += (s, e) => InitializeComponents();
            }
            if (!DesignMode)
            {
                MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
            System.Diagnostics.Debug.WriteLine("CreateOrderForm constructor called at " + DateTime.Now);
        }

        private void InitializeComponents()
        {
            // Initialize DataGridView
            ConfigureDataGridView(dataGridView, new Point(0, 0), new Size(ControlWidth, DataGridViewHeight));
            dataGridView.Columns.Add("KundeName", "Kunde Name");
            dataGridView.Columns.Add("KundeNr", "Kunde Nr.");
            dataGridView.Columns.Add("Anz", "Anz");
            dataGridView.Columns.Add("Nr", "Nr");
            dataGridView.Columns.Add("Bez", "Bez");
            dataGridView.Columns.Add("SJ1", "S/J");
            dataGridView.Columns.Add("Extra", "Extra");
            dataGridView.Columns.Add("Preis", "Preis");
            dataGridView.Columns.Add("Rabatt", "Rabatt");

            // Initialize panel
            ConfigurePanel(panelLastOrdersTable, new Point(0, 120), new Size(ControlWidth, PanelHeight));

            // Initialize TextBoxes with KeyDown events
            ConfigureTextBox(textBoxCount, "textBoxCount", new Point(2, 1), new Size(235, TextBoxHeight), 1, textBox1_TextChanged, TextBox_KeyDown);
            ConfigureTextBox(textBoxArticleNumber, "textBoxArticleNumber", new Point(260, 2), new Size(249, TextBoxHeight), 7, textBox4_TextChanged, TextBox_KeyDown);
            ConfigureTextBox(textBoxCategory, "textBoxCategory", new Point(536, 2), new Size(83, TextBoxHeight), 9, textBox5_TextChanged, TextBox_KeyDown);
            ConfigureTextBox(textBoxExtra, "textBoxExtra", new Point(652, 2), new Size(83, TextBoxHeight), 10, null, TextBox_KeyDown);
            ConfigureTextBox(textBoxPrice, "textBoxPrice", new Point(877, 2), new Size(83, TextBoxHeight), 11, null, TextBox_KeyDown);
            ConfigureTextBox(textRabbatValue, "textBoxRabbat", new Point(220, 240), new Size(83, TextBoxHeight), 12, null, TextBox_KeyDown);

            // Add TextBoxes to panel
            panelLastOrdersTable.Controls.AddRange(new Control[] { textBoxCount, textBoxArticleNumber, textBoxCategory, textBoxExtra, textBoxPrice });

            // Initialize Labels
            ConfigureLabel(lblRabbat, "Rabbat:", new Point(0, 240), Color.Yellow);
            ConfigureLabel(lblCount, "Count:", new Point(360, 240), Color.Yellow);
            ConfigureLabel(lblCountValue, "0", new Point(560, 240), Color.LightGreen);
            ConfigureLabel(lblTotal, "Sum:", new Point(720, 240), Color.Yellow);
            ConfigureLabel(lblTotalValue, "€0.00", new Point(920, 240), Color.LightGreen);

            // Add controls to UserControl
            Controls.AddRange(new Control[] { dataGridView, panelLastOrdersTable, lblRabbat, textRabbatValue, lblCount, lblCountValue, lblTotal, lblTotalValue });

            System.Diagnostics.Debug.WriteLine("InitializeComponents started at " + DateTime.Now);
            textBoxCount.Focus();
            System.Diagnostics.Debug.WriteLine("InitializeComponents: Initial focus set to textBoxCount at " + DateTime.Now);

            // Set UserControl size
            Size = new Size(ControlWidth, FormHeight);
            System.Diagnostics.Debug.WriteLine("InitializeComponents completed at " + DateTime.Now);

        }

        private void ConfigureDataGridView(DataGridView grid, Point location, Size size)
        {
            grid.Location = location;
            grid.Size = size;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
        }

        private void ConfigurePanel(Panel panel, Point location, Size size)
        {
            panel.Font = PanelFont;
            panel.ForeColor = Color.Yellow;
            panel.Location = location;
            panel.Name = "panelLastOrders";
            panel.Size = size;
            panel.TabIndex = 10;
        }

        private void ConfigureTextBox(TextBox textBox, string name, Point location, Size size, int tabIndex, EventHandler textChangedHandler, KeyEventHandler keyDownHandler)
        {
            textBox.Font = DefaultTextBoxFont;
            textBox.Location = location;
            textBox.Margin = new Padding(2);
            textBox.Name = name;
            textBox.Size = size;
            textBox.TabIndex = tabIndex;
            if (textChangedHandler != null)
            {
                textBox.TextChanged += textChangedHandler;
            }
            if (keyDownHandler != null)
            {
                textBox.KeyDown += keyDownHandler;
            }
        }

        private void ConfigureLabel(Label label, string text, Point location, Color foreColor)
        {
            label.Text = text;
            label.Location = location;
            label.ForeColor = foreColor;
            label.Font = DefaultLabelFont;
            label.AutoSize = true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox current = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent beep
                if (current == textRabbatValue)
                {
                    SubmitForm();
                }
                else
                {
                    SelectNextControl(current, true, true, true, true);
                }
            }
            else if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(current.Text))
            {
                e.SuppressKeyPress = true; // Navigate only if textbox is empty
                SelectNextControl(current, false, true, true, true);
            }
        }

        private void CreateOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("test " + e.KeyCode, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (e.KeyCode == Keys.F2 && ActiveControl == textRabbatValue)
            {
                e.SuppressKeyPress = true;
                SaveOrders();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            System.Diagnostics.Debug.WriteLine($"ProcessCmdKey: Key {keyData} pressed at {DateTime.Now}");
            if (keyData == Keys.F3 && tempOrders.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine($"ProcessCmdKey: Calling SaveOrders for F3 at {DateTime.Now}");
                SaveOrders();
                return true; // Indicate key was handled
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void SubmitForm()
        {
            // Store form data in tempOrders
            string[] order = new string[]
            {
            "Customer", // KundeName (placeholder)
            "0",     // KundeNr
            textBoxCount.Text,
            textBoxArticleNumber.Text,
            textBoxCategory.Text,
            "",        // SJ1 (placeholder)
            textBoxExtra.Text,
            textBoxPrice.Text,
            textRabbatValue.Text
            };
            tempOrders.Add(order);

            // Update DataGridView
            dataGridView.Rows.Clear();
            foreach (var ord in tempOrders)
            {
                dataGridView.Rows.Add(ord);
            }

            // Update count and total
            lblCountValue.Text = tempOrders.Count.ToString();
            decimal total = 0;
            foreach (var ord in tempOrders)
            {
                if (decimal.TryParse(ord[7], out decimal price) && decimal.TryParse(ord[2], out decimal count))
                {
                    decimal discount = decimal.TryParse(ord[8], out decimal rabatt) ? rabatt : 0;
                    total += (price * count) * (1 - discount / 100);
                }
            }
            lblTotalValue.Text = $"€{total:F2}";

            // Reset form and focus on first field
            textBoxCount.Text = "";
            textBoxArticleNumber.Text = "";
            textBoxCategory.Text = "";
            textBoxExtra.Text = "";
            textBoxPrice.Text = "";
            textRabbatValue.Text = "";
            textBoxCount.Focus();
        }

        private void SaveOrders()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "orders.txt");
                List<string> lines = File.Exists(filePath) ? new List<string>(File.ReadAllLines(filePath)) : new List<string>();

                // Add header if file is empty
                if (lines.Count == 0)
                {
                    lines.Add("Kunde Name\tKunde Nr.\tAnz\tNr\tBez\tS/J\tExtra\tPreis\tRabatt");
                }

                // Append new orders
                foreach (var order in tempOrders)
                {
                    lines.Add(string.Join("\t", order));
                }

                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Orders saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear temporary storage and reset form
                tempOrders.Clear();
                dataGridView.Rows.Clear();
                LoadSampleData();
                textBoxCount.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Orders not saved!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Error saving orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSampleData()
        {
            if (!DesignMode)
            {
                if (dataGridView.IsHandleCreated)
                {
                    AddSampleRows();
                }
                else
                {
                    dataGridView.HandleCreated += (s, e) => AddSampleRows();
                }
            }
        }

        private void AddSampleRows()
        {
            string filePath = Path.Combine(Application.StartupPath, "orders.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("orders.txt not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                dataGridView.Rows.Clear();
                string[] lines = File.ReadAllLines(filePath);
                string getCustomerNumber = "812";

                int startLine = lines.Length > 0 && lines[0].Contains("Kunde Name") ? 1 : 0;

                for (int i = startLine; i < lines.Length; i++)
                {
                    string[] columns = Regex.Split(lines[i].Trim(), @"\t|\s{2,}");
                    if (columns.Length >= 9 && columns[1].Trim() == getCustomerNumber)
                    {
                        string bez = string.Join(" ", columns.Skip(4).Take(columns.Length - 8));
                        dataGridView.Rows.Add(
                            columns[0].Trim(),
                            columns[1].Trim(),
                            columns[2].Trim(),
                            columns[3].Trim(),
                            bez,
                            columns[columns.Length - 4].Trim(),
                            columns[columns.Length - 3].Trim(),
                            columns[columns.Length - 2].Trim(),
                            columns[columns.Length - 1].Trim()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                LoadSampleData();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DefaultTextBoxFont?.Dispose();
                DefaultLabelFont?.Dispose();
                PanelFont?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Add logic for textBoxCount TextChanged event if needed
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Add logic for textBoxArticleNumber TextChanged event if needed
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Add logic for textBoxCategory TextChanged event if needed
        }
        private void TextBoxRabbatValue_KeyPress(object sender, KeyPressEventArgs e)
         {
           if (e.KeyChar == (char) Keys.Enter)
              {
                   e.Handled = true; // Prevent beep
                    SubmitForm();
                }
         }
    }
}

