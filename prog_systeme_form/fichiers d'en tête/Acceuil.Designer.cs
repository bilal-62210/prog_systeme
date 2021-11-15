
namespace prog_systeme_form.fichiers_d_en_tête
{
    partial class Acceuil
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
            this.txt_bienvenue = new System.Windows.Forms.TextBox();
            this.txt_langue = new System.Windows.Forms.TextBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.btn_english = new System.Windows.Forms.RadioButton();
            this.btn_francais = new System.Windows.Forms.RadioButton();
            this.btn_valider = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_bienvenue
            // 
            this.txt_bienvenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_bienvenue.Font = new System.Drawing.Font("Elephant", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bienvenue.Location = new System.Drawing.Point(1039, 215);
            this.txt_bienvenue.Multiline = true;
            this.txt_bienvenue.Name = "txt_bienvenue";
            this.txt_bienvenue.Size = new System.Drawing.Size(278, 76);
            this.txt_bienvenue.TabIndex = 2;
            this.txt_bienvenue.Text = "Bienvenue sur votre logiciel de sauvegarde by ProSoft \r\n\r\n Welcome on your save b" +
    "y ProSoft";
            this.txt_bienvenue.TextChanged += new System.EventHandler(this.txt_bienvenue_TextChanged);
            // 
            // txt_langue
            // 
            this.txt_langue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_langue.Font = new System.Drawing.Font("Elephant", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_langue.Location = new System.Drawing.Point(518, 527);
            this.txt_langue.Multiline = true;
            this.txt_langue.Name = "txt_langue";
            this.txt_langue.Size = new System.Drawing.Size(352, 61);
            this.txt_langue.TabIndex = 3;
            this.txt_langue.Text = "Veuillez selctionner votre langue\r\n\r\nPlease choose your langage";
            this.txt_langue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_langue.TextChanged += new System.EventHandler(this.txt_langue_TextChanged);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.SystemColors.Window;
            this.logo.Image = global::prog_systeme_form.Properties.Resources._4072706;
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(1381, 829);
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.logo_Click);
            // 
            // btn_english
            // 
            this.btn_english.AutoSize = true;
            this.btn_english.BackColor = System.Drawing.SystemColors.Window;
            this.btn_english.Location = new System.Drawing.Point(518, 643);
            this.btn_english.Name = "btn_english";
            this.btn_english.Size = new System.Drawing.Size(75, 21);
            this.btn_english.TabIndex = 5;
            this.btn_english.TabStop = true;
            this.btn_english.Text = "English";
            this.btn_english.UseVisualStyleBackColor = false;
            // 
            // btn_francais
            // 
            this.btn_francais.AutoSize = true;
            this.btn_francais.BackColor = System.Drawing.SystemColors.Window;
            this.btn_francais.Location = new System.Drawing.Point(787, 643);
            this.btn_francais.Name = "btn_francais";
            this.btn_francais.Size = new System.Drawing.Size(83, 21);
            this.btn_francais.TabIndex = 6;
            this.btn_francais.TabStop = true;
            this.btn_francais.Text = "Français";
            this.btn_francais.UseVisualStyleBackColor = false;
            // 
            // btn_valider
            // 
            this.btn_valider.BackColor = System.Drawing.SystemColors.Window;
            this.btn_valider.Location = new System.Drawing.Point(646, 722);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(92, 29);
            this.btn_valider.TabIndex = 7;
            this.btn_valider.Text = "OK";
            this.btn_valider.UseVisualStyleBackColor = false;
            // 
            // Acceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 829);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.btn_francais);
            this.Controls.Add(this.btn_english);
            this.Controls.Add(this.txt_langue);
            this.Controls.Add(this.txt_bienvenue);
            this.Controls.Add(this.logo);
            this.Name = "Acceuil";
            this.Text = "Acceuil";
            this.Load += new System.EventHandler(this.Acceuil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.TextBox txt_bienvenue;
        private System.Windows.Forms.TextBox txt_langue;
        private System.Windows.Forms.RadioButton btn_english;
        private System.Windows.Forms.RadioButton btn_francais;
        private System.Windows.Forms.Button btn_valider;
    }
}