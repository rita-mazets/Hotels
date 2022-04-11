
namespace Hotels
{
    partial class SearchNumber
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hotelsDataSet = new Hotels.HotelsDataSet();
            this.hotelsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hotelsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // hotelsDataSet
            // 
            this.hotelsDataSet.DataSetName = "HotelsDataSet";
            this.hotelsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hotelsDataSetBindingSource
            // 
            this.hotelsDataSetBindingSource.DataSource = this.hotelsDataSet;
            this.hotelsDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Price,
            this.Type,
            this.Capacity,
            this.BedType});
            this.dataGridView1.Location = new System.Drawing.Point(234, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1404, 704);
            this.dataGridView1.TabIndex = 0;
            // 
            // Number
            // 
            this.Number.HeaderText = "Номер";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 200;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 200;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.Width = 200;
            // 
            // Capacity
            // 
            this.Capacity.HeaderText = "Вместимость";
            this.Capacity.MinimumWidth = 6;
            this.Capacity.Name = "Capacity";
            this.Capacity.Width = 200;
            // 
            // BedType
            // 
            this.BedType.HeaderText = "Тип кровати";
            this.BedType.MinimumWidth = 6;
            this.BedType.Name = "BedType";
            this.BedType.Width = 200;
            // 
            // user
            // 
            this.user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(1369, 36);
            this.user.Margin = new System.Windows.Forms.Padding(8);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(269, 63);
            this.user.TabIndex = 23;
            this.user.Text = "Бронировать";
            this.user.UseVisualStyleBackColor = true;
            this.user.Click += new System.EventHandler(this.user_Click);
            // 
            // back
            // 
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(17, 8);
            this.back.Margin = new System.Windows.Forms.Padding(8);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(188, 57);
            this.back.TabIndex = 29;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // SearchNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.back);
            this.Controls.Add(this.user);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SearchNumber";
            this.Text = "SearchNumber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchNumber_FormClosing);
            this.Load += new System.EventHandler(this.SearchNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hotelsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource hotelsDataSetBindingSource;
        private HotelsDataSet hotelsDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedType;
        private System.Windows.Forms.Button user;
        private System.Windows.Forms.Button back;
    }
}