namespace Hotels
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.admin = new System.Windows.Forms.Button();
            this.registr = new System.Windows.Forms.Button();
            this.entry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // admin
            // 
            this.admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin.Location = new System.Drawing.Point(81, 63);
            this.admin.Margin = new System.Windows.Forms.Padding(8);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(320, 112);
            this.admin.TabIndex = 6;
            this.admin.Text = "Я админ";
            this.admin.UseVisualStyleBackColor = true;
            this.admin.Click += new System.EventHandler(this.admin_Click);
            // 
            // registr
            // 
            this.registr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registr.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registr.Location = new System.Drawing.Point(553, 63);
            this.registr.Margin = new System.Windows.Forms.Padding(8);
            this.registr.Name = "registr";
            this.registr.Size = new System.Drawing.Size(320, 112);
            this.registr.TabIndex = 7;
            this.registr.Text = "Регистрация";
            this.registr.UseVisualStyleBackColor = true;
            this.registr.Click += new System.EventHandler(this.registr_Click);
            // 
            // entry
            // 
            this.entry.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.entry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entry.Location = new System.Drawing.Point(1008, 63);
            this.entry.Margin = new System.Windows.Forms.Padding(8);
            this.entry.Name = "entry";
            this.entry.Size = new System.Drawing.Size(320, 112);
            this.entry.TabIndex = 8;
            this.entry.Text = "Вход";
            this.entry.UseVisualStyleBackColor = false;
            this.entry.Click += new System.EventHandler(this.entry_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.BackgroundImage = global::Hotels.Properties.Resources.Hotel1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1582, 1055);
            this.Controls.Add(this.entry);
            this.Controls.Add(this.registr);
            this.Controls.Add(this.admin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "Main";
            this.Text = "Вход";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Button registr;
        private System.Windows.Forms.Button entry;
    }
}

