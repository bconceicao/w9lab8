
namespace Midterm245
{
    partial class SearchPeople
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
            this.btnSearchPeople = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textFname = new System.Windows.Forms.TextBox();
            this.textLname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchPeople
            // 
            this.btnSearchPeople.Location = new System.Drawing.Point(313, 85);
            this.btnSearchPeople.Name = "btnSearchPeople";
            this.btnSearchPeople.Size = new System.Drawing.Size(146, 48);
            this.btnSearchPeople.TabIndex = 0;
            this.btnSearchPeople.Text = "Search People";
            this.btnSearchPeople.UseVisualStyleBackColor = true;
            this.btnSearchPeople.Click += new System.EventHandler(this.btnSearchBooks_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(12, 153);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 62;
            this.dgvResults.RowTemplate.Height = 33;
            this.dgvResults.Size = new System.Drawing.Size(823, 295);
            this.dgvResults.TabIndex = 1;
            this.dgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name:";
            // 
            // textFname
            // 
            this.textFname.Location = new System.Drawing.Point(256, 17);
            this.textFname.Name = "textFname";
            this.textFname.Size = new System.Drawing.Size(150, 31);
            this.textFname.TabIndex = 4;
            // 
            // textLname
            // 
            this.textLname.Location = new System.Drawing.Point(586, 17);
            this.textLname.Name = "textLname";
            this.textLname.Size = new System.Drawing.Size(150, 31);
            this.textLname.TabIndex = 5;
            // 
            // SearchPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 464);
            this.Controls.Add(this.textLname);
            this.Controls.Add(this.textFname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnSearchPeople);
            this.Name = "SearchPeople";
            this.Text = "SearchBook";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchPeople;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textFname;
        private System.Windows.Forms.TextBox textLname;
    }
}