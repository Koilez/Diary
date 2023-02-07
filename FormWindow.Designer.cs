namespace Project1
{
    partial class FormWindow
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
            this.panelWindow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelWindow
            // 
            this.panelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWindow.Location = new System.Drawing.Point(0, 0);
            this.panelWindow.Name = "panelWindow";
            this.panelWindow.Size = new System.Drawing.Size(690, 361);
            this.panelWindow.TabIndex = 0;
            // 
            // FormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 361);
            this.Controls.Add(this.panelWindow);
            this.Name = "FormWindow";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWindow_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWindow;
    }
}

