
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            search = new TextBox();
            bannerPanel = new Panel();
            btnMenu = new Button();
            labelPRValue = new Label();
            label7 = new Label();
            labelDate = new Label();
            menuButton = new Button();
            contextMenu = new ContextMenuStrip(components);
            menuItem1 = new ToolStripMenuItem();
            menuItem2 = new ToolStripMenuItem();
            menuItem3 = new ToolStripMenuItem();
            personalInfoPanel = new Panel();
            label10 = new Label();
            label1 = new Label();
            labelLastDiscountValue = new Label();
            lastOrdersTable = new DataGridView();
            lastOrderAnz = new DataGridViewTextBoxColumn();
            lastOrderNr = new DataGridViewTextBoxColumn();
            lastOrderName = new DataGridViewTextBoxColumn();
            lastOrderSize = new DataGridViewTextBoxColumn();
            lastOrderExtra = new DataGridViewTextBoxColumn();
            lastOrderPrice = new DataGridViewTextBoxColumn();
            textBoxDiscount = new TextBox();
            labelCountValue = new Label();
            labelSumValue = new Label();
            labelSum = new Label();
            labelCount = new Label();
            labelRabbat = new Label();
            labelKNR = new Label();
            knr = new TextBox();
            labelName = new Label();
            name = new TextBox();
            labelPhone = new Label();
            phone = new TextBox();
            labelStr = new Label();
            str = new TextBox();
            labelOrt = new Label();
            ort = new TextBox();
            footerPanel = new Panel();
            label8 = new Label();
            label9 = new Label();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            footerLabel1 = new Label();
            footerLabel2 = new Label();
            footerLabel3 = new Label();
            footerLabel4 = new Label();
            footerLabel5 = new Label();
            footerLabel6 = new Label();
            footerLabel7 = new Label();
            footerLabel8 = new Label();
            footerLabel9 = new Label();
            bannerPanel.SuspendLayout();
            contextMenu.SuspendLayout();
            personalInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lastOrdersTable).BeginInit();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // search
            // 
            search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            search.BackColor = Color.MediumBlue;
            search.Font = new Font("Microsoft Sans Serif", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            search.ForeColor = Color.Yellow;
            search.Location = new Point(1300, 61);
            search.Margin = new Padding(4, 3, 4, 3);
            search.Name = "search";
            search.Size = new Size(359, 50);
            search.TabIndex = 0;
            search.TextChanged += search_TextChanged;
            search.KeyDown += search_KeyDown;
            // 
            // bannerPanel
            // 
            bannerPanel.BackColor = Color.MediumBlue;
            bannerPanel.BorderStyle = BorderStyle.Fixed3D;
            bannerPanel.Controls.Add(btnMenu);
            bannerPanel.Controls.Add(labelPRValue);
            bannerPanel.Controls.Add(label7);
            bannerPanel.Controls.Add(labelDate);
            bannerPanel.Controls.Add(menuButton);
            bannerPanel.Dock = DockStyle.Top;
            bannerPanel.Location = new Point(0, 0);
            bannerPanel.Margin = new Padding(4, 3, 4, 3);
            bannerPanel.Name = "bannerPanel";
            bannerPanel.Size = new Size(1903, 57);
            bannerPanel.TabIndex = 1;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.White;
            btnMenu.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.Black;
            btnMenu.Location = new Point(1651, 14);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(110, 32);
            btnMenu.TabIndex = 17;
            btnMenu.Text = "Meneu";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += button1_Click;
            btnMenu.MouseLeave += mouse_leave;
            btnMenu.MouseHover += mouse_enter;
            // 
            // labelPRValue
            // 
            labelPRValue.Anchor = AnchorStyles.Left;
            labelPRValue.AutoSize = true;
            labelPRValue.BackColor = Color.FromArgb(192, 0, 192);
            labelPRValue.BorderStyle = BorderStyle.Fixed3D;
            labelPRValue.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPRValue.ForeColor = Color.Cyan;
            labelPRValue.Location = new Point(870, 8);
            labelPRValue.Name = "labelPRValue";
            labelPRValue.Padding = new Padding(10, 0, 12, 0);
            labelPRValue.Size = new Size(58, 39);
            labelPRValue.TabIndex = 16;
            labelPRValue.Text = "1";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.BackColor = Color.MediumBlue;
            label7.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label7.ForeColor = Color.Cyan;
            label7.Location = new Point(782, 9);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(87, 31);
            label7.TabIndex = 15;
            label7.Text = "PR = ";
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.Left;
            labelDate.AutoSize = true;
            labelDate.BackColor = Color.MediumBlue;
            labelDate.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            labelDate.ForeColor = Color.Cyan;
            labelDate.Location = new Point(223, 8);
            labelDate.Margin = new Padding(4, 0, 4, 0);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(374, 31);
            labelDate.TabIndex = 14;
            labelDate.Text = "                                             ";
            // 
            // menuButton
            // 
            menuButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            menuButton.FlatStyle = FlatStyle.Flat;
            menuButton.ForeColor = Color.White;
            menuButton.Location = new Point(3015, 18);
            menuButton.Margin = new Padding(4, 3, 4, 3);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(48, 27);
            menuButton.TabIndex = 1;
            menuButton.Text = "☰";
            menuButton.UseVisualStyleBackColor = true;
            menuButton.Click += menuButton_Click;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(24, 24);
            contextMenu.Items.AddRange(new ToolStripItem[] { menuItem1, menuItem2, menuItem3 });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(121, 70);
            // 
            // menuItem1
            // 
            menuItem1.Name = "menuItem1";
            menuItem1.Size = new Size(120, 22);
            menuItem1.Text = "Option 1";
            menuItem1.Click += menuItem1_Click;
            // 
            // menuItem2
            // 
            menuItem2.Name = "menuItem2";
            menuItem2.Size = new Size(120, 22);
            menuItem2.Text = "Option 2";
            menuItem2.Click += menuItem2_Click;
            // 
            // menuItem3
            // 
            menuItem3.Name = "menuItem3";
            menuItem3.Size = new Size(120, 22);
            menuItem3.Text = "Option 3";
            menuItem3.Click += menuItem3_Click;
            // 
            // personalInfoPanel
            // 
            personalInfoPanel.Controls.Add(label10);
            personalInfoPanel.Controls.Add(label1);
            personalInfoPanel.Controls.Add(labelLastDiscountValue);
            personalInfoPanel.Controls.Add(lastOrdersTable);
            personalInfoPanel.Controls.Add(textBoxDiscount);
            personalInfoPanel.Controls.Add(labelCountValue);
            personalInfoPanel.Controls.Add(labelSumValue);
            personalInfoPanel.Controls.Add(labelSum);
            personalInfoPanel.Controls.Add(labelCount);
            personalInfoPanel.Controls.Add(labelRabbat);
            personalInfoPanel.Controls.Add(labelKNR);
            personalInfoPanel.Controls.Add(knr);
            personalInfoPanel.Controls.Add(labelName);
            personalInfoPanel.Controls.Add(name);
            personalInfoPanel.Controls.Add(labelPhone);
            personalInfoPanel.Controls.Add(search);
            personalInfoPanel.Controls.Add(phone);
            personalInfoPanel.Controls.Add(labelStr);
            personalInfoPanel.Controls.Add(str);
            personalInfoPanel.Controls.Add(labelOrt);
            personalInfoPanel.Controls.Add(ort);
            personalInfoPanel.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            personalInfoPanel.ForeColor = Color.Yellow;
            personalInfoPanel.Location = new Point(5, 58);
            personalInfoPanel.Margin = new Padding(4, 3, 4, 3);
            personalInfoPanel.Name = "personalInfoPanel";
            personalInfoPanel.Size = new Size(1884, 832);
            personalInfoPanel.TabIndex = 2;
            personalInfoPanel.Paint += personalInfoPanel_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Yellow;
            label10.Location = new Point(1429, 43);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(96, 31);
            label10.TabIndex = 25;
            label10.Text = "Suche";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(474, 749);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 36);
            label1.TabIndex = 24;
            label1.Text = "%";
            // 
            // labelLastDiscountValue
            // 
            labelLastDiscountValue.AutoSize = true;
            labelLastDiscountValue.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            labelLastDiscountValue.ForeColor = Color.Red;
            labelLastDiscountValue.Location = new Point(623, 748);
            labelLastDiscountValue.Margin = new Padding(2, 0, 2, 0);
            labelLastDiscountValue.Name = "labelLastDiscountValue";
            labelLastDiscountValue.Size = new Size(96, 36);
            labelLastDiscountValue.TabIndex = 23;
            labelLastDiscountValue.Text = "€0.00";
            // 
            // lastOrdersTable
            // 
            lastOrdersTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.MediumBlue;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = Color.MediumBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.Yellow;
            lastOrdersTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            lastOrdersTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lastOrdersTable.BackgroundColor = Color.MediumBlue;
            lastOrdersTable.BorderStyle = BorderStyle.None;
            lastOrdersTable.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.MediumBlue;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            lastOrdersTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            lastOrdersTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            lastOrdersTable.Columns.AddRange(new DataGridViewColumn[] { lastOrderAnz, lastOrderNr, lastOrderName, lastOrderSize, lastOrderExtra, lastOrderPrice });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.MediumBlue;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Yellow;
            dataGridViewCellStyle7.SelectionBackColor = Color.MediumBlue;
            dataGridViewCellStyle7.SelectionForeColor = Color.Yellow;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            lastOrdersTable.DefaultCellStyle = dataGridViewCellStyle7;
            lastOrdersTable.EditMode = DataGridViewEditMode.EditOnEnter;
            lastOrdersTable.GridColor = Color.MediumBlue;
            lastOrdersTable.Location = new Point(211, 202);
            lastOrdersTable.Margin = new Padding(4, 3, 4, 3);
            lastOrdersTable.Name = "lastOrdersTable";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.MediumBlue;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Yellow;
            dataGridViewCellStyle8.SelectionBackColor = Color.MediumBlue;
            dataGridViewCellStyle8.SelectionForeColor = Color.Yellow;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            lastOrdersTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            lastOrdersTable.RowHeadersVisible = false;
            lastOrdersTable.RowHeadersWidth = 5;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            lastOrdersTable.RowsDefaultCellStyle = dataGridViewCellStyle9;
            lastOrdersTable.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastOrdersTable.ScrollBars = ScrollBars.None;
            lastOrdersTable.Size = new Size(1451, 381);
            lastOrdersTable.TabIndex = 16;
            lastOrdersTable.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lastOrderAnz
            // 
            dataGridViewCellStyle3.BackColor = Color.MediumBlue;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Yellow;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.Padding = new Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = Color.MediumBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Yellow;
            lastOrderAnz.DefaultCellStyle = dataGridViewCellStyle3;
            lastOrderAnz.FillWeight = 7.793834F;
            lastOrderAnz.HeaderText = "Anz";
            lastOrderAnz.MaxInputLength = 100;
            lastOrderAnz.MinimumWidth = 10;
            lastOrderAnz.Name = "lastOrderAnz";
            lastOrderAnz.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // lastOrderNr
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            lastOrderNr.DefaultCellStyle = dataGridViewCellStyle4;
            lastOrderNr.FillWeight = 7.793834F;
            lastOrderNr.HeaderText = "Nr.";
            lastOrderNr.MaxInputLength = 3;
            lastOrderNr.Name = "lastOrderNr";
            // 
            // lastOrderName
            // 
            lastOrderName.FillWeight = 12F;
            lastOrderName.HeaderText = "Bez";
            lastOrderName.MaxInputLength = 100;
            lastOrderName.MinimumWidth = 10;
            lastOrderName.Name = "lastOrderName";
            // 
            // lastOrderSize
            // 
            lastOrderSize.FillWeight = 7.793834F;
            lastOrderSize.HeaderText = "S/J";
            lastOrderSize.MaxInputLength = 50;
            lastOrderSize.Name = "lastOrderSize";
            // 
            // lastOrderExtra
            // 
            dataGridViewCellStyle5.Format = "N0";
            lastOrderExtra.DefaultCellStyle = dataGridViewCellStyle5;
            lastOrderExtra.FillWeight = 18F;
            lastOrderExtra.HeaderText = "Extra";
            lastOrderExtra.MaxInputLength = 100;
            lastOrderExtra.MinimumWidth = 100;
            lastOrderExtra.Name = "lastOrderExtra";
            // 
            // lastOrderPrice
            // 
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            lastOrderPrice.DefaultCellStyle = dataGridViewCellStyle6;
            lastOrderPrice.FillWeight = 7.793834F;
            lastOrderPrice.HeaderText = "Preis";
            lastOrderPrice.MaxInputLength = 10;
            lastOrderPrice.Name = "lastOrderPrice";
            // 
            // textBoxDiscount
            // 
            textBoxDiscount.BackColor = Color.MediumBlue;
            textBoxDiscount.BorderStyle = BorderStyle.None;
            textBoxDiscount.Cursor = Cursors.IBeam;
            textBoxDiscount.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxDiscount.ForeColor = Color.Lime;
            textBoxDiscount.Location = new Point(542, 751);
            textBoxDiscount.Margin = new Padding(2);
            textBoxDiscount.Name = "textBoxDiscount";
            textBoxDiscount.Size = new Size(70, 34);
            textBoxDiscount.TabIndex = 22;
            textBoxDiscount.Text = "0";
            textBoxDiscount.TextChanged += textBoxDiscount_TextChanged;
            textBoxDiscount.KeyDown += hanle_keys;
            // 
            // labelCountValue
            // 
            labelCountValue.AutoSize = true;
            labelCountValue.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            labelCountValue.ForeColor = Color.Lime;
            labelCountValue.Location = new Point(1008, 749);
            labelCountValue.Margin = new Padding(2, 0, 2, 0);
            labelCountValue.Name = "labelCountValue";
            labelCountValue.Size = new Size(33, 36);
            labelCountValue.TabIndex = 21;
            labelCountValue.Text = "0";
            // 
            // labelSumValue
            // 
            labelSumValue.AutoSize = true;
            labelSumValue.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            labelSumValue.ForeColor = Color.Lime;
            labelSumValue.Location = new Point(1336, 748);
            labelSumValue.Margin = new Padding(2, 0, 2, 0);
            labelSumValue.Name = "labelSumValue";
            labelSumValue.Size = new Size(78, 36);
            labelSumValue.TabIndex = 20;
            labelSumValue.Text = "0.00";
            // 
            // labelSum
            // 
            labelSum.AutoSize = true;
            labelSum.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            labelSum.ForeColor = Color.Yellow;
            labelSum.Location = new Point(1230, 748);
            labelSum.Margin = new Padding(2, 0, 2, 0);
            labelSum.Name = "labelSum";
            labelSum.Size = new Size(87, 36);
            labelSum.TabIndex = 19;
            labelSum.Text = "Sum:";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            labelCount.ForeColor = Color.Yellow;
            labelCount.Location = new Point(855, 749);
            labelCount.Margin = new Padding(2, 0, 2, 0);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(80, 36);
            labelCount.TabIndex = 18;
            labelCount.Text = "Anz:";
            // 
            // labelRabbat
            // 
            labelRabbat.AutoSize = true;
            labelRabbat.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            labelRabbat.ForeColor = Color.Yellow;
            labelRabbat.Location = new Point(322, 748);
            labelRabbat.Margin = new Padding(2, 0, 2, 0);
            labelRabbat.Name = "labelRabbat";
            labelRabbat.Size = new Size(126, 36);
            labelRabbat.TabIndex = 16;
            labelRabbat.Text = "Rabbat:";
            labelRabbat.Click += label1_Click_2;
            // 
            // labelKNR
            // 
            labelKNR.AutoSize = true;
            labelKNR.BackColor = Color.FromArgb(192, 0, 192);
            labelKNR.BorderStyle = BorderStyle.Fixed3D;
            labelKNR.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            labelKNR.ForeColor = Color.Yellow;
            labelKNR.Location = new Point(209, 0);
            labelKNR.Margin = new Padding(2, 0, 2, 0);
            labelKNR.Name = "labelKNR";
            labelKNR.Size = new Size(76, 33);
            labelKNR.TabIndex = 0;
            labelKNR.Text = "K-Nr";
            // 
            // knr
            // 
            knr.BackColor = Color.MediumBlue;
            knr.BorderStyle = BorderStyle.None;
            knr.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            knr.ForeColor = Color.Yellow;
            knr.Location = new Point(323, 3);
            knr.Margin = new Padding(2);
            knr.Name = "knr";
            knr.Size = new Size(180, 31);
            knr.TabIndex = 1;
            knr.TextChanged += knr_TextChanged;
            knr.KeyDown += Input_KeyDown;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = Color.FromArgb(192, 0, 192);
            labelName.BorderStyle = BorderStyle.Fixed3D;
            labelName.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            labelName.ForeColor = Color.Yellow;
            labelName.Location = new Point(520, 5);
            labelName.Margin = new Padding(2, 0, 2, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(125, 33);
            labelName.TabIndex = 2;
            labelName.Text = "  Name: ";
            // 
            // name
            // 
            name.BackColor = Color.MediumBlue;
            name.BorderStyle = BorderStyle.None;
            name.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            name.ForeColor = Color.Yellow;
            name.Location = new Point(681, 1);
            name.Margin = new Padding(2);
            name.Name = "name";
            name.Size = new Size(320, 31);
            name.TabIndex = 3;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.BackColor = Color.FromArgb(192, 0, 192);
            labelPhone.BorderStyle = BorderStyle.Fixed3D;
            labelPhone.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            labelPhone.ForeColor = Color.Yellow;
            labelPhone.Location = new Point(1128, 1);
            labelPhone.Margin = new Padding(2, 0, 2, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(105, 33);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "   Tel   ";
            // 
            // phone
            // 
            phone.BackColor = Color.MediumBlue;
            phone.BorderStyle = BorderStyle.None;
            phone.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            phone.ForeColor = Color.Yellow;
            phone.Location = new Point(1269, 1);
            phone.Margin = new Padding(2);
            phone.Name = "phone";
            phone.Size = new Size(241, 31);
            phone.TabIndex = 5;
            phone.TextChanged += phone_TextChanged;
            // 
            // labelStr
            // 
            labelStr.AutoSize = true;
            labelStr.BackColor = Color.FromArgb(192, 0, 192);
            labelStr.BorderStyle = BorderStyle.Fixed3D;
            labelStr.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            labelStr.ForeColor = Color.Yellow;
            labelStr.Location = new Point(209, 46);
            labelStr.Margin = new Padding(2, 0, 2, 0);
            labelStr.Name = "labelStr";
            labelStr.Size = new Size(79, 33);
            labelStr.TabIndex = 6;
            labelStr.Text = "Str.  ";
            // 
            // str
            // 
            str.BackColor = Color.MediumBlue;
            str.BorderStyle = BorderStyle.None;
            str.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            str.ForeColor = Color.Yellow;
            str.Location = new Point(326, 46);
            str.Margin = new Padding(2);
            str.Name = "str";
            str.Size = new Size(580, 31);
            str.TabIndex = 7;
            str.TextChanged += str_TextChanged;
            // 
            // labelOrt
            // 
            labelOrt.AutoSize = true;
            labelOrt.BackColor = Color.FromArgb(192, 0, 192);
            labelOrt.BorderStyle = BorderStyle.Fixed3D;
            labelOrt.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            labelOrt.ForeColor = Color.Yellow;
            labelOrt.Location = new Point(209, 80);
            labelOrt.Margin = new Padding(2, 0, 2, 0);
            labelOrt.Name = "labelOrt";
            labelOrt.Size = new Size(81, 33);
            labelOrt.TabIndex = 8;
            labelOrt.Text = "Ort   ";
            // 
            // ort
            // 
            ort.BackColor = Color.MediumBlue;
            ort.BorderStyle = BorderStyle.None;
            ort.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            ort.ForeColor = Color.Yellow;
            ort.Location = new Point(324, 80);
            ort.Margin = new Padding(2);
            ort.Name = "ort";
            ort.Size = new Size(581, 31);
            ort.TabIndex = 9;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.Cyan;
            footerPanel.Controls.Add(label8);
            footerPanel.Controls.Add(label9);
            footerPanel.Controls.Add(label5);
            footerPanel.Controls.Add(label6);
            footerPanel.Controls.Add(label3);
            footerPanel.Controls.Add(label4);
            footerPanel.Controls.Add(label2);
            footerPanel.Controls.Add(footerLabel1);
            footerPanel.Controls.Add(footerLabel2);
            footerPanel.Controls.Add(footerLabel3);
            footerPanel.Controls.Add(footerLabel4);
            footerPanel.Controls.Add(footerLabel5);
            footerPanel.Controls.Add(footerLabel6);
            footerPanel.Controls.Add(footerLabel7);
            footerPanel.Controls.Add(footerLabel8);
            footerPanel.Controls.Add(footerLabel9);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(0, 1024);
            footerPanel.Margin = new Padding(4, 3, 4, 3);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(1903, 37);
            footerPanel.TabIndex = 4;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.BackColor = Color.Cyan;
            label8.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(1008, 1);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(57, 31);
            label8.TabIndex = 14;
            label8.Text = "F6:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.BackColor = Color.Cyan;
            label9.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(1068, 1);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(100, 31);
            label9.TabIndex = 15;
            label9.Text = "Fahrer";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.BackColor = Color.Cyan;
            label5.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(1653, 1);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(81, 31);
            label5.TabIndex = 13;
            label5.Text = "Ende";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.BackColor = Color.Cyan;
            label6.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(1573, 1);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(73, 31);
            label6.TabIndex = 12;
            label6.Text = "F10:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Cyan;
            label3.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(1451, 1);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 31);
            label3.TabIndex = 11;
            label3.Text = "druck";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.BackColor = Color.Cyan;
            label4.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(1388, 1);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(57, 31);
            label4.TabIndex = 10;
            label4.Text = "F9:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Cyan;
            label2.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(1264, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 31);
            label2.TabIndex = 9;
            label2.Text = "R.neu";
            label2.Click += label2_Click;
            // 
            // footerLabel1
            // 
            footerLabel1.Anchor = AnchorStyles.Left;
            footerLabel1.AutoSize = true;
            footerLabel1.BackColor = Color.Cyan;
            footerLabel1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel1.ForeColor = Color.Red;
            footerLabel1.Location = new Point(231, 0);
            footerLabel1.Margin = new Padding(4, 0, 4, 0);
            footerLabel1.Name = "footerLabel1";
            footerLabel1.Size = new Size(57, 31);
            footerLabel1.TabIndex = 0;
            footerLabel1.Text = "F1:";
            // 
            // footerLabel2
            // 
            footerLabel2.Anchor = AnchorStyles.Left;
            footerLabel2.AutoSize = true;
            footerLabel2.BackColor = Color.Cyan;
            footerLabel2.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel2.ForeColor = Color.Black;
            footerLabel2.Location = new Point(296, 0);
            footerLabel2.Margin = new Padding(4, 0, 4, 0);
            footerLabel2.Name = "footerLabel2";
            footerLabel2.Size = new Size(95, 31);
            footerLabel2.TabIndex = 1;
            footerLabel2.Text = "B.Neu";
            // 
            // footerLabel3
            // 
            footerLabel3.Anchor = AnchorStyles.Left;
            footerLabel3.AutoSize = true;
            footerLabel3.BackColor = Color.Cyan;
            footerLabel3.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel3.ForeColor = Color.Red;
            footerLabel3.Location = new Point(408, 0);
            footerLabel3.Margin = new Padding(4, 0, 4, 0);
            footerLabel3.Name = "footerLabel3";
            footerLabel3.Size = new Size(57, 31);
            footerLabel3.TabIndex = 2;
            footerLabel3.Text = "F2:";
            // 
            // footerLabel4
            // 
            footerLabel4.Anchor = AnchorStyles.Left;
            footerLabel4.AutoSize = true;
            footerLabel4.BackColor = Color.Cyan;
            footerLabel4.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel4.ForeColor = Color.Black;
            footerLabel4.Location = new Point(474, 0);
            footerLabel4.Margin = new Padding(4, 0, 4, 0);
            footerLabel4.Name = "footerLabel4";
            footerLabel4.Size = new Size(96, 31);
            footerLabel4.TabIndex = 3;
            footerLabel4.Text = "Suche";
            // 
            // footerLabel5
            // 
            footerLabel5.Anchor = AnchorStyles.Left;
            footerLabel5.AutoSize = true;
            footerLabel5.BackColor = Color.Cyan;
            footerLabel5.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel5.ForeColor = Color.Red;
            footerLabel5.Location = new Point(596, 0);
            footerLabel5.Margin = new Padding(4, 0, 4, 0);
            footerLabel5.Name = "footerLabel5";
            footerLabel5.Size = new Size(57, 31);
            footerLabel5.TabIndex = 4;
            footerLabel5.Text = "F3:";
            // 
            // footerLabel6
            // 
            footerLabel6.Anchor = AnchorStyles.Left;
            footerLabel6.AutoSize = true;
            footerLabel6.BackColor = Color.Cyan;
            footerLabel6.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel6.ForeColor = Color.Black;
            footerLabel6.Location = new Point(662, 0);
            footerLabel6.Margin = new Padding(4, 0, 4, 0);
            footerLabel6.Name = "footerLabel6";
            footerLabel6.Size = new Size(123, 31);
            footerLabel6.TabIndex = 5;
            footerLabel6.Text = "Anderen";
            // 
            // footerLabel7
            // 
            footerLabel7.Anchor = AnchorStyles.Left;
            footerLabel7.AutoSize = true;
            footerLabel7.BackColor = Color.Cyan;
            footerLabel7.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel7.ForeColor = Color.Red;
            footerLabel7.Location = new Point(830, 0);
            footerLabel7.Margin = new Padding(4, 0, 4, 0);
            footerLabel7.Name = "footerLabel7";
            footerLabel7.Size = new Size(57, 31);
            footerLabel7.TabIndex = 6;
            footerLabel7.Text = "F4:";
            // 
            // footerLabel8
            // 
            footerLabel8.Anchor = AnchorStyles.Left;
            footerLabel8.AutoSize = true;
            footerLabel8.BackColor = Color.Cyan;
            footerLabel8.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel8.ForeColor = Color.Black;
            footerLabel8.Location = new Point(891, 0);
            footerLabel8.Margin = new Padding(4, 0, 4, 0);
            footerLabel8.Name = "footerLabel8";
            footerLabel8.Size = new Size(85, 31);
            footerLabel8.TabIndex = 7;
            footerLabel8.Text = "R.OK";
            // 
            // footerLabel9
            // 
            footerLabel9.Anchor = AnchorStyles.Left;
            footerLabel9.AutoSize = true;
            footerLabel9.BackColor = Color.Cyan;
            footerLabel9.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            footerLabel9.ForeColor = Color.Red;
            footerLabel9.Location = new Point(1205, 0);
            footerLabel9.Margin = new Padding(4, 0, 4, 0);
            footerLabel9.Name = "footerLabel9";
            footerLabel9.Size = new Size(57, 31);
            footerLabel9.TabIndex = 8;
            footerLabel9.Text = "F7:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.MediumBlue;
            ClientSize = new Size(1903, 1061);
            Controls.Add(footerPanel);
            Controls.Add(personalInfoPanel);
            Controls.Add(bannerPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Test AddIn";
            WindowState = FormWindowState.Maximized;
            bannerPanel.ResumeLayout(false);
            bannerPanel.PerformLayout();
            contextMenu.ResumeLayout(false);
            personalInfoPanel.ResumeLayout(false);
            personalInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lastOrdersTable).EndInit();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);

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
        private Label label10;
        private Label labelLastDiscountValue;
        private TextBox textBoxDiscount;
        private Label labelCountValue;
        private Label labelSumValue;
        private Label labelSum;
        private Label labelCount;
        private Label labelRabbat;
        private DataGridViewTextBoxColumn lastOrderAnz;
        private DataGridViewTextBoxColumn lastOrderNr;
        private DataGridViewTextBoxColumn lastOrderName;
        private DataGridViewTextBoxColumn lastOrderSize;
        private DataGridViewTextBoxColumn lastOrderExtra;
        private DataGridViewTextBoxColumn lastOrderPrice;
        private Button btnMenu;
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

