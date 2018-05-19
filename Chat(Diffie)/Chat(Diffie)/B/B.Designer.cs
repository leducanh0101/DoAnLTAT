namespace B
{
    partial class frmB
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
            this.btnBSend = new System.Windows.Forms.Button();
            this.txtBMess = new System.Windows.Forms.TextBox();
            this.txtBEncrypt = new System.Windows.Forms.TextBox();
            this.txtBKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendNoise = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnBSend
            // 
            this.btnBSend.Location = new System.Drawing.Point(153, 96);
            this.btnBSend.Name = "btnBSend";
            this.btnBSend.Size = new System.Drawing.Size(129, 51);
            this.btnBSend.TabIndex = 1;
            this.btnBSend.Text = "Send";
            this.btnBSend.UseVisualStyleBackColor = true;
            this.btnBSend.Click += new System.EventHandler(this.btnBSend_Click);
            // 
            // txtBMess
            // 
            this.txtBMess.Location = new System.Drawing.Point(98, 13);
            this.txtBMess.Multiline = true;
            this.txtBMess.Name = "txtBMess";
            this.txtBMess.Size = new System.Drawing.Size(509, 50);
            this.txtBMess.TabIndex = 2;
            // 
            // txtBEncrypt
            // 
            this.txtBEncrypt.Location = new System.Drawing.Point(319, 212);
            this.txtBEncrypt.Multiline = true;
            this.txtBEncrypt.Name = "txtBEncrypt";
            this.txtBEncrypt.Size = new System.Drawing.Size(284, 53);
            this.txtBEncrypt.TabIndex = 3;
            this.txtBEncrypt.TextChanged += new System.EventHandler(this.txtBEncrypt_TextChanged);
            // 
            // txtBKey
            // 
            this.txtBKey.Location = new System.Drawing.Point(319, 347);
            this.txtBKey.Name = "txtBKey";
            this.txtBKey.Size = new System.Drawing.Size(284, 20);
            this.txtBKey.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(319, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(319, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Encrypt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(2, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message";
            // 
            // btnSendNoise
            // 
            this.btnSendNoise.Location = new System.Drawing.Point(369, 92);
            this.btnSendNoise.Name = "btnSendNoise";
            this.btnSendNoise.Size = new System.Drawing.Size(129, 55);
            this.btnSendNoise.TabIndex = 9;
            this.btnSendNoise.Text = "Send + Noise";
            this.btnSendNoise.UseVisualStyleBackColor = true;
            this.btnSendNoise.Click += new System.EventHandler(this.btnSendNoise_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(-1, 172);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(314, 273);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // frmB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 448);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSendNoise);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBKey);
            this.Controls.Add(this.txtBEncrypt);
            this.Controls.Add(this.txtBMess);
            this.Controls.Add(this.btnBSend);
            this.Name = "frmB";
            this.Text = "B";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmB_FormClosed);
            this.Load += new System.EventHandler(this.frmB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBSend;
        private System.Windows.Forms.TextBox txtBMess;
        private System.Windows.Forms.TextBox txtBEncrypt;
        private System.Windows.Forms.TextBox txtBKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendNoise;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

