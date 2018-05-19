namespace A
{
    partial class MayA
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAKey = new System.Windows.Forms.TextBox();
            this.txtAEncrypt = new System.Windows.Forms.TextBox();
            this.txtAMess = new System.Windows.Forms.TextBox();
            this.btnASend = new System.Windows.Forms.Button();
            this.btnSendNoise = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(23, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(396, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Encrypt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(396, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Key";
            // 
            // txtAKey
            // 
            this.txtAKey.Location = new System.Drawing.Point(400, 202);
            this.txtAKey.Name = "txtAKey";
            this.txtAKey.Size = new System.Drawing.Size(237, 20);
            this.txtAKey.TabIndex = 12;
            this.txtAKey.TextChanged += new System.EventHandler(this.txtAKey_TextChanged);
            // 
            // txtAEncrypt
            // 
            this.txtAEncrypt.Location = new System.Drawing.Point(400, 59);
            this.txtAEncrypt.Multiline = true;
            this.txtAEncrypt.Name = "txtAEncrypt";
            this.txtAEncrypt.Size = new System.Drawing.Size(237, 53);
            this.txtAEncrypt.TabIndex = 11;
            this.txtAEncrypt.TextChanged += new System.EventHandler(this.txtAEncrypt_TextChanged);
            // 
            // txtAMess
            // 
            this.txtAMess.Location = new System.Drawing.Point(119, 285);
            this.txtAMess.Multiline = true;
            this.txtAMess.Name = "txtAMess";
            this.txtAMess.Size = new System.Drawing.Size(518, 50);
            this.txtAMess.TabIndex = 10;
            // 
            // btnASend
            // 
            this.btnASend.Location = new System.Drawing.Point(169, 361);
            this.btnASend.Name = "btnASend";
            this.btnASend.Size = new System.Drawing.Size(129, 51);
            this.btnASend.TabIndex = 9;
            this.btnASend.Text = "Send";
            this.btnASend.UseVisualStyleBackColor = true;
            this.btnASend.Click += new System.EventHandler(this.btnASend_Click);
            // 
            // btnSendNoise
            // 
            this.btnSendNoise.Location = new System.Drawing.Point(354, 361);
            this.btnSendNoise.Name = "btnSendNoise";
            this.btnSendNoise.Size = new System.Drawing.Size(129, 55);
            this.btnSendNoise.TabIndex = 17;
            this.btnSendNoise.Text = "Send + Noise";
            this.btnSendNoise.UseVisualStyleBackColor = true;
            this.btnSendNoise.Click += new System.EventHandler(this.btnSendNoise_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(371, 266);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MayA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 436);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSendNoise);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAKey);
            this.Controls.Add(this.txtAEncrypt);
            this.Controls.Add(this.txtAMess);
            this.Controls.Add(this.btnASend);
            this.Name = "MayA";
            this.Text = "A";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MayA_FormClosed);
            this.Load += new System.EventHandler(this.MayA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAKey;
        private System.Windows.Forms.TextBox txtAEncrypt;
        private System.Windows.Forms.TextBox txtAMess;
        private System.Windows.Forms.Button btnASend;
        private System.Windows.Forms.Button btnSendNoise;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

