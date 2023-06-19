namespace Visao
{
    partial class Gerenciamento
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnDeleteCandidato = new Button();
            dataGridCandidatos = new DataGridView();
            IdCandidato = new DataGridViewTextBoxColumn();
            NomeCandidato = new DataGridViewTextBoxColumn();
            NumeroCandidato = new DataGridViewTextBoxColumn();
            DataNascimentoCandidato = new DataGridViewTextBoxColumn();
            PartidoCandidato = new DataGridViewComboBoxColumn();
            partidoBindingSource = new BindingSource(components);
            CargoCandidato = new DataGridViewComboBoxColumn();
            enumHelperObjectBindingSource = new BindingSource(components);
            candidatoDTOBindingSource = new BindingSource(components);
            btnSalvarGridCandidatos = new Button();
            tabPage2 = new TabPage();
            btnDeletePartido = new Button();
            btnSalvarGridPartido = new Button();
            dataGridPartido = new DataGridView();
            IdPartido = new DataGridViewTextBoxColumn();
            NomePartido = new DataGridViewTextBoxColumn();
            NumeroPartido = new DataGridViewTextBoxColumn();
            partidoDTOBindingSource = new BindingSource(components);
            tabPage3 = new TabPage();
            btnDeleteEleicao = new Button();
            btnSalvarGridEleicoes = new Button();
            dataGridEleicao = new DataGridView();
            IdEleicao = new DataGridViewTextBoxColumn();
            TipoEleicao = new DataGridViewComboBoxColumn();
            AnoEleicao = new DataGridViewTextBoxColumn();
            MesEleicao = new DataGridViewTextBoxColumn();
            StatusEleicao = new DataGridViewComboBoxColumn();
            SegundoTurnoEleicao = new DataGridViewCheckBoxColumn();
            eleicaoDTOBindingSource = new BindingSource(components);
            enumHelperObjectBindingSource3 = new BindingSource(components);
            candidatoBindingSource = new BindingSource(components);
            enumHelperObjectBindingSource2 = new BindingSource(components);
            enumHelperObjectBindingSource1 = new BindingSource(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridCandidatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partidoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)candidatoDTOBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPartido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partidoDTOBindingSource).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEleicao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)eleicaoDTOBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)candidatoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(914, 601);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnDeleteCandidato);
            tabPage1.Controls.Add(dataGridCandidatos);
            tabPage1.Controls.Add(btnSalvarGridCandidatos);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(906, 568);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Candidatos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCandidato
            // 
            btnDeleteCandidato.Enabled = false;
            btnDeleteCandidato.Location = new Point(124, 15);
            btnDeleteCandidato.Name = "btnDeleteCandidato";
            btnDeleteCandidato.Size = new Size(94, 29);
            btnDeleteCandidato.TabIndex = 4;
            btnDeleteCandidato.Text = "Apagar";
            btnDeleteCandidato.UseVisualStyleBackColor = true;
            btnDeleteCandidato.Click += btnApagarCandidato_Click;
            // 
            // dataGridCandidatos
            // 
            dataGridCandidatos.AutoGenerateColumns = false;
            dataGridCandidatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCandidatos.Columns.AddRange(new DataGridViewColumn[] { IdCandidato, NomeCandidato, NumeroCandidato, DataNascimentoCandidato, PartidoCandidato, CargoCandidato });
            dataGridCandidatos.DataSource = candidatoDTOBindingSource;
            dataGridCandidatos.Location = new Point(8, 60);
            dataGridCandidatos.Name = "dataGridCandidatos";
            dataGridCandidatos.RowHeadersWidth = 51;
            dataGridCandidatos.RowTemplate.Height = 29;
            dataGridCandidatos.Size = new Size(890, 501);
            dataGridCandidatos.TabIndex = 3;
            dataGridCandidatos.DefaultValuesNeeded += dataGridCandidatos_DefaultValuesNeeded;
            dataGridCandidatos.SelectionChanged += dataGridCandidatos_SelectionChanged;
            // 
            // IdCandidato
            // 
            IdCandidato.DataPropertyName = "Id";
            IdCandidato.HeaderText = "Id";
            IdCandidato.MinimumWidth = 6;
            IdCandidato.Name = "IdCandidato";
            IdCandidato.ReadOnly = true;
            IdCandidato.Width = 125;
            // 
            // NomeCandidato
            // 
            NomeCandidato.DataPropertyName = "Nome";
            NomeCandidato.HeaderText = "Nome";
            NomeCandidato.MinimumWidth = 6;
            NomeCandidato.Name = "NomeCandidato";
            NomeCandidato.Width = 125;
            // 
            // NumeroCandidato
            // 
            NumeroCandidato.DataPropertyName = "Numero";
            NumeroCandidato.HeaderText = "Numero";
            NumeroCandidato.MinimumWidth = 6;
            NumeroCandidato.Name = "NumeroCandidato";
            NumeroCandidato.Width = 125;
            // 
            // DataNascimentoCandidato
            // 
            DataNascimentoCandidato.DataPropertyName = "DataNascimento";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            DataNascimentoCandidato.DefaultCellStyle = dataGridViewCellStyle1;
            DataNascimentoCandidato.HeaderText = "DataNascimento";
            DataNascimentoCandidato.MinimumWidth = 6;
            DataNascimentoCandidato.Name = "DataNascimentoCandidato";
            DataNascimentoCandidato.Width = 125;
            // 
            // PartidoCandidato
            // 
            PartidoCandidato.DataPropertyName = "PartidoId";
            PartidoCandidato.DataSource = partidoBindingSource;
            PartidoCandidato.DisplayMember = "Nome";
            PartidoCandidato.HeaderText = "Partido";
            PartidoCandidato.MinimumWidth = 6;
            PartidoCandidato.Name = "PartidoCandidato";
            PartidoCandidato.Resizable = DataGridViewTriState.True;
            PartidoCandidato.SortMode = DataGridViewColumnSortMode.Automatic;
            PartidoCandidato.ValueMember = "Id";
            PartidoCandidato.Width = 125;
            // 
            // partidoBindingSource
            // 
            partidoBindingSource.DataSource = typeof(Model.Models.Partido);
            // 
            // CargoCandidato
            // 
            CargoCandidato.DataPropertyName = "Cargo";
            CargoCandidato.DataSource = enumHelperObjectBindingSource;
            CargoCandidato.DisplayMember = "Text";
            CargoCandidato.HeaderText = "Cargo";
            CargoCandidato.MinimumWidth = 6;
            CargoCandidato.Name = "CargoCandidato";
            CargoCandidato.Resizable = DataGridViewTriState.True;
            CargoCandidato.SortMode = DataGridViewColumnSortMode.Automatic;
            CargoCandidato.ValueMember = "Value";
            CargoCandidato.Width = 125;
            // 
            // enumHelperObjectBindingSource
            // 
            enumHelperObjectBindingSource.DataSource = typeof(Model.Helpers.EnumHelperObject);
            // 
            // candidatoDTOBindingSource
            // 
            candidatoDTOBindingSource.DataSource = typeof(Model.DTO.CandidatoDTO);
            // 
            // btnSalvarGridCandidatos
            // 
            btnSalvarGridCandidatos.Location = new Point(24, 15);
            btnSalvarGridCandidatos.Name = "btnSalvarGridCandidatos";
            btnSalvarGridCandidatos.Size = new Size(94, 29);
            btnSalvarGridCandidatos.TabIndex = 1;
            btnSalvarGridCandidatos.Text = "Salvar";
            btnSalvarGridCandidatos.UseVisualStyleBackColor = true;
            btnSalvarGridCandidatos.Click += btnSalvarGridCandidatos_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnDeletePartido);
            tabPage2.Controls.Add(btnSalvarGridPartido);
            tabPage2.Controls.Add(dataGridPartido);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(906, 568);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Partido";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDeletePartido
            // 
            btnDeletePartido.Enabled = false;
            btnDeletePartido.Location = new Point(109, 19);
            btnDeletePartido.Name = "btnDeletePartido";
            btnDeletePartido.Size = new Size(94, 29);
            btnDeletePartido.TabIndex = 3;
            btnDeletePartido.Text = "Apagar";
            btnDeletePartido.UseVisualStyleBackColor = true;
            btnDeletePartido.Click += btnDeletePartido_Click;
            // 
            // btnSalvarGridPartido
            // 
            btnSalvarGridPartido.Location = new Point(9, 19);
            btnSalvarGridPartido.Name = "btnSalvarGridPartido";
            btnSalvarGridPartido.Size = new Size(94, 29);
            btnSalvarGridPartido.TabIndex = 1;
            btnSalvarGridPartido.Text = "Salvar";
            btnSalvarGridPartido.UseVisualStyleBackColor = true;
            btnSalvarGridPartido.Click += btnSalvarGridPartido_Click;
            // 
            // dataGridPartido
            // 
            dataGridPartido.AutoGenerateColumns = false;
            dataGridPartido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPartido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPartido.Columns.AddRange(new DataGridViewColumn[] { IdPartido, NomePartido, NumeroPartido });
            dataGridPartido.DataSource = partidoDTOBindingSource;
            dataGridPartido.Location = new Point(9, 98);
            dataGridPartido.Margin = new Padding(3, 4, 3, 4);
            dataGridPartido.Name = "dataGridPartido";
            dataGridPartido.RowHeadersWidth = 51;
            dataGridPartido.RowTemplate.Height = 25;
            dataGridPartido.Size = new Size(887, 458);
            dataGridPartido.TabIndex = 0;
            dataGridPartido.RowValidating += dataGridView1_RowValidating;
            dataGridPartido.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // IdPartido
            // 
            IdPartido.DataPropertyName = "Id";
            IdPartido.HeaderText = "Id";
            IdPartido.MinimumWidth = 6;
            IdPartido.Name = "IdPartido";
            IdPartido.ReadOnly = true;
            // 
            // NomePartido
            // 
            NomePartido.DataPropertyName = "Nome";
            NomePartido.HeaderText = "Nome";
            NomePartido.MinimumWidth = 6;
            NomePartido.Name = "NomePartido";
            // 
            // NumeroPartido
            // 
            NumeroPartido.DataPropertyName = "Numero";
            NumeroPartido.HeaderText = "Numero";
            NumeroPartido.MinimumWidth = 6;
            NumeroPartido.Name = "NumeroPartido";
            // 
            // partidoDTOBindingSource
            // 
            partidoDTOBindingSource.DataSource = typeof(Model.DTO.PartidoDTO);
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnDeleteEleicao);
            tabPage3.Controls.Add(btnSalvarGridEleicoes);
            tabPage3.Controls.Add(dataGridEleicao);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 4, 3, 4);
            tabPage3.Size = new Size(906, 568);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Eleições";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEleicao
            // 
            btnDeleteEleicao.Location = new Point(108, 25);
            btnDeleteEleicao.Name = "btnDeleteEleicao";
            btnDeleteEleicao.Size = new Size(94, 29);
            btnDeleteEleicao.TabIndex = 2;
            btnDeleteEleicao.Text = "Apagar";
            btnDeleteEleicao.UseVisualStyleBackColor = true;
            btnDeleteEleicao.Click += btnDeleteEleicao_Click;
            // 
            // btnSalvarGridEleicoes
            // 
            btnSalvarGridEleicoes.Location = new Point(8, 25);
            btnSalvarGridEleicoes.Name = "btnSalvarGridEleicoes";
            btnSalvarGridEleicoes.Size = new Size(94, 29);
            btnSalvarGridEleicoes.TabIndex = 1;
            btnSalvarGridEleicoes.Text = "Salvar";
            btnSalvarGridEleicoes.UseVisualStyleBackColor = true;
            btnSalvarGridEleicoes.Click += btnSalvarGridEleicoes_Click;
            // 
            // dataGridEleicao
            // 
            dataGridEleicao.AutoGenerateColumns = false;
            dataGridEleicao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEleicao.Columns.AddRange(new DataGridViewColumn[] { IdEleicao, TipoEleicao, AnoEleicao, MesEleicao, StatusEleicao, SegundoTurnoEleicao });
            dataGridEleicao.DataSource = eleicaoDTOBindingSource;
            dataGridEleicao.Location = new Point(8, 89);
            dataGridEleicao.Name = "dataGridEleicao";
            dataGridEleicao.RowHeadersWidth = 51;
            dataGridEleicao.RowTemplate.Height = 29;
            dataGridEleicao.Size = new Size(890, 472);
            dataGridEleicao.TabIndex = 0;
            dataGridEleicao.SelectionChanged += dataGridEleicao_SelectionChanged;
            // 
            // IdEleicao
            // 
            IdEleicao.DataPropertyName = "Id";
            IdEleicao.HeaderText = "Id";
            IdEleicao.MinimumWidth = 6;
            IdEleicao.Name = "IdEleicao";
            IdEleicao.ReadOnly = true;
            IdEleicao.Width = 125;
            // 
            // TipoEleicao
            // 
            TipoEleicao.DataPropertyName = "TipoEleicao";
            TipoEleicao.DataSource = enumHelperObjectBindingSource;
            TipoEleicao.DisplayMember = "Text";
            TipoEleicao.HeaderText = "TipoEleicao";
            TipoEleicao.MinimumWidth = 6;
            TipoEleicao.Name = "TipoEleicao";
            TipoEleicao.Resizable = DataGridViewTriState.True;
            TipoEleicao.SortMode = DataGridViewColumnSortMode.Automatic;
            TipoEleicao.ValueMember = "Value";
            TipoEleicao.Width = 125;
            // 
            // AnoEleicao
            // 
            AnoEleicao.DataPropertyName = "Ano";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            AnoEleicao.DefaultCellStyle = dataGridViewCellStyle2;
            AnoEleicao.HeaderText = "Ano";
            AnoEleicao.MinimumWidth = 6;
            AnoEleicao.Name = "AnoEleicao";
            AnoEleicao.Width = 125;
            // 
            // MesEleicao
            // 
            MesEleicao.DataPropertyName = "Mes";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            MesEleicao.DefaultCellStyle = dataGridViewCellStyle3;
            MesEleicao.HeaderText = "Mes";
            MesEleicao.MinimumWidth = 6;
            MesEleicao.Name = "MesEleicao";
            MesEleicao.Width = 125;
            // 
            // StatusEleicao
            // 
            StatusEleicao.DataPropertyName = "StatusEleicao";
            StatusEleicao.DataSource = enumHelperObjectBindingSource;
            StatusEleicao.DisplayMember = "Text";
            StatusEleicao.HeaderText = "StatusEleicao";
            StatusEleicao.MinimumWidth = 6;
            StatusEleicao.Name = "StatusEleicao";
            StatusEleicao.Resizable = DataGridViewTriState.True;
            StatusEleicao.SortMode = DataGridViewColumnSortMode.Automatic;
            StatusEleicao.ValueMember = "Value";
            StatusEleicao.Width = 125;
            // 
            // SegundoTurnoEleicao
            // 
            SegundoTurnoEleicao.DataPropertyName = "SegundoTurno";
            SegundoTurnoEleicao.HeaderText = "SegundoTurno";
            SegundoTurnoEleicao.MinimumWidth = 6;
            SegundoTurnoEleicao.Name = "SegundoTurnoEleicao";
            SegundoTurnoEleicao.Width = 125;
            // 
            // eleicaoDTOBindingSource
            // 
            eleicaoDTOBindingSource.DataSource = typeof(Model.DTO.EleicaoDTO);
            // 
            // enumHelperObjectBindingSource3
            // 
            enumHelperObjectBindingSource3.DataSource = typeof(Model.Helpers.EnumHelperObject);
            // 
            // candidatoBindingSource
            // 
            candidatoBindingSource.DataSource = typeof(Model.Models.Candidato);
            // 
            // enumHelperObjectBindingSource2
            // 
            enumHelperObjectBindingSource2.DataSource = typeof(Model.Helpers.EnumHelperObject);
            // 
            // enumHelperObjectBindingSource1
            // 
            enumHelperObjectBindingSource1.DataSource = typeof(Model.Helpers.EnumHelperObject);
            // 
            // Gerenciamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Gerenciamento";
            Text = "Gerenciamento";
            Load += Gerenciamento_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridCandidatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)partidoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)candidatoDTOBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPartido).EndInit();
            ((System.ComponentModel.ISupportInitialize)partidoDTOBindingSource).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridEleicao).EndInit();
            ((System.ComponentModel.ISupportInitialize)eleicaoDTOBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource3).EndInit();
            ((System.ComponentModel.ISupportInitialize)candidatoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)enumHelperObjectBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private BindingSource candidatoBindingSource;
        private BindingSource partidoBindingSource;
        private BindingSource enumHelperObjectBindingSource;
        private BindingSource enumHelperObjectBindingSource1;
        private BindingSource enumHelperObjectBindingSource2;
        private BindingSource enumHelperObjectBindingSource3;
        private BindingSource candidatoDTOBindingSource;
        private TabPage tabPage3;
        private DataGridView dataGridPartido;
        private DataGridViewTextBoxColumn IdPartido;
        private DataGridViewTextBoxColumn NomePartido;
        private DataGridViewTextBoxColumn NumeroPartido;
        private BindingSource partidoDTOBindingSource;
        private Button btnSalvarGridPartido;
        private Button btnSalvarGridCandidatos;
        private Button btnNovoCandidato;
        private DataGridView dataGridCandidatos;
        private DataGridViewTextBoxColumn IdCandidato;
        private DataGridViewTextBoxColumn NomeCandidato;
        private DataGridViewTextBoxColumn NumeroCandidato;
        private DataGridViewTextBoxColumn DataNascimentoCandidato;
        private DataGridViewComboBoxColumn PartidoCandidato;
        private DataGridViewComboBoxColumn CargoCandidato;
        private Button btnNovoPartido;
        private Button btnDeletePartido;
        private Button btnDeleteCandidato;
        private DataGridView dataGridEleicao;
        private BindingSource eleicaoDTOBindingSource;
        private Button btnSalvarGridEleicoes;
        private Button btnDeleteEleicao;
        private DataGridViewTextBoxColumn IdEleicao;
        private DataGridViewComboBoxColumn TipoEleicao;
        private DataGridViewTextBoxColumn AnoEleicao;
        private DataGridViewTextBoxColumn MesEleicao;
        private DataGridViewComboBoxColumn StatusEleicao;
        private DataGridViewCheckBoxColumn SegundoTurnoEleicao;
    }
}