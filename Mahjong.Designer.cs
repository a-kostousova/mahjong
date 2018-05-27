using System.Windows.Forms;

namespace MahjongApp
{
    partial class MahjongForm : Form
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из игры?", "", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) e.Cancel = true;
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Tomato;
            this.startButton.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startButton.Location = new System.Drawing.Point(181, 104);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(283, 101);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "СТАРТ";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new ;
                //System.EventHandler(this.StartButtonClick);
            // 
            // MahjongForm
            // 
            this.ClientSize = new System.Drawing.Size(646, 354);
            this.Controls.Add(this.startButton);
            this.Name = "MahjongForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button startButton;
    }
}

