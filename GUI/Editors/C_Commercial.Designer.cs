/* This file is part of AHD ID3 Tag Editor (AITE)
 * A program that edit and create ID3 Tag.
 *
 * Copyright © Alaa Ibrahim Hadid 2012 - 2021
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace AHD.ID3.Editor.GUI
{
    partial class C_Commercial
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_Commercial));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.textEditorControl_price = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.comboBox_price = new System.Windows.Forms.ComboBox();
            this.dateControl_ValidUntil = new AHD.ID3.Editor.GUI.DateControl();
            this.comboBoxControl_ReceivedAs = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.textEditorControl_ContactURL = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_NameOfSeller = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.richTextControl_Description = new AHD.ID3.Editor.GUI.RichTextControl();
            this.label1 = new System.Windows.Forms.Label();
            this.imagePanel1 = new AHD.ID3.Editor.GUI.ImagePanel();
            this.label_picInfo = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(322, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Save changes";
            this.toolStripButton1.Click += new System.EventHandler(this.SaveChanges);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Reload";
            this.toolStripButton2.Click += new System.EventHandler(this.ReloadFrame);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // textEditorControl_price
            // 
            this.textEditorControl_price.LinkTooltip = "";
            this.textEditorControl_price.LinkValue = "linkLabel1";
            this.textEditorControl_price.LinkVisible = false;
            this.textEditorControl_price.Location = new System.Drawing.Point(3, 28);
            this.textEditorControl_price.MaximumCharsCount = 32767;
            this.textEditorControl_price.Name = "textEditorControl_price";
            this.textEditorControl_price.PropertyName = "Price:";
            this.textEditorControl_price.PropertyValue = "";
            this.textEditorControl_price.Size = new System.Drawing.Size(150, 39);
            this.textEditorControl_price.TabIndex = 1;
            // 
            // comboBox_price
            // 
            this.comboBox_price.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_price.FormattingEnabled = true;
            this.comboBox_price.Items.AddRange(new object[] {
            "Afghani [ AFN ]",
            "Algerian Dinar [ DZD ]",
            "Argentine Peso [ ARS ]",
            "Armenian Dram [ AMD ]",
            "Aruban Guilder [ AWG ]",
            "Australian Dollar [ AUD ]",
            "Azerbaijanian Manat [ AZN ]",
            "Bahamian Dollar [ BSD ]",
            "Bahraini Dinar [ BHD ]",
            "Baht [ THB ]",
            "Balboa [ PAB ]",
            "Bangladeshi Taka [ BDT ]",
            "Barbados Dollar [ BBD ]",
            "Belarussian Ruble [ BYR ]",
            "Belize Dollar [ BZD ]",
            "Bermudian Dollar [ BMD ]",
            "Bolivian Mvdol [ BOV ]",
            "Boliviano [ BOB ]",
            "Botswana Pula [ BWP ]",
            "Brazilian Real [ BRL ]",
            "Brunei Dollar [ BND ]",
            "Bulgarian Lev [ BGN ]",
            "Burundian Franc [ BIF ]",
            "Canadian Dollar [ CAD ]",
            "Cape Verde Escudo [ CVE ]",
            "Cayman Islands Dollar [ KYD ]",
            "Cedi [ GHC ]",
            "Chilean Peso [ CLP ]",
            "Colombian Peso [ COP ]",
            "Comoro Franc [ KMF ]",
            "Convertible Marks [ BAM ]",
            "Cordoba Oro [ NIO ]",
            "Costa Rican Colon [ CRC ]",
            "Croatian Kuna [ HRK ]",
            "Cuban Peso [ CUP ]",
            "Cyprus Pound [ CYP ]",
            "Czech Koruna [ CZK ]",
            "Dalasi [ GMD ]",
            "Danish Krone [ DKK ]",
            "Denar [ MKD ]",
            "Djibouti Franc [ DJF ]",
            "Dobra [ STD ]",
            "Dominican Peso [ DOP ]",
            "Dong [ VND ]",
            "East Caribbean Dollar [ XCD ]",
            "Egyptian Pound [ EGP ]",
            "Ethiopian Birr [ ETB ]",
            "Euro [ EUR ]",
            "Falkland Islands Pound [ FKP ]",
            "Fiji Dollar [ FJD ]",
            "Forint [ HUF ]",
            "Franc Congolais [ CDF ]",
            "Gibraltar pound [ GIP ]",
            "Guarani [ PYG ]",
            "Guinea Franc [ GNF ]",
            "Guyana Dollar [ GYD ]",
            "Haiti Gourde [ HTG ]",
            "Hong Kong Dollar [ HKD ]",
            "Hryvnia [ UAH ]",
            "Iceland Krona [ ISK ]",
            "Indian Rupee [ INR ]",
            "Iranian Rial [ IRR ]",
            "Iraqi Dinar [ IQD ]",
            "Jamaican Dollar [ JMD ]",
            "Japanese yen [ JPY ]",
            "Jordanian Dinar [ JOD ]",
            "Kenyan Shilling [ KES ]",
            "Kina [ PGK ]",
            "Kip [ LAK ]",
            "Kroon [ EEK ]",
            "Kuwaiti Dinar [ KWD ]",
            "Kwacha [ MWK ]",
            "Kwacha [ ZMK ]",
            "Kwanza [ AOA ]",
            "Kyat [ MMK ]",
            "Lari [ GEL ]",
            "Latvian Lats [ LVL ]",
            "Lebanese Pound [ LBP ]",
            "Lek [ ALL ]",
            "Lempira [ HNL ]",
            "Leone [ SLL ]",
            "Liberian Dollar [ LRD ]",
            "Libyan Dinar [ LYD ]",
            "Lilangeni [ SZL ]",
            "Lithuanian Litas [ LTL ]",
            "Loti [ LSL ]",
            "Malagasy Ariary [ MGA ]",
            "Malaysian Ringgit [ MYR ]",
            "Maltese Lira [ MTL ]",
            "Manat [ TMM ]",
            "Mauritius Rupee [ MUR ]",
            "Metical [ MZN ]",
            "Mexican Peso [ MXN ]",
            "Mexican Unidad [ MXV ]",
            "Moldovan Leu [ MDL ]",
            "Moroccan Dirham [ MAD ]",
            "Naira [ NGN ]",
            "Nakfa [ ERN ]",
            "Namibian Dollar [ NAD ]",
            "Nepalese Rupee [ NPR ]",
            "Netherlands Antillian Guilder [ ANG ]",
            "New Israeli Shekel [ ILS ]",
            "New Taiwan Dollar [ TWD ]",
            "New Turkish Lira [ TRY ]",
            "New Zealand Dollar [ NZD ]",
            "Ngultrum [ BTN ]",
            "North Korean Won [ KPW ]",
            "Norwegian Krone [ NOK ]",
            "Nuevo Sol [ PEN ]",
            "Ouguiya [ MRO ]",
            "Pa\'anga [ TOP ]",
            "Pakistan Rupee [ PKR ]",
            "Pataca [ MOP ]",
            "Peso Uruguayo [ UYU ]",
            "Philippine Peso [ PHP ]",
            "Pound Sterling [ GBP ]",
            "Qatari Rial [ QAR ]",
            "Quetzal [ GTQ ]",
            "Rial Omani [ OMR ]",
            "Riel [ KHR ]",
            "Romanian Leu [ ROL ]",
            "Romanian New Leu [ RON ]",
            "Rufiyaa [ MVR ]",
            "Rupiah [ IDR ]",
            "Russian Ruble [ RUB ]",
            "Rwanda Franc [ RWF ]",
            "Saint Helena Pound [ SHP ]",
            "Samoan Tala [ WST ]",
            "Saudi Riyal [ SAR ]",
            "Serbian Dinar [ RSD ]",
            "Seychelles Rupee [ SCR ]",
            "Singapore Dollar [ SGD ]",
            "Slovak Koruna [ SKK ]",
            "Solomon Islands Dollar [ SBD ]",
            "Som [ KGS ]",
            "Somali Shilling [ SOS ]",
            "Somoni [ TJS ]",
            "South African Rand [ ZAR ]",
            "South Korean Won [ KRW ]",
            "Sri Lanka Rupee [ LKR ]",
            "Sudanese Dinar [ SDD ]",
            "Surinam Dollar [ SRD ]",
            "Swedish Krona [ SEK ]",
            "Swiss Franc [ CHF ]",
            "Syrian Pound [ SYP ]",
            "Tanzanian Shilling [ TZS ]",
            "Tenge [ KZT ]",
            "Trinidad and Tobago Dollar [ TTD ]",
            "Tugrik [ MNT ]",
            "Tunisian Dinar [ TND ]",
            "Uganda Shilling [ UGX ]",
            "Unidad de Valor Real [ COU ]",
            "Unidades de formento [ CLF ]",
            "United Arab Emirates dirham [ AED ]",
            "US Dollar [ USD ]",
            "Uzbekistan Som [ UZS ]",
            "Vatu [ VUV ]",
            "Venezuelan bolívar [ VEB ]",
            "Yemeni Rial [ YER ]",
            "Yuan Renminbi [ CNY ]",
            "Zimbabwe Dollar [ ZWD ]",
            "Zloty [ PLN ]"});
            this.comboBox_price.Location = new System.Drawing.Point(159, 44);
            this.comboBox_price.Name = "comboBox_price";
            this.comboBox_price.Size = new System.Drawing.Size(135, 21);
            this.comboBox_price.TabIndex = 4;
            // 
            // dateControl_ValidUntil
            // 
            this.dateControl_ValidUntil.LinkTooltip = "";
            this.dateControl_ValidUntil.LinkValue = "linkLabel1";
            this.dateControl_ValidUntil.LinkVisible = false;
            this.dateControl_ValidUntil.Location = new System.Drawing.Point(7, 73);
            this.dateControl_ValidUntil.Name = "dateControl_ValidUntil";
            this.dateControl_ValidUntil.PropertyName = "Valid until:";
            this.dateControl_ValidUntil.PropertyValue = new System.DateTime(2013, 2, 24, 21, 15, 36, 619);
            this.dateControl_ValidUntil.Size = new System.Drawing.Size(146, 39);
            this.dateControl_ValidUntil.TabIndex = 5;
            // 
            // comboBoxControl_ReceivedAs
            // 
            this.comboBoxControl_ReceivedAs.LinkTooltip = "";
            this.comboBoxControl_ReceivedAs.LinkValue = "linkLabel1";
            this.comboBoxControl_ReceivedAs.LinkVisible = false;
            this.comboBoxControl_ReceivedAs.Location = new System.Drawing.Point(159, 73);
            this.comboBoxControl_ReceivedAs.Name = "comboBoxControl_ReceivedAs";
            this.comboBoxControl_ReceivedAs.PropertyName = "Received as:";
            this.comboBoxControl_ReceivedAs.PropertyValue = "";
            this.comboBoxControl_ReceivedAs.Size = new System.Drawing.Size(138, 39);
            this.comboBoxControl_ReceivedAs.TabIndex = 6;
            // 
            // textEditorControl_ContactURL
            // 
            this.textEditorControl_ContactURL.LinkTooltip = "";
            this.textEditorControl_ContactURL.LinkValue = "linkLabel1";
            this.textEditorControl_ContactURL.LinkVisible = false;
            this.textEditorControl_ContactURL.Location = new System.Drawing.Point(7, 118);
            this.textEditorControl_ContactURL.MaximumCharsCount = 32767;
            this.textEditorControl_ContactURL.Name = "textEditorControl_ContactURL";
            this.textEditorControl_ContactURL.PropertyName = "Contact URL:";
            this.textEditorControl_ContactURL.PropertyValue = "";
            this.textEditorControl_ContactURL.Size = new System.Drawing.Size(290, 39);
            this.textEditorControl_ContactURL.TabIndex = 7;
            // 
            // textEditorControl_NameOfSeller
            // 
            this.textEditorControl_NameOfSeller.LinkTooltip = "";
            this.textEditorControl_NameOfSeller.LinkValue = "linkLabel1";
            this.textEditorControl_NameOfSeller.LinkVisible = false;
            this.textEditorControl_NameOfSeller.Location = new System.Drawing.Point(7, 163);
            this.textEditorControl_NameOfSeller.MaximumCharsCount = 32767;
            this.textEditorControl_NameOfSeller.Name = "textEditorControl_NameOfSeller";
            this.textEditorControl_NameOfSeller.PropertyName = "Name of seller:";
            this.textEditorControl_NameOfSeller.PropertyValue = "";
            this.textEditorControl_NameOfSeller.Size = new System.Drawing.Size(290, 39);
            this.textEditorControl_NameOfSeller.TabIndex = 8;
            // 
            // richTextControl_Description
            // 
            this.richTextControl_Description.LinkTooltip = "";
            this.richTextControl_Description.LinkValue = "linkLabel1";
            this.richTextControl_Description.LinkVisible = false;
            this.richTextControl_Description.Location = new System.Drawing.Point(7, 208);
            this.richTextControl_Description.Name = "richTextControl_Description";
            this.richTextControl_Description.PropertyName = "Description:";
            this.richTextControl_Description.PropertyValue = "";
            this.richTextControl_Description.Size = new System.Drawing.Size(290, 101);
            this.richTextControl_Description.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Logo:";
            // 
            // imagePanel1
            // 
            this.imagePanel1.ImageToView = null;
            this.imagePanel1.Location = new System.Drawing.Point(8, 334);
            this.imagePanel1.Name = "imagePanel1";
            this.imagePanel1.Size = new System.Drawing.Size(97, 93);
            this.imagePanel1.TabIndex = 11;
            this.imagePanel1.Text = "imagePanel1";
            // 
            // label_picInfo
            // 
            this.label_picInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_picInfo.Location = new System.Drawing.Point(111, 334);
            this.label_picInfo.Name = "label_picInfo";
            this.label_picInfo.Size = new System.Drawing.Size(186, 93);
            this.label_picInfo.TabIndex = 12;
            this.label_picInfo.Text = "MIME: image/jpg\r\nSize: 0 KB\r\nImage size: 0 x 0";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel3.Location = new System.Drawing.Point(140, 312);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(46, 13);
            this.linkLabel3.TabIndex = 15;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "&Save As";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel2.Location = new System.Drawing.Point(102, 312);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(32, 13);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "C&lear";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel1.Location = new System.Drawing.Point(52, 312);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "&Change";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Create new";
            this.toolStripButton3.Click += new System.EventHandler(this.CreateNew);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Delete frame (clear and disable this frame)";
            this.toolStripButton4.Click += new System.EventHandler(this.ClearFrame);
            // 
            // C_Commercial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label_picInfo);
            this.Controls.Add(this.imagePanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextControl_Description);
            this.Controls.Add(this.textEditorControl_NameOfSeller);
            this.Controls.Add(this.textEditorControl_ContactURL);
            this.Controls.Add(this.comboBoxControl_ReceivedAs);
            this.Controls.Add(this.dateControl_ValidUntil);
            this.Controls.Add(this.comboBox_price);
            this.Controls.Add(this.textEditorControl_price);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_Commercial";
            this.Size = new System.Drawing.Size(322, 452);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private TextEditorControl textEditorControl_price;
        private System.Windows.Forms.ComboBox comboBox_price;
        private DateControl dateControl_ValidUntil;
        private ComboBoxControl comboBoxControl_ReceivedAs;
        private TextEditorControl textEditorControl_ContactURL;
        private TextEditorControl textEditorControl_NameOfSeller;
        private RichTextControl richTextControl_Description;
        private System.Windows.Forms.Label label1;
        private ImagePanel imagePanel1;
        private System.Windows.Forms.Label label_picInfo;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}
