using System;

namespace WindowsFormsApp2
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.cmdConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOptions = new System.Windows.Forms.ComboBox();
            this.chkConsolidateCitations = new System.Windows.Forms.CheckBox();
            this.chkConsolidateHeader = new System.Windows.Forms.CheckBox();
            this.chkTEICoordinates = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Input:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 36);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(732, 112);
            this.txtInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Output:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 272);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(732, 228);
            this.txtOutput.TabIndex = 3;
            // 
            // cmdConvert
            // 
            this.cmdConvert.Location = new System.Drawing.Point(652, 194);
            this.cmdConvert.Name = "cmdConvert";
            this.cmdConvert.Size = new System.Drawing.Size(92, 31);
            this.cmdConvert.TabIndex = 4;
            this.cmdConvert.Text = "&Convert";
            this.cmdConvert.UseVisualStyleBackColor = true;
            this.cmdConvert.Click += new System.EventHandler(this.Button1_ClickAsync);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select option:";
            // 
            // cmbOptions
            // 
            this.cmbOptions.FormattingEnabled = true;
            this.cmbOptions.Location = new System.Drawing.Point(120, 166);
            this.cmbOptions.Name = "cmbOptions";
            this.cmbOptions.Size = new System.Drawing.Size(250, 23);
            this.cmbOptions.TabIndex = 6;
            this.cmbOptions.SelectedIndexChanged += new System.EventHandler(this.CmbOptions_SelectedIndexChanged);
            // 
            // chkConsolidateCitations
            // 
            this.chkConsolidateCitations.AutoSize = true;
            this.chkConsolidateCitations.Location = new System.Drawing.Point(12, 201);
            this.chkConsolidateCitations.Name = "chkConsolidateCitations";
            this.chkConsolidateCitations.Size = new System.Drawing.Size(173, 19);
            this.chkConsolidateCitations.TabIndex = 7;
            this.chkConsolidateCitations.Text = "Consolidate &Citations";
            this.chkConsolidateCitations.ThreeState = true;
            this.chkConsolidateCitations.UseVisualStyleBackColor = true;
            this.chkConsolidateCitations.CheckedChanged += new System.EventHandler(this.generic_checkedChanged);
            this.chkConsolidateCitations.MouseHover += new System.EventHandler(this.generic_mouseHover);
            // 
            // chkConsolidateHeader
            // 
            this.chkConsolidateHeader.AutoSize = true;
            this.chkConsolidateHeader.Location = new System.Drawing.Point(216, 201);
            this.chkConsolidateHeader.Name = "chkConsolidateHeader";
            this.chkConsolidateHeader.Size = new System.Drawing.Size(152, 19);
            this.chkConsolidateHeader.TabIndex = 8;
            this.chkConsolidateHeader.Text = "Consolidate &Header";
            this.chkConsolidateHeader.ThreeState = true;
            this.chkConsolidateHeader.UseVisualStyleBackColor = true;
            this.chkConsolidateHeader.CheckedChanged += new System.EventHandler(this.generic_checkedChanged);
            this.chkConsolidateHeader.MouseHover += new System.EventHandler(this.generic_mouseHover);
            // 
            // chkTEICoordinates
            // 
            this.chkTEICoordinates.AutoSize = true;
            this.chkTEICoordinates.Location = new System.Drawing.Point(399, 201);
            this.chkTEICoordinates.Name = "chkTEICoordinates";
            this.chkTEICoordinates.Size = new System.Drawing.Size(131, 19);
            this.chkTEICoordinates.TabIndex = 9;
            this.chkTEICoordinates.Text = "&TEI Coordinates";
            this.chkTEICoordinates.ThreeState = true;
            this.chkTEICoordinates.UseVisualStyleBackColor = true;
            this.chkTEICoordinates.CheckedChanged += new System.EventHandler(this.generic_checkedChanged);
            this.chkTEICoordinates.MouseHover += new System.EventHandler(this.generic_mouseHover);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 519);
            this.Controls.Add(this.chkTEICoordinates);
            this.Controls.Add(this.chkConsolidateHeader);
            this.Controls.Add(this.chkConsolidateCitations);
            this.Controls.Add(this.cmbOptions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdConvert);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Grobid Test:)~";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button cmdConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOptions;
        private System.Windows.Forms.CheckBox chkConsolidateCitations;
        private System.Windows.Forms.CheckBox chkConsolidateHeader;
        private System.Windows.Forms.CheckBox chkTEICoordinates;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

