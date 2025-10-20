using System;
using MaterialSkin.Controls;

namespace 
{
    partial class frmSeguridad
    {
        private MaterialSkin.Controls.MaterialLabel lblUsuario;
        private MaterialSkin.Controls.MaterialLabel lblRol;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAntigua;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNueva;
        private MaterialSkin.Controls.MaterialRaisedButton btnCambiar;

        private void InitializeComponent()
        {
            this.lblUsuario = new MaterialSkin.Controls.MaterialLabel();
            this.lblRol = new MaterialSkin.Controls.MaterialLabel();
            this.txtAntigua = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNueva = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnCambiar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.Depth = 0;
            this.lblUsuario.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsuario.Location = new System.Drawing.Point(371, 170);
            this.lblUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(250, 28);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblRol
            // 
            this.lblRol.Depth = 0;
            this.lblRol.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRol.Location = new System.Drawing.Point(371, 220);
            this.lblRol.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(250, 28);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Rol:";
            // 
            // txtAntigua
            // 
            this.txtAntigua.Depth = 0;
            this.txtAntigua.Hint = "Contraseña antigua";
            this.txtAntigua.Location = new System.Drawing.Point(371, 270);
            this.txtAntigua.MaxLength = 32767;
            this.txtAntigua.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAntigua.Name = "txtAntigua";
            this.txtAntigua.PasswordChar = '\0';
            this.txtAntigua.SelectedText = "";
            this.txtAntigua.SelectionLength = 0;
            this.txtAntigua.SelectionStart = 0;
            this.txtAntigua.Size = new System.Drawing.Size(250, 28);
            this.txtAntigua.TabIndex = 2;
            this.txtAntigua.TabStop = false;
            this.txtAntigua.UseSystemPasswordChar = true;
            // 
            // txtNueva
            // 
            this.txtNueva.Depth = 0;
            this.txtNueva.Hint = "Contraseña nueva";
            this.txtNueva.Location = new System.Drawing.Point(371, 329);
            this.txtNueva.MaxLength = 32767;
            this.txtNueva.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.PasswordChar = '\0';
            this.txtNueva.SelectedText = "";
            this.txtNueva.SelectionLength = 0;
            this.txtNueva.SelectionStart = 0;
            this.txtNueva.Size = new System.Drawing.Size(250, 28);
            this.txtNueva.TabIndex = 3;
            this.txtNueva.TabStop = false;
            this.txtNueva.UseSystemPasswordChar = true;
            // 
            // btnCambiar
            // 
            this.btnCambiar.AutoSize = true;
            this.btnCambiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCambiar.Depth = 0;
            this.btnCambiar.Icon = null;
            this.btnCambiar.Location = new System.Drawing.Point(375, 415);
            this.btnCambiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Primary = true;
            this.btnCambiar.Size = new System.Drawing.Size(213, 36);
            this.btnCambiar.TabIndex = 4;
            this.btnCambiar.Text = "Cambiar contraseña";
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // frmSeguridad
            // 
            this.ClientSize = new System.Drawing.Size(979, 707);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtAntigua);
            this.Controls.Add(this.txtNueva);
            this.Controls.Add(this.btnCambiar);
            this.Name = "frmSeguridad";
            this.Text = "Seguridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            frmSeguridad seguridad = new frmSeguridad(usuarioActual);
            seguridad.ShowDialog();
        }
    }
}