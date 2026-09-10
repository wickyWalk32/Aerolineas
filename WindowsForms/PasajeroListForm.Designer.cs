using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    partial class PasajeroListForm
    {
        private DataGridView dgvPasajeros;
        private Button btnRefrescar;
        private Button btnCerrar;
        private IContainer components;

        private void InitializeComponent()
        {
            dgvPasajeros = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colTipoDoc = new DataGridViewTextBoxColumn();
            colNroDoc = new DataGridViewTextBoxColumn();
            btnRefrescar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPasajeros).BeginInit();
            SuspendLayout();
            // 
            // dgvPasajeros
            // 
            dgvPasajeros.AllowUserToAddRows = false;
            dgvPasajeros.AllowUserToDeleteRows = false;
            dgvPasajeros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPasajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajeros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPasajeros.Columns.AddRange(new DataGridViewColumn[] { colId, colTipo, colNombre, colApellido, colTipoDoc, colNroDoc });
            dgvPasajeros.Location = new Point(12, 12);
            dgvPasajeros.MultiSelect = false;
            dgvPasajeros.Name = "dgvPasajeros";
            dgvPasajeros.ReadOnly = true;
            dgvPasajeros.RowHeadersWidth = 62;
            dgvPasajeros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasajeros.Size = new Size(942, 420);
            dgvPasajeros.TabIndex = 0;
            dgvPasajeros.CellContentClick += dgvPasajeros_CellContentClick;
            // 
            // colId
            // 
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.MinimumWidth = 8;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.MinimumWidth = 8;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.MinimumWidth = 8;
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colTipoDoc
            // 
            colTipoDoc.MinimumWidth = 8;
            colTipoDoc.Name = "colTipoDoc";
            colTipoDoc.ReadOnly = true;
            // 
            // colNroDoc
            // 
            colNroDoc.MinimumWidth = 8;
            colNroDoc.Name = "colNroDoc";
            colNroDoc.ReadOnly = true;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefrescar.Location = new Point(12, 444);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(120, 30);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += BtnRefrescar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(834, 444);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(120, 30);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += BtnCerrar_Click;
            // 
            // PasajeroListForm
            // 
            ClientSize = new Size(966, 486);
            Controls.Add(dgvPasajeros);
            Controls.Add(btnRefrescar);
            Controls.Add(btnCerrar);
            Name = "PasajeroListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Listado de Pasajeros";
            Load += PasajeroListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPasajeros).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colTipoDoc;
        private DataGridViewTextBoxColumn colNroDoc;
    }
}