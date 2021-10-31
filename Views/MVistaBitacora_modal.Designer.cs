
namespace TALLERM.View
{
    partial class MVistaBitacora_modal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MVistaBitacora_modal));
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDETALLE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEVENTO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFECHA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Detalles";
            // 
            // textBoxDETALLE
            // 
            this.textBoxDETALLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDETALLE.Location = new System.Drawing.Point(132, 94);
            this.textBoxDETALLE.MaxLength = 150;
            this.textBoxDETALLE.Multiline = true;
            this.textBoxDETALLE.Name = "textBoxDETALLE";
            this.textBoxDETALLE.ReadOnly = true;
            this.textBoxDETALLE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDETALLE.Size = new System.Drawing.Size(365, 156);
            this.textBoxDETALLE.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Evento";
            // 
            // textBoxEVENTO
            // 
            this.textBoxEVENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEVENTO.Location = new System.Drawing.Point(132, 55);
            this.textBoxEVENTO.MaxLength = 25;
            this.textBoxEVENTO.Name = "textBoxEVENTO";
            this.textBoxEVENTO.ReadOnly = true;
            this.textBoxEVENTO.Size = new System.Drawing.Size(365, 22);
            this.textBoxEVENTO.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha hora";
            // 
            // textBoxFECHA
            // 
            this.textBoxFECHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFECHA.Location = new System.Drawing.Point(132, 22);
            this.textBoxFECHA.MaxLength = 25;
            this.textBoxFECHA.Name = "textBoxFECHA";
            this.textBoxFECHA.ReadOnly = true;
            this.textBoxFECHA.Size = new System.Drawing.Size(365, 22);
            this.textBoxFECHA.TabIndex = 21;
            // 
            // MVistaBitacora_modal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 266);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFECHA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDETALLE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEVENTO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MVistaBitacora_modal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONMMAP - Detalle bitácora";
            this.Load += new System.EventHandler(this.MControlTiposVehiculos_modal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDETALLE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEVENTO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFECHA;
    }
}