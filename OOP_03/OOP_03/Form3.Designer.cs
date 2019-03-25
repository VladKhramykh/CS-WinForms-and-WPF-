namespace OOP_02
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.showResult = new System.Windows.Forms.ListBox();
            this.radioCountry = new System.Windows.Forms.RadioButton();
            this.radioCity = new System.Windows.Forms.RadioButton();
            this.radioArea = new System.Windows.Forms.RadioButton();
            this.radioNumberOfRooms = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioNumberOfHouse = new System.Windows.Forms.RadioButton();
            this.showInfo = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findTextBox
            // 
            resources.ApplyResources(this.findTextBox, "findTextBox");
            this.findTextBox.Name = "findTextBox";
            // 
            // showResult
            // 
            resources.ApplyResources(this.showResult, "showResult");
            this.showResult.FormattingEnabled = true;
            this.showResult.Name = "showResult";
            this.showResult.SelectedIndexChanged += new System.EventHandler(this.showResult_SelectedIndexChanged);
            // 
            // radioCountry
            // 
            resources.ApplyResources(this.radioCountry, "radioCountry");
            this.radioCountry.Name = "radioCountry";
            this.radioCountry.TabStop = true;
            this.radioCountry.UseVisualStyleBackColor = true;
            // 
            // radioCity
            // 
            resources.ApplyResources(this.radioCity, "radioCity");
            this.radioCity.Name = "radioCity";
            this.radioCity.TabStop = true;
            this.radioCity.UseVisualStyleBackColor = true;
            // 
            // radioArea
            // 
            resources.ApplyResources(this.radioArea, "radioArea");
            this.radioArea.Name = "radioArea";
            this.radioArea.TabStop = true;
            this.radioArea.UseVisualStyleBackColor = true;
            // 
            // radioNumberOfRooms
            // 
            resources.ApplyResources(this.radioNumberOfRooms, "radioNumberOfRooms");
            this.radioNumberOfRooms.Name = "radioNumberOfRooms";
            this.radioNumberOfRooms.TabStop = true;
            this.radioNumberOfRooms.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioNumberOfHouse);
            this.groupBox1.Controls.Add(this.radioNumberOfRooms);
            this.groupBox1.Controls.Add(this.radioArea);
            this.groupBox1.Controls.Add(this.radioCity);
            this.groupBox1.Controls.Add(this.radioCountry);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioNumberOfHouse
            // 
            resources.ApplyResources(this.radioNumberOfHouse, "radioNumberOfHouse");
            this.radioNumberOfHouse.Name = "radioNumberOfHouse";
            this.radioNumberOfHouse.TabStop = true;
            this.radioNumberOfHouse.UseVisualStyleBackColor = true;
            // 
            // showInfo
            // 
            resources.ApplyResources(this.showInfo, "showInfo");
            this.showInfo.FormattingEnabled = true;
            this.showInfo.Name = "showInfo";
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.showInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showResult);
            this.Controls.Add(this.findTextBox);
            this.Name = "Form3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.ListBox showResult;
        private System.Windows.Forms.RadioButton radioCountry;
        private System.Windows.Forms.RadioButton radioCity;
        private System.Windows.Forms.RadioButton radioArea;
        private System.Windows.Forms.RadioButton radioNumberOfRooms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox showInfo;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.RadioButton radioNumberOfHouse;
    }
}